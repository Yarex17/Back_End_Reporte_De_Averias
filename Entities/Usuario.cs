namespace Entities
{
    public class Usuario
    {
        public int TN_IdUsuario { get; set; }
        public int TN_Oficina { get; set; }
        public string TC_Rol { get; set; }
        public string TC_Nombre { get; set; }
        public string  TC_Apellido { get; set; }
        public string TC_Cedula { get; set; }
        public string TC_Correo { get; set; }
        public string? TC_Contrasennia { get; set; }
        public bool TB_Activo { get; set; }
        public bool TB_Eliminado { get; set; }
    }

    public class UsuarioDatos
    {
        public int TN_IdUsuario { get; set; }
        public int TN_Oficina { get; set; }
        public string TC_Rol { get; set; }
        public string TC_Nombre { get; set; }
        public string TC_Apellido { get; set; }
        public string TC_Cedula { get; set; }
        public string TC_Correo { get; set; }
        public string? TC_Contrasennia { get; set; }
        public bool TB_Activo { get; set; }
        public bool TB_Eliminado { get; set; }
    }
}