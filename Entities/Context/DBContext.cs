using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Context
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

        public virtual DbSet<TraOficinaEdificio> TraOficinaEdificio { get; set; }

        public virtual DbSet<TraPrioridad> TraPrioridad { get; set; }

        public virtual DbSet<TraReporte> TraReporte { get; set; }

        public virtual DbSet<TraReporteTipoAveriaPrioridadEstadoOficina> TraReporteTipoAveriaPrioridadEstadoOficina { get; set; }

        public virtual DbSet<TraTipoAveria> TraTipoAveria { get; set; }

        public virtual DbSet<TraUsuario> TraUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HAJJ5O1;User Id=sa;Password=12345;Initial Catalog=ReporteAverias;TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TraEdificio>(entity =>
            {
                entity.HasKey(e => e.TnIdEdificio).HasName("PKRA_Edificio");

                entity.ToTable("TRA_Edificio", "EDFS");

                entity.Property(e => e.TnIdEdificio).HasColumnName("TN_IdEdificio");
                entity.Property(e => e.TbActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("TB_Activo");
                entity.Property(e => e.TbEliminado).HasColumnName("TB_Eliminado");
                entity.Property(e => e.TcNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TC_Nombre");
                entity.Property(e => e.TcPropietario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TC_Propietario");
            });

            modelBuilder.Entity<TraEstado>(entity =>
            {
                entity.HasKey(e => e.TnIdEstado).HasName("PKRA_Estado");

                entity.ToTable("TRA_Estado", "AVRS");

                entity.Property(e => e.TnIdEstado).HasColumnName("TN_IdEstado");
                entity.Property(e => e.TbActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("TB_Activo");
                entity.Property(e => e.TbEliminado).HasColumnName("TB_Eliminado");
                entity.Property(e => e.TcNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TC_Nombre");
            });

            modelBuilder.Entity<TraOficina>(entity =>
            {
                entity.HasKey(e => e.TnIdOficina).HasName("PKRA_Oficina");

                entity.ToTable("TRA_Oficina", "EDFS");

                entity.Property(e => e.TnIdOficina).HasColumnName("TN_IdOficina");
                entity.Property(e => e.TbActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("TB_Activo");
                entity.Property(e => e.TbEliminado).HasColumnName("TB_Eliminado");
                entity.Property(e => e.TnNumeroPiso).HasColumnName("TN_NumeroPiso");
            });

            modelBuilder.Entity<TraOficinaEdificio>(entity =>
            {
                entity.HasKey(e => new { e.TnIdEdificio, e.TnIdOficina }).HasName("PKRA_OficinaEdificio");

                entity.ToTable("TRA_OficinaEdificio", "EDFS");

                entity.Property(e => e.TnIdEdificio).HasColumnName("TN_IdEdificio");
                entity.Property(e => e.TnIdOficina).HasColumnName("TN_IdOficina");

                entity.HasOne(d => d.TnIdEdificioNavigation).WithMany(p => p.TraOficinaEdificios)
                    .HasForeignKey(d => d.TnIdEdificio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRA_OficinaEdificio_Edificio");
            });

            modelBuilder.Entity<TraPrioridad>(entity =>
            {
                entity.HasKey(e => e.TnIdPrioridad).HasName("PKRA_Prioridad");

                entity.ToTable("TRA_Prioridad", "AVRS");

                entity.Property(e => e.TnIdPrioridad).HasColumnName("TN_IdPrioridad");
                entity.Property(e => e.TbActiva)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("TB_Activa");
                entity.Property(e => e.TbEliminada).HasColumnName("TB_Eliminada");
                entity.Property(e => e.TcNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TC_Nombre");
            });

            modelBuilder.Entity<TraReporte>(entity =>
            {
                entity.HasKey(e => e.TnIdReporte).HasName("PKRA_Reporte");

                entity.ToTable("TRA_Reporte", "AVRS");

                entity.Property(e => e.TnIdReporte).HasColumnName("TN_IdReporte");
                entity.Property(e => e.TbActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("TB_Activo");
                entity.Property(e => e.TbEliminado).HasColumnName("TB_Eliminado");
                entity.Property(e => e.TcDescripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("TC_Descripcion");
                entity.Property(e => e.TfFecha)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnName("TF_Fecha");

                entity.HasMany(d => d.TnIdUsuarios).WithMany(p => p.TnIdReportes)
                    .UsingEntity<Dictionary<string, object>>(
                        "TraReporteUsuario",
                        r => r.HasOne<TraUsuario>().WithMany()
                            .HasForeignKey("TnIdUsuario")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FKRA_ReporteUsuario_Usuario"),
                        l => l.HasOne<TraReporte>().WithMany()
                            .HasForeignKey("TnIdReporte")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FKRA_ReporteUsuario_Reporte"),
                        j =>
                        {
                            j.HasKey("TnIdReporte", "TnIdUsuario").HasName("PKRA_ReporteUsario");
                            j.ToTable("TRA_ReporteUsuario", "AVRS");
                            j.IndexerProperty<int>("TnIdReporte").HasColumnName("TN_IdReporte");
                            j.IndexerProperty<int>("TnIdUsuario").HasColumnName("TN_IdUsuario");
                        });
            });

            modelBuilder.Entity<TraReporteTipoAveriaPrioridadEstadoOficina>(entity =>
            {
                entity.HasKey(e => new { e.TnIdReporte, e.TnIdTipoAveria, e.TnIdPrioridad, e.TnIdEstado}).HasName("PKRA_ReporteTipoAveriaPrioridadEstadoOficina");

                entity.ToTable("TRA_ReporteTipoAveriaPrioridadEstadoOficina", "AVRS");

                entity.Property(e => e.TnIdReporte).HasColumnName("TN_IdReporte");
                entity.Property(e => e.TnIdTipoAveria).HasColumnName("TN_IdTipoAveria");
                entity.Property(e => e.TnIdPrioridad).HasColumnName("TN_IdPrioridad");
                entity.Property(e => e.TnIdEstado).HasColumnName("TN_IdEstado");

                entity.HasOne(d => d.TnIdEstadoNavigation).WithMany(p => p.TraReporteTipoAveriaPrioridadEstadoOficinas)
                    .HasForeignKey(d => d.TnIdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRA_Reporte_Estado");

                entity.HasOne(d => d.TnIdPrioridadNavigation).WithMany(p => p.TraReporteTipoAveriaPrioridadEstadoOficinas)
                    .HasForeignKey(d => d.TnIdPrioridad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRA_Reporte_Prioridad");

                entity.HasOne(d => d.TnIdReporteNavigation).WithMany(p => p.TraReporteTipoAveriaPrioridadEstadoOficinas)
                    .HasForeignKey(d => d.TnIdReporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PKRA_ReporteTAPEO_Reporte");

                entity.HasOne(d => d.TnIdTipoAveriaNavigation).WithMany(p => p.TraReporteTipoAveriaPrioridadEstadoOficinas)
                    .HasForeignKey(d => d.TnIdTipoAveria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRA_Reporte_TipoAveria");
            });

            modelBuilder.Entity<TraTipoAveria>(entity =>
            {
                entity.HasKey(e => e.TnIdTipoAveria).HasName("PKRA_TipoAveria");

                entity.ToTable("TRA_TipoAveria", "AVRS");

                entity.Property(e => e.TnIdTipoAveria).HasColumnName("TN_IdTipoAveria");
                entity.Property(e => e.TbActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("TB_Activo");
                entity.Property(e => e.TbEliminado).HasColumnName("TB_Eliminado");
                entity.Property(e => e.TcDescripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("TC_Descripcion");
            });

            modelBuilder.Entity<TraUsuario>(entity =>
            {
                entity.HasKey(e => e.TnIdUsuario).HasName("PKRA_Usuario");

                entity.ToTable("TRA_Usuario", "USRS");

                entity.Property(e => e.TnIdUsuario).HasColumnName("TN_IdUsuario");
                entity.Property(e => e.TbActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasColumnName("TB_Activo");
                entity.Property(e => e.TbEliminado).HasColumnName("TB_Eliminado");
                entity.Property(e => e.TcApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TC_Apellido");
                entity.Property(e => e.TcCedula)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("TC_Cedula");
                entity.Property(e => e.TcContrasennia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TC_Contrasennia");
                entity.Property(e => e.TcCorreo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TC_Correo");
                entity.Property(e => e.TcNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TC_Nombre");
                entity.Property(e => e.TcRol)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TC_Rol");

                entity.HasMany(d => d.TnIdOficinas).WithMany(p => p.TnIdUsuarios)
                    .UsingEntity<Dictionary<string, object>>(
                        "TraUsuarioOficina",
                        r => r.HasOne<TraOficina>().WithMany()
                            .HasForeignKey("TnIdOficina")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FKRA_Usuario_Oficina"),
                        l => l.HasOne<TraUsuario>().WithMany()
                            .HasForeignKey("TnIdUsuario")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FKRA_ReporteUsuario_Usuario"),
                        j =>
                        {
                            j.HasKey("TnIdUsuario", "TnIdOficina").HasName("PKRA_UsuarioOficina");
                            j.ToTable("TRA_UsuarioOficina", "USRS");
                            j.IndexerProperty<int>("TnIdUsuario").HasColumnName("TN_IdUsuario");
                            j.IndexerProperty<int>("TnIdOficina").HasColumnName("TN_IdOficina");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
