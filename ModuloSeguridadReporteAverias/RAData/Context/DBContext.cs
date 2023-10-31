using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAEntities.Entities;

namespace RAData.Context
{
    public partial class BDContext : DbContext
    {
        public BDContext()
        {
        }

        public virtual DbSet<Usuario> TRA_Usuario { get; set; }

        public virtual DbSet<Rol> TReporteDeAverias_Rol { get; set; }

        public virtual DbSet<Oficina> TReporteDeAverias_Oficina { get; set; }

        public virtual DbSet<UsuarioRolOficina> TReporteDeAverias_UsuarioRolOficina { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            options.UseSqlServer($"Data Source=YAREX;Initial Catalog=ReporteAverias;Persist Security Info=True;User ID=sa;Password=12345678;Pooling=False; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioRolOficina>()
                .HasKey(c => new { c.TN_UsuarioId, c.TN_OficinaId, c.TN_RolId });
            modelBuilder.Entity<Usuario>().ToTable("TRA_Usuario", "USRS");
        }
    }
}
