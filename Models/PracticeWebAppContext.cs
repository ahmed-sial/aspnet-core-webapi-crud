using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _WebApi.Models;

public partial class PracticeWebAppContext : DbContext
{
    public PracticeWebAppContext()
    {
    }

    public PracticeWebAppContext(DbContextOptions<PracticeWebAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3214EC0763CB8956");

            entity.ToTable("students");

            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentGender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
