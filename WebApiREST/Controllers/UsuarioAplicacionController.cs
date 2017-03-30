﻿
using System.Collections.Generic;
using System.Web.Http;
using WebApiREST.Models;

namespace WebApiREST.Controllers
{
    public class UsuarioAplicacionController : ApiController
    {
        /// <summary>
        /// Método para dar de alta a un usuario de aplicación.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [Route("api/UsuarioAplicacion")]
        public IHttpActionResult SetUsuarioAplicacion(string usuario, string pass)
        {
            return Ok(DataManager.SetUsuarioAplicacion(usuario, pass));
        }

        [Route("api/UsuarioAplicacion/{latitudInicial:double}/{longitudInicial:double}/{latitudDestino:double}/{longitudDestino:double}/{idUsuarioAplicacion:int}")]
        public IHttpActionResult GetTaxi(double latitudInicial,double longitudInicial,double latitudDestino,double longitudDestino, int idUsuarioAplicacion)
        {
            Negocio obj = DataManager.GetAuto(longitudInicial, latitudInicial,longitudDestino,latitudDestino, idUsuarioAplicacion);
            List<Negocio> lista = new List<Negocio>();
            lista.Add(obj);
            return Ok(lista);
        }

        [AcceptVerbs("GET", "POST")]
        [Route("api/UsuarioAplicacion/{correo}/{pass}")]
        public IHttpActionResult LoginUsuarioAplication(string correo, string pass)
        {
            return Ok(DataManager.LoginUsuarioAplicacion(correo, pass));
        }
    }
}