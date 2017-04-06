using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiREST.Models
{
    public class Negocio
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public string Horario { get; set; }
        public int idNegocio { get; set; }
        public int idCategoria { get; set; }
        public string Telefono { get; set; }

        /// <summary>
        /// Double que representa la distancia entre el negocio y el usuario.
        /// </summary>
        public double Distancia { get; set; }

        /// <summary>
        /// Entero que representa el estatus del negocio
        /// 1.-Libre
        /// 2.-Asignado
        /// 3.-Ocupado
        /// 4.-No Disponible
        /// </summary>
        public int Estatus { get; set; }
    }
}