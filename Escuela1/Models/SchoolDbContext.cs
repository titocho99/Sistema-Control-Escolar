using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Escuela1.Models;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AlumnosDetalle> AlumnosDetalles { get; set; }

    public virtual DbSet<Maestro> Maestros { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno);

            entity.Property(e => e.IdAlumno).HasColumnName("Id_Alumno");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nua)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AlumnosDetalle>(entity =>
        {
            entity.ToTable("AlumnosDetalle");

            entity.Property(e => e.Calificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdAlumno).HasColumnName("Id_Alumno");
            entity.Property(e => e.IdMateria).HasColumnName("Id_Materia");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.AlumnosDetalles)
                .HasForeignKey(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlumnosDetalle_Alumnos");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.AlumnosDetalles)
                .HasForeignKey(d => d.IdMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlumnosDetalle_Materias");
        });

        modelBuilder.Entity<Maestro>(entity =>
        {
            entity.HasKey(e => e.IdProfesor);

            entity.Property(e => e.IdProfesor).HasColumnName("Id_Profesor");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nup)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.IdMateria);

            entity.Property(e => e.IdMateria).HasColumnName("Id_Materia");
            entity.Property(e => e.IdProfesor).HasColumnName("Id_Profesor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Materia)
                .HasForeignKey(d => d.IdProfesor)
                .HasConstraintName("FK_Materias_Maestros");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
