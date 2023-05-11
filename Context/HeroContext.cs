using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SpHero.Models;

namespace SpHero.Context
{
    public class HeroContext:DbContext
    {
        public HeroContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-3MT64N8;Initial Catalog=myDataBase; Integrated Security=True;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
            .HasOne(h => h.School)
            .WithMany(s => s.Heroes)
            .HasForeignKey(h => h.School);

            modelBuilder.Entity<Hero>()
                .HasMany(h => h.Powers)
                .WithMany(p => p.Heroes);

            modelBuilder.Entity<Power>()
                .HasMany(p => p.Heroes)
                .WithMany(h => h.Powers);

            base.OnModelCreating(modelBuilder);

        }

        //entities
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<School> Schools { get; set; }
    }

}
