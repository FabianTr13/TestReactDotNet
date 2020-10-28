using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabiApi.Entities
{
    public class Lote
    {
        public int Id { get; set; }
        public String Descripcion { set; get; }
        public bool Abierto { set; get; }
        public DateTime FechaCreado { set; get; } = DateTime.Now;
        public DateTime? FechaCerrado { set; get; }
    }
}
