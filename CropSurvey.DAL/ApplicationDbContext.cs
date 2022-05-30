using CropSurvey.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CropSurvey.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Gender>? Genders { get; set; }

        public DbSet<KnowledgeLevel>? KnowledgeLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.SeedGenders(modelBuilder);
            this.SeedKnowledgeLevels(modelBuilder);
        }

        private void SeedGenders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(new Gender { ID = 1, Name = "Muški" });
            modelBuilder.Entity<Gender>().HasData(new Gender { ID = 2, Name = "Ženski" });
            modelBuilder.Entity<Gender>().HasData(new Gender { ID = 3, Name = "Nije navedeno" });
        }

        private void SeedKnowledgeLevels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnowledgeLevel>().HasData(new KnowledgeLevel { ID = 1, Name = "Nikakvo do osnovno" });
            modelBuilder.Entity<KnowledgeLevel>().HasData(new KnowledgeLevel { ID = 2, Name = "Osnovno do srednje" });
            modelBuilder.Entity<KnowledgeLevel>().HasData(new KnowledgeLevel { ID = 3, Name = "Srednje do napredno" });
        }
    }
}