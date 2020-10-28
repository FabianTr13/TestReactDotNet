using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabiApi.Entities
{
    public class Documento
    {
        public int Id { get; set; }
        public string Proveedor { set; get; }
        public string Descripcion {set; get;} 
        public DateTime FechaCreado { set; get; }
    }
}
