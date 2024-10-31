using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using WebWellsMVC.WellDb.DbModels;
using WebWellsMVC;


namespace WebWellsMVC.WellDb.DBContext
{
    public partial class WellsDbContext : DbContext
    {
        private readonly string? _connectionString;
        public WellsDbContext()
        {
        }
        public string connectionString;

        public WellsDbContext(DbContextOptions<WellsDbContext> options)
     : base(options)
        {

        }
        public virtual DbSet<Users> users { get; set; }
        public virtual DbSet<Wells> wells { get; set; }

        //   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer(_connectionString);

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder()
        //          .AddJsonFile("appsettings.json")
        //          .SetBasePath(Directory.GetCurrentDirectory())
        //          .Build();
        //    optionsBuilder.UseSqlServer("DefaultConnection");


        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Wells>(entity =>
            {
                entity.HasKey(e => e.UWI).HasName("PK_Wells");
                
                entity.Property(e => e.UWI).UseIdentityColumn();

                entity.Property(e => e.UWI).ValueGeneratedNever()
                .HasColumnName("UWI");
                entity.Property(e => e.Date).HasColumnType("datetime2");
                entity.HasData(
                        new Wells { UWI = 1, Name = "Скважина_001", Bush = "Первый куст", Type = "газовая", OpMethod = "фонтанный", Stage = "эксплуатация", Date = DateTime.Parse("2022-01-01 15:30:00.000") }
                );
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Users");
                entity.Property(e => e.Id).UseIdentityColumn();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}