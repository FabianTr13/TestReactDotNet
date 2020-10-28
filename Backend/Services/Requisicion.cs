using FabiApi.Context;
using FabiApi.DTOs;
using FabiApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabiApi.Services
{
    public class Requisicion
    {
        public async Task<bool> CrearRequisicion(List<ProductoRequisicion> Productos, pgConnection pg)
        {
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

                        //Pasamos por cada producto
                        foreach (ProductoRequisicion item in Productos)
                        {
                            //Buscamos el detalle de lote y verificamos cantidad usada
                            var lotedetalle = await context.LoteDetalles.FirstOrDefaultAsync(x => x.LoteId == item.Loteid && x.ProductoId == item.ProductoId);

                            if (lotedetalle.CantidadRestante < item.cantidad)
                            {
                                await dbContextTransaction.RollbackAsync();
                                return false;
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
                        return false;
                    }

                    await context.SaveChangesAsync();

                    dbContextTransaction.Commit();
                }
            }

            return true;
        }
    }
}
