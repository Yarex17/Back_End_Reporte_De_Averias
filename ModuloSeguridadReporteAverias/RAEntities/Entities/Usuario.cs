using System.ComponentModel.DataAnnotations;

namespace RAEntities.Entities
{
    public class Usuario
    {
        [Key]
        public int TN_IdUsuario { get; set; }
        public int TnOficina { get; set; }
        public string TC_Rol { get; set; }
        public string TC_Nombre { get; set; }
        public string TC_Apellido { get; set; }
        public string TC_Cedula { get; set; }
        public string TC_Correo { get; set; }
        public string TC_Contrasennia { get; set; }
        public bool? TB_Activo { get; set; }
        public bool TB_Eliminado { get; set; }

    }

    public class Login
    {
        [Key]
        public int? ID { get; set; }

        public string? Usuario { get; set; }

        public string? rol { get; set; }
    }

    public class UsuarioRolOficina
    {
        public int? TN_UsuarioId { get; set; }
        public int? TN_OficinaId { get; set; }
        public int? TN_RolId { get; set; }

    }
}