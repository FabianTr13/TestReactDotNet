using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FabiApi.Entities;
using FabiApi.Context;
using Microsoft.EntityFrameworkCore;
using FabiApi.DTOs;

namespace FabiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        //Declares global
        private readonly pgConnection pg;

        //Construcctor
        public DocumentoController(pgConnection pgCon)
        {
            this.pg = pgCon;
        }

        [HttpGet("getDocumento/{id}")]
        public async Task<ActionResult<IEnumerable<DocumentoDetalle>>> Get(int id)
        {
            var detalle = await pg.DocumentoDetalles
                .Where(x => x.DocumentoId == id)
                .Where(x => x.TipoTransaccionId == 2)
                .Include(x => x.Producto)
                .ToListAsync();
            if (detalle == null)
                return NoContent();

            return detalle;
        }

        [HttpPost("setRequisicion")]
        public async Task<ActionResult> Get([FromBody] setRequisicion request)
        {
            int newDocumentoId;
            using (var context = pg)
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //Creamos el documento
                        var documento = new Documento
                        {
                            Proveedor = "api",
                            Descripcion = "ninguna",
                            FechaCreado = DateTime.Now
                        };

                        context.Documento.Add(documento);
                        await context.SaveChangesAsync();

                        newDocumentoId = documento.Id;

                        //Pasamos por cada producto
                        foreach (ProductoRequisicion item in request.Productos)
                        {
                            //Buscamos el detalle de lote y verificamos cantidad usada
                            var lotedetalle = await context.LoteDetalles.FirstOrDefaultAsync(x => x.LoteId == item.Loteid && x.ProductoId == item.ProductoId);

                            if (lotedetalle.CantidadRestante < item.cantidad)
                            {
                                await dbContextTransaction.RollbackAsync();
                                return NotFound();
                            }

                            lotedetalle.CantidadRestante -= item.cantidad;
                            context.Entry(lotedetalle).State = EntityState.Modified;
                            await context.SaveChangesAsync();

                            //Insertamos el detalle de documento
                            var Docdetalle = new DocumentoDetalle
                            {
                                TipoTransaccionId = 2,
                                ProductoId = item.ProductoId,
                                DocumentoId = documento.Id,
                                LoteId = item.Loteid,
                                Cantidad = item.cantidad,
                                Costo = lotedetalle.Costo

                            };

                            context.DocumentoDetalles.Add(Docdetalle);
                            await context.SaveChangesAsync();

                            //Insertamos en el auxiliar de productos
                            var productAux = new ProductoAuxiliar
                            {
                                FechaSalida = DateTime.Now,
                                ProductoId = item.ProductoId,
                                tipoTransaccionId = 2,
                                DocumentoId = documento.Id,
                                Cantidad = item.cantidad,
                                CantidadRestante = lotedetalle.CantidadRestante,
                                LoteId = item.Loteid
                            };
                            context.Add(productAux);
                            await context.SaveChangesAsync();

                        }
                    }
                    catch (Exception)
                    {
                        await dbContextTransaction.RollbackAsync();
                        return NotFound();
                    }

                    await context.SaveChangesAsync();

                    dbContextTransaction.Commit();
                }
            }

            return Ok(new { idDocumento = newDocumentoId });
        }

        [HttpPost("revertDocumento")]
        public async Task<ActionResult> Get([FromBody] List<DocumentoDetalle> Productos)
        {
            using (var context = pg)
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (DocumentoDetalle item in Productos)
                        {
                            //Revert lote
                            var lotedetalle = await context.LoteDetalles.FirstOrDefaultAsync(x => x.LoteId == item.LoteId && x.ProductoId == item.ProductoId);

                            lotedetalle.CantidadRestante += item.Cantidad;
                            context.Entry(lotedetalle).State = EntityState.Modified;
                            await context.SaveChangesAsync();

                            //Revert Auxiliar
                            var productAux = new ProductoAuxiliar
                            {
                                FechaSalida = DateTime.Now,
                                ProductoId = item.ProductoId,
                                tipoTransaccionId = 1,
                                DocumentoId = item.DocumentoId,
                                Cantidad = item.Cantidad,
                                CantidadRestante = lotedetalle.CantidadRestante,
                                LoteId = item.LoteId
                            };
                            context.Add(productAux);
                            await context.SaveChangesAsync();

                            //Revert Documento
                            var detalle = await context.DocumentoDetalles.FirstOrDefaultAsync(x => x.Id == item.Id);
                            detalle.Cantidad = 0;
                            context.Entry(detalle).State = EntityState.Modified;
                            await context.SaveChangesAsync();
                        }
                    }
                    catch (Exception)
                    {
                        await dbContextTransaction.RollbackAsync();
                        return NotFound();
                    }

                    await context.SaveChangesAsync();

                    dbContextTransaction.Commit();
                }
            }

            return Ok();
        }
    }
}