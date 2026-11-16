using Microsoft.EntityFrameworkCore;
using CuidarDePerto.Api.Models; // Certifica-te de que este namespace corresponde ao das tuas classes Idoso e Alerta

namespace CuidarDePerto.Api.Data
{
    public class CuidarDePertoContext : DbContext
    {
        public CuidarDePertoContext(DbContextOptions<CuidarDePertoContext> options) : base(options)
        {
        }

        public DbSet<Idoso> Idosos { get; set; }
        public DbSet<Alerta> Alertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alerta>()
                .HasOne(a => a.Idoso)
                .WithMany(i => i.Alertas)
                .HasForeignKey(a => a.IdosoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}