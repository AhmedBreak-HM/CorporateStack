using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<POCO>().Property(x => x.ID).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Language>().Property(x => x.ID).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Language>().HasData(
             new Language { ID = Guid.NewGuid(), Name = "Arabic" },
             new Language { ID = Guid.NewGuid(), Name = "English" },
             new Language { ID = Guid.NewGuid(), Name = "French" }
            );
            modelBuilder.Entity<POCO>()
            .HasOne(x => x.Supervisor)
            .WithMany()
            .HasForeignKey(x => x.SupervisorID);
        }
        public DbSet<POCO> POCOs { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<POCOLanguage> POCOLanguages { get; set; }
    }
}
