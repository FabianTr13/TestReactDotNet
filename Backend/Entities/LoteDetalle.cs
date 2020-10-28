using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabiApi.Entities
{
    public class LoteDetalle
    {
        public int Id { get; set; }
        public int ProductoId { set; get; }
        public Producto Producto { set; get; }
        public int LoteId { set; get; }
        public Lote Lote { set; get; }
        public int Cantidad { set; get; }
        public int CantidadUsada { set; get; }
        public int? CantidadRestante { set; get; }
        public double Costo { set; get; }
        public DateTime FechaCreado { set; get; }
}
}
