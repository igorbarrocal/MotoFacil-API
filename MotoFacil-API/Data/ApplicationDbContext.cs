using Microsoft.EntityFrameworkCore;
using MotoFacilAPI.Models;
using System.Collections.Generic;

namespace MotoFacilAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Moto> Motos => Set<Moto>();
        public DbSet<Servico> Servicos => Set<Servico>();
    }
}
