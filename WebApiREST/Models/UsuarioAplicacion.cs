using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiREST.Models
{
    public class UsuarioAplicacion
    {
        public int idUsuarioAplicacion { get; set; }

        public string Correo { get; set; }

        public string Contrasena { get; set; }

        public bool IsActivo { get; set; }
    }
}