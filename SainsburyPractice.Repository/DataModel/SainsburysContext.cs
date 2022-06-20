using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SainsburyPractice.Repository.DataModel
{
    public class SainsburysContext : DbContext
    {
        public SainsburysContext(DbContextOptions<SainsburysContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasComment("Test tables for sainsbury");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateInActive).HasColumnType("datetime");

                entity.Property(e => e.Details)
                    .HasMaxLength(100)
                    .HasColumnName("details");

                entity.Property(e => e.IsValid).HasColumnType("bit(1)");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            base.OnModelCreating(modelBuilder);
        } 
    }
}
