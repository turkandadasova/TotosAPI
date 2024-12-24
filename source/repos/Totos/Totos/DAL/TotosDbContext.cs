using Microsoft.EntityFrameworkCore;
using Totos.Entities;

namespace Totos.DAL
{
    public class TotosDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<BannedWord> BannedWords { get; set; }


        public TotosDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x => x.Code);
                b.Property(x => x.Code).IsFixedLength(true).HasMaxLength(2);
                b.HasIndex(x => x.Name).IsUnique();
                b.Property(x => x.Name).IsRequired().HasMaxLength(32);
                b.Property(x => x.Icon).IsRequired().HasMaxLength(300);
                b.HasData(new Language
                {
                    Code = "az",
                    Name = "Azərbaycan",
                    Icon= "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.freepik.com%2Ffree-photos-vectors%2Fazerbaijan-flag&psig=AOvVaw3lzlH7C9ThfAHeFF2esETl&ust=1734788454376000&source=images&cd=vfe&opi=89978449&ved=0CBMQjRxqFwoTCJjVkOG8tooDFQAAAAAdAAAAABAE"
                });
            });
            modelBuilder.Entity<Word>(w =>
            {
                w.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(32);
                w.HasOne(x=>x.Language).WithMany(x=>x.Words).HasForeignKey(x=>x.LangCode);
                w.HasMany(x=>x.BannedWords).WithOne(x=>x.Word).HasForeignKey(x=>x.WordId);
            });
            modelBuilder.Entity<Game>(w =>
            {
                w.HasOne(x => x.Language).WithMany(x => x.Games).HasForeignKey(x => x.LangCode);
                
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
