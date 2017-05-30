namespace WebApiREST.Models
{
    public class UsuarioAplicacion
    {
        public int idUsuarioAplicacion { get; set; }


        public string Correo { get; set; }


        public string Contrasena { get; set; }


        public bool IsActivo { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }
    }
}