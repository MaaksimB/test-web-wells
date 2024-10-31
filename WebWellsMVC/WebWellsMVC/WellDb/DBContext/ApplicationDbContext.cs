using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebWellsMVC.WellDb.DbModels;
using Microsoft.EntityFrameworkCore.Storage;
using WebWellsMVC;

namespace WebWellsMVC.WellDb.DBContext
{
    public partial class ApplicationDbContext : DbContext
    {
        public DbSet<Users> users => Set<Users>();
        public DbSet<Wells> wells => Set<Wells>();

        // public ApplicationDbContext() => Database.EnsureCreated();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)

        {
           // Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{


        //    modelBuilder.Entity<Wells>(entity =>
        //    {
        //        entity.HasKey(e => e.UWI).HasName("PK_Wells");

        //        entity.Property(e => e.UWI).UseIdentityColumn();

        //        entity.Property(e => e.UWI).ValueGeneratedNever()
        //        .HasColumnName("UWI");
        //        entity.Property(e => e.Date).HasColumnType("datetime2");
        //        entity.HasData(
        //                new Wells { UWI = 1, Name = "Скважина_001", Bush = "Первый куст", Type = "газовая", OpMethod = "фонтанный", Stage = "эксплуатация", Date = DateTime.Parse("2022-01-01 15:30:00.000") }
        //        );
        //    });

        //    modelBuilder.Entity<Users>(entity =>
        //    {
        //        entity.HasKey(e => e.Id).HasName("PK_Users");
        //        entity.Property(e => e.Id).UseIdentityColumn();

        //        entity.Property(e => e.Id).ValueGeneratedNever();
        //    });
        //}
    }
}