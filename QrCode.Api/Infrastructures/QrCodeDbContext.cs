using Microsoft.EntityFrameworkCore;
using QrCode.Api.Entities;

namespace QrCode.Api.Infrastructures
{
    public class QrCodeDbContext : DbContext
    {
        public DbSet<ProdutoEntity> Produtos { get; set; }
        public DbSet<CertificadoEntity> Certificados { get; set; }
        public QrCodeDbContext(DbContextOptions<QrCodeDbContext> options):base (options)
        {
           
        }
    }
}
