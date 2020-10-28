using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabiApi.DTOs
{
    public class ProductoRequisicion
    {
        public int ProductoId { set; get; }
        public int Loteid { set; get; }
        public int cantidad { set; get; }
    }
}
