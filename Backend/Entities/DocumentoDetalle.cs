using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabiApi.Entities
{
    public class DocumentoDetalle
    {
        public int Id { get; set; }
        public int TipoTransaccionId { set; get; }
        public TipoTransaccion TipoTransaccion { set; get; }
        public int ProductoId { set; get; }
        public Producto Producto { set; get; }
        public int DocumentoId { set; get; }
        public Documento Documento { set; get; }
        public int LoteId { set; get; }
        public Lote Lote { set; get; }
        public int Cantidad { set; get; }
        public double Costo { set; get; }

    }
}
