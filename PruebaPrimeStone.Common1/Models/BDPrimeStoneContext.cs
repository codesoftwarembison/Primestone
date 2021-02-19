using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaPrimeStone.Common1.Models
{
    public partial class BDPrimeStoneContext : DbContext
    {
        public BDPrimeStoneContext()
        {
        }

        public BDPrimeStoneContext(DbContextOptions<BDPrimeStoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Direccione> Direcciones { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<EstudianteCurso> EstudianteCursos { get; set; }
        public virtual DbSet<EstudianteDireccion> EstudianteDireccions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-L6V7QIRL\\SQLOCAL;Initial Catalog=BDPrimeStone;User ID=sa;Password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__085F27D657EE7FE9");

                entity.ToTable("Curso");

                entity.Property(e => e.FechaFin).HasMaxLength(10);

                entity.Property(e => e.FechaInicio).HasMaxLength(10);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Tiempo).HasMaxLength(10);
            });

            modelBuilder.Entity<Direccione>(entity =>
            {
                entity.HasKey(e => e.IdDireccion)
                    .HasName("PK__Direccio__1F8E0C76080C44E1");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__Estudian__B5007C241FC6AE50");

                entity.ToTable("Estudiante");

                entity.Property(e => e.Edad).HasMaxLength(10);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<EstudianteCurso>(entity =>
            {
                entity.HasKey(e => e.IdEstudianteCurso)
                    .HasName("PK__Estudian__D4C2F4F992D96477");

                entity.ToTable("EstudianteCurso");

                entity.HasOne(d => d.CursoNavigation)
                    .WithMany(p => p.EstudianteCursos)
                    .HasForeignKey(d => d.Curso)
                    .HasConstraintName("FK__Estudiant__Curso__2B3F6F97");

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.EstudianteCursos)
                    .HasForeignKey(d => d.Estudiante)
                    .HasConstraintName("FK__Estudiant__Estud__2A4B4B5E");
            });

            modelBuilder.Entity<EstudianteDireccion>(entity =>
            {
                entity.HasKey(e => e.IdEstudianteDireccion)
                    .HasName("PK__Estudian__B6DAA0B940EB0309");

                entity.ToTable("EstudianteDireccion");

                entity.HasOne(d => d.DireccionNavigation)
                    .WithMany(p => p.EstudianteDireccions)
                    .HasForeignKey(d => d.Direccion)
                    .HasConstraintName("FK__Estudiant__Direc__2F10007B");

                entity.HasOne(d => d.EstudianteNavigation)
                    .WithMany(p => p.EstudianteDireccions)
                    .HasForeignKey(d => d.Estudiante)
                    .HasConstraintName("FK__Estudiant__Estud__2E1BDC42");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
