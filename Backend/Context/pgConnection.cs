using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FabiApi.Entities;

namespace FabiApi.Context
{
    public class pgConnection : DbContext
    {
        public pgConnection()
        {

        }
        public pgConnection(DbContextOptions<pgConnection> options) : base(options)
        { }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoAuxiliar> ProductoAuxiliar { get; set; }

        public DbSet<Lote> Lote { get; set; }
        public DbSet<LoteDetalle> LoteDetalles { get; set; }

        public DbSet<TipoTransaccion> TipoTransaccions { get; set; }

        public DbSet<Documento> Documento { get; set; }
        public DbSet<DocumentoDetalle> DocumentoDetalles { get; set; }
    }
}