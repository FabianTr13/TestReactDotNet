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
    public class TipoTransaccionController : ControllerBase
    {
        //DEclares global
        private readonly pgConnection pg;

        //COnstrucctor
        public TipoTransaccionController(pgConnection pgCon)
        {
            this.pg = pgCon;
        }

        [HttpGet("/getTipos")]
        public async Task<ActionResult<IEnumerable<TipoTransaccion>>> Get()
        {
            var tipos = await pg.TipoTransaccions.ToListAsync();

            if (tipos == null)
                return NotFound();

            return Ok(tipos);
        }
    }
}