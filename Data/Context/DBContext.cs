using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Context
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TraEdificio> TraEdificio { get; set; }
        public virtual DbSet<TraEstado> TraEstado { get; set; }
        public virtual DbSet<TraOficina> TraOficina { get; set; }
        public virtual DbSet<TraPrioridad> TraPrioridad { get; set; }
        public virtual DbSet<TraReporte> TraReporte { get; set; }
        public virtual DbSet<TraReporteUsuario> TraReporteUsuario { get; set; }
        public virtual DbSet<TraTipoAveria> TraTipoAveria { get; set; }
        public virtual DbSet<Usuario> TraUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=163.178.107.10;Database=ReporteAverias_2023;User Id=laboratorios;Password=TUy&)&nfC7QqQau.%278UQ24/=%;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TraEdificio>(entity =>
            {
                entity.HasKey(e => e.TnIdEdificio)
                    .HasName("PKRA_Edificio");

                entity.ToTable("TRA_Edificio", "EDFS");

                entity.Property(e => e.TnIdEdificio).HasColumnName("TN_IdEdificio");

                entity.Property(e => e.TbActivo)
                    .IsRequired()
                    .HasColumnName("TB_Activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TbEliminado).HasColumnName("TB_Eliminado");

                entity.Property(e => e.TcNombre)
                    .IsRequired()
                    .HasColumnName("TC_Nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TcPropietario)
                    .IsRequired()
                    .HasColumnName("TC_Propietario")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TraEstado>(entity =>
            {
                entity.HasKey(e => e.TnIdEstado)
                    .HasName("PKRA_Estado");

                entity.ToTable("TRA_Estado", "AVRS");

                entity.Property(e => e.TnIdEstado).HasColumnName("TN_IdEstado");

                entity.Property(e => e.TbActivo)
                    .IsRequired()
                    .HasColumnName("TB_Activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TbEliminado).HasColumnName("TB_Eliminado");

                entity.Property(e => e.TcNombre)
                    .IsRequired()
                    .HasColumnName("TC_Nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TraOficina>(entity =>
            {
                entity.HasKey(e => e.TnIdOficina)
                    .HasName("PKRA_Oficina");

                entity.ToTable("TRA_Oficina", "EDFS");

                entity.Property(e => e.TnIdOficina).HasColumnName("TN_IdOficina");

                entity.Property(e => e.TbActivo)
                    .IsRequired()
                    .HasColumnName("TB_Activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TbEliminado).HasColumnName("TB_Eliminado");

                entity.Property(e => e.TnEdificio).HasColumnName("TN_Edificio");

                entity.Property(e => e.TnNumeroPiso).HasColumnName("TN_NumeroPiso");

                entity.HasOne(d => d.TnEdificioNavigation)
                    .WithMany(p => p.TraOficina)
                    .HasForeignKey(d => d.TnEdificio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRA_Oficina_Edificio");
            });

            modelBuilder.Entity<TraPrioridad>(entity =>
            {
                entity.HasKey(e => e.TnIdPrioridad)
                    .HasName("PKRA_Prioridad");

                entity.ToTable("TRA_Prioridad", "AVRS");

                entity.Property(e => e.TnIdPrioridad).HasColumnName("TN_IdPrioridad");

                entity.Property(e => e.TbActiva)
                    .IsRequired()
                    .HasColumnName("TB_Activa")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TbEliminada).HasColumnName("TB_Eliminada");

                entity.Property(e => e.TcNombre)
                    .IsRequired()
                    .HasColumnName("TC_Nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TraReporte>(entity =>
            {
                entity.HasKey(e => e.TnIdReporte)
                    .HasName("PKRA_Reporte");

                entity.ToTable("TRA_Reporte", "AVRS");

                entity.Property(e => e.TnIdReporte).HasColumnName("TN_IdReporte");

                entity.Property(e => e.TbActivo)
                    .IsRequired()
                    .HasColumnName("TB_Activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TbEliminado).HasColumnName("TB_Eliminado");

                entity.Property(e => e.TcDescripcion)
                    .IsRequired()
                    .HasColumnName("TC_Descripcion")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TfFecha)
                    .HasColumnName("TF_Fecha")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TnEstado).HasColumnName("TN_Estado");

                entity.Property(e => e.TnOficina).HasColumnName("TN_Oficina");

                entity.Property(e => e.TnPrioridad).HasColumnName("TN_Prioridad");

                entity.Property(e => e.TnTipoAveria).HasColumnName("TN_TipoAveria");

                entity.HasOne(d => d.TnEstadoNavigation)
                    .WithMany(p => p.TraReporte)
                    .HasForeignKey(d => d.TnEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRA_Reporte_Estado");

                entity.HasOne(d => d.TnOficinaNavigation)
                    .WithMany(p => p.TraReporte)
                    .HasForeignKey(d => d.TnOficina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRA_Reporte_Oficina");

                entity.HasOne(d => d.TnPrioridadNavigation)
                    .WithMany(p => p.TraReporte)
                    .HasForeignKey(d => d.TnPrioridad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRA_Reporte_Prioridad");

                entity.HasOne(d => d.TnTipoAveriaNavigation)
                    .WithMany(p => p.TraReporte)
                    .HasForeignKey(d => d.TnTipoAveria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRA_Reporte_TipoAveria");
            });

            modelBuilder.Entity<TraReporteUsuario>(entity =>
            {
                entity.HasKey(e => new { e.TnIdReporte, e.TnIdUsuario })
                    .HasName("PKRA_ReporteUsario");

                entity.ToTable("TRA_ReporteUsuario", "AVRS");

                entity.Property(e => e.TnIdReporte).HasColumnName("TN_IdReporte");

                entity.Property(e => e.TnIdUsuario).HasColumnName("TN_IdUsuario");

                entity.HasOne(d => d.TnIdReporteNavigation)
                    .WithMany(p => p.TraReporteUsuario)
                    .HasForeignKey(d => d.TnIdReporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRA_ReporteUsuario_Reporte");

                entity.HasOne(d => d.TnIdUsuarioNavigation)
                    .WithMany(p => p.TraReporteUsuario)
                    .HasForeignKey(d => d.TnIdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRA_ReporteUsuario_Usuario");
            });

            modelBuilder.Entity<TraTipoAveria>(entity =>
            {
                entity.HasKey(e => e.TnIdTipoAveria)
                    .HasName("PKRA_TipoAveria");

                entity.ToTable("TRA_TipoAveria", "AVRS");

                entity.Property(e => e.TnIdTipoAveria).HasColumnName("TN_IdTipoAveria");

                entity.Property(e => e.TbActivo)
                    .IsRequired()
                    .HasColumnName("TB_Activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TbEliminado).HasColumnName("TB_Eliminado");

                entity.Property(e => e.TcDescripcion)
                    .HasColumnName("TC_Descripcion")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TraUsuario>(entity =>
            {
                entity.HasKey(e => e.TnIdUsuario)
                    .HasName("PKRA_Usuario");

                entity.ToTable("TRA_Usuario", "USRS");

                entity.Property(e => e.TnIdUsuario).HasColumnName("TN_IdUsuario");

                entity.Property(e => e.TbActivo)
                    .IsRequired()
                    .HasColumnName("TB_Activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TbEliminado).HasColumnName("TB_Eliminado");

                entity.Property(e => e.TcApellido)
                    .IsRequired()
                    .HasColumnName("TC_Apellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TcCedula)
                    .IsRequired()
                    .HasColumnName("TC_Cedula")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.TcContrasennia)
                    .IsRequired()
                    .HasColumnName("TC_Contrasennia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TcCorreo)
                    .IsRequired()
                    .HasColumnName("TC_Correo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TcNombre)
                    .IsRequired()
                    .HasColumnName("TC_Nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TcRol)
                    .IsRequired()
                    .HasColumnName("TC_Rol")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TnOficina).HasColumnName("TN_Oficina");

                entity.HasOne(d => d.TnOficinaNavigation)
                    .WithMany(p => p.TraUsuario)
                    .HasForeignKey(d => d.TnOficina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRA_Usuario_Oficina");
            });
        }
    }
}
