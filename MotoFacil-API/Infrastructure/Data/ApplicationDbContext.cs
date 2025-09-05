using Microsoft.EntityFrameworkCore;
using MotoFacilAPI.Domain.Entities;
using MotoFacilAPI.Domain.ValueObjects;

namespace MotoFacilAPI.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Moto> Motos => Set<Moto>();
        public DbSet<Servico> Servicos => Set<Servico>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(b =>
            {
                b.OwnsOne(u => u.Email, eo =>
                {
                    eo.Property(e => e.Value).HasColumnName("Email").IsRequired();
                });
                b.Navigation(u => u.Motos).AutoInclude(false);
            });
        }
    }
}