using System;
using System.Collections.Generic;
using DemoEFCore.DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCore.DataLayer;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<JobRole> JobRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DemoEFCore;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__Employee__3214EC07D6657D7A");

            entity.ToTable("Employee");

            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.EmpId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<JobRole>(entity =>
        {
            entity.HasKey(e => e.JobRoleNo).HasName("PK__JobRole__6DF4458D711B9A0B");

            entity.ToTable("JobRole");

            entity.Property(e => e.JobRoleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.JobRoleName).HasMaxLength(100);

            entity.HasOne(d => d.EmpNoNavigation).WithMany(p => p.JobRoles)
                .HasForeignKey(d => d.EmpNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobRole_Employee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
