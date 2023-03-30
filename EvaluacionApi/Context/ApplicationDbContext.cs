using EvaluacionApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvaluacionApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
