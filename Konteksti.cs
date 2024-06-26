using OnlineBookStoreApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace OnlineBookStoreApp.Data
{
    public class Konteksti : IdentityDbContext
    {
        public Konteksti(DbContextOptions<Konteksti> op) : base(op)
        {

        }

        public DbSet<Kategoria> Kategorite { get; set; }
        public DbSet<Kopertina> Kopertinat { get; set; }
        public DbSet<Produkti> Produktet { get; set; }
        public DbSet<Shporta> Shportat { get; set; }
        public DbSet<Perdorusi> Perdorusit { get; set; }
        public DbSet<Kompania> Kompania { get; set; }
        public DbSet<Porosia> Porosite { get; set; }
        public DbSet<DetajetEPorosise> DetajetEPorosive { get; set; }
    }
}