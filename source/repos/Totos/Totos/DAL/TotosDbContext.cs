using Microsoft.EntityFrameworkCore;
using Totos.Entities;

namespace Totos.DAL
{
    public class TotosDbContext : DbContext
    {
        public TotosDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Language> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b =>
            {

                b.HasKey(x => x.Code);
                b.Property(x => x.Code).IsFixedLength(true).HasMaxLength(2);
                b.HasIndex(x => x.Name).IsUnique();
                b.Property(x => x.Name).IsRequired().HasMaxLength(32);
                b.Property(x => x.Icon).IsRequired().HasMaxLength(128);

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
