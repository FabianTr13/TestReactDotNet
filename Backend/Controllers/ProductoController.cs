using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FabiApi.Entities;
using FabiApi.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;
using FabiApi.DTOs;

namespace FabiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        //DEclares global
        private readonly pgConnection pg;

        //COnstrucctor
        public ProductoController(pgConnection pgCon)
        {
            this.pg = pgCon;
        }

        [HttpGet("getProductos")]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            var productos = await pg.Producto.ToListAsync();

            if (productos == null)
                NoContent();

            return Ok(productos);
        }

        [HttpGet("getMovimientos/{fecha}")]
        public async Task<ActionResult<IEnumerable<ProductoAuxiliar>>> Get(String fecha)
        {
            DateTime fechaSalida = DateTime.Parse(fecha);
            var detalle = await pg.ProductoAuxiliar
                .Where(x => x.FechaSalida == fechaSalida)
                .Include(x => x.Producto)
                .Include(x=> x.TipoTransaccion)
                .ToListAsync();

            if (detalle == null)
                NoContent();

            return Ok(detalle);
        }
    }
}