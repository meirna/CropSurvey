using System.Globalization;
using CropSurvey.Model;
using Microsoft.AspNetCore.Identity;
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

        public DbSet<Photo>? Photos { get; set; }

        public DbSet<PhotoCategory>? PhotoCategories { get; set; }

        public DbSet<Crop>? Crops { get; set; }

        public DbSet<Rating>? Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //this.SeedGenders(modelBuilder);
            //this.SeedKnowledgeLevels(modelBuilder);
            //this.SeedPhotoCategories(modelBuilder);
            //this.SeedPhotos(modelBuilder);
            //this.SeedCrops(modelBuilder);
            //this.SeedRoles(modelBuilder);
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

        private void SeedPhotoCategories(ModelBuilder modelBuilder)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(currentDirectory, "..", "..", "..", "..", "CropSurvey.DAL", "Data", "photos.csv");
            using (var reader = new StreamReader(path))
            {
                var header = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    modelBuilder.Entity<PhotoCategory>().HasData(new PhotoCategory { ID = Int32.Parse(values[0]), Name = values[1] });
                }
            }
        }

        private void SeedPhotos(ModelBuilder modelBuilder)
        {
            using (var reader = new StreamReader(@"..\CropSurvey.DAL\Data\photos.csv"))
            {
                var header = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    modelBuilder.Entity<Photo>().HasData(new Photo { CategoryID = Int32.Parse(values[0]), ID = values[1] });
                }
            }
        }

        private void SeedCrops(ModelBuilder modelBuilder)
        {
            using (var reader = new StreamReader(@"..\CropSurvey.DAL\Data\crops.csv"))
            {
                var header = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    modelBuilder.Entity<Crop>().HasData(new Crop { 
                        ID = values[0],
                        PhotoID = values[1],
                        AspectRatio = values[2],
                        Algorithm = values[3],
                        Timer = double.Parse(values[4], CultureInfo.InvariantCulture)
                    });
                }
            }
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole() { Name = "Admin" });
        }
    }
}