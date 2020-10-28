using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FabiApi.Entities
{
    public class ProductoAuxiliar
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Column(TypeName = "date")]
        public DateTime? FechaSalida { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int tipoTransaccionId { get; set; }
        public TipoTransaccion TipoTransaccion { get; set; }
        public int DocumentoId { get; set; }
        public Documento Documento { get; set; }
        public int Cantidad { get; set; }
        public int? CantidadRestante { set; get; }
        public int LoteId { set; get; }
        public Lote Lote { set; get; }
}
}
