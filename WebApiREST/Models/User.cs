using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiREST.Models
{
    public class User
    {
        
        public int ID_USUARIO { get; set; }

       
        public string USUARIO { get; set; }

        
        public string PASSWORD { get; set; }

        
        public string NOMBRE { get; set; }

       
        public string APELLIDO_PATERNO { get; set; }

        
        public string APELLIDO_MATERNO { get; set; }

        
        public DateTime FECHA_NACIMIENTO { get; set; }

        public int IdNegocio { get; set; }


        public Negocio Negocio { get; set; }

    }
}