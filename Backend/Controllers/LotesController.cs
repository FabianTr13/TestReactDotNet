using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FabiApi.Entities;
using FabiApi.Context;
using Microsoft.EntityFrameworkCore;

namespace FabiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesController : ControllerBase
    {
        //DEclares global
        private readonly pgConnection pg;

        //COnstrucctor
        public LotesController(pgConnection pgCon)
        {
            this.pg = pgCon;
        }

        [HttpGet("getLotes/{id}")]
        public async Task<ActionResult<IEnumerable<LoteDetalle>>> Get(int id)
        {
             var lotes = await pg.LoteDetalles.Where(x => x.ProductoId == id).Where(x => x.CantidadRestante > 0).ToListAsync();
            if (lotes == null)
                return NoContent();

            return lotes;
        }
    }
}