using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Time_Management.Models;

public partial class ApplicationDbContext2 : DbContext
{
    public ApplicationDbContext2()
    {
    }

    public ApplicationDbContext2(DbContextOptions<ApplicationDbContext2> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicModule> AcademicModules { get; set; }

    public virtual DbSet<AcademicSemester> AcademicSemesters { get; set; }

    public virtual DbSet<SelfStudySession> SelfStudySessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-Time_Management-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicModule>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__academic__1A2D065348496EFC");
        });

        modelBuilder.Entity<AcademicSemester>(entity =>
        {
            entity.HasKey(e => e.SemesterId).HasName("PK__academic__CBC81B01EFE05A66");
        });

        modelBuilder.Entity<SelfStudySession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__self_stu__69B13FDCDB676CDD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
