﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiREST.Models;
using EFModel;
using EFModel.ServiceObject;
namespace WebApiREST.Controllers
{
    public class NegocioController : ApiController
    {
        

        /// <summary>
        /// Método que se utiliza para las busquedas de los negocios a partir de una categoria
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        [System.Web.Http.AcceptVerbs("POST")]
        [Route("api/Negocio/{latitud:double}/{longitud:double}/{palabra}/{optional}")]
        public IHttpActionResult GetNegocio(double latitud, double longitud,string palabra,string optional)
        {
            return Ok(DataManager.GetNegociosRelacionados(palabra, latitud, longitud));
        }

        /// <summary>
        /// Método que se utiliza para obtener todos los negocios que estan cercas de una ubicación.
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [AcceptVerbs("POST")]
        [Route("api/Negocio/{latitud:double}/{longitud:double}/{optional}")]
        public IHttpActionResult GetNegocios(double latitud, double longitud,string optional)
        {
            return Ok(DataManager.GetAllNegociosCercas(latitud, longitud));
        }

        /// <summary>
        /// Método que se utiliza para insertar un registro de negocio.
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="horarios"></param>
        /// <returns></returns>
        [System.Web.Http.AcceptVerbs("GET")]
        [Route("api/Negocio/{latitud:double}/{longitud:double}/{nombre}/{descripcion}/{horarios}")]
        public IHttpActionResult SetNegocio(double latitud,double longitud, string nombre,string descripcion, string horarios)
        {
            return Ok(DataManager.SetNegocio(latitud, longitud, nombre, descripcion, horarios));
        }

        /// <summary>
        /// Método que se utiliza para guardar una calificacion a un negocio.
        /// </summary>
        /// <param name="calificacion"></param>
        /// <param name="comentarios"></param>
        /// <param name="idNegocio"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("api/Negocio/{calificacion:double}/{comentarios}/{idNegocio:int}")]
        public IHttpActionResult SetCalificacion(double calificacion, string comentarios, int idNegocio)
        {
            return Ok(DataManager.SetCalificacion(calificacion, idNegocio, comentarios));
        }

        /// <summary>
        /// Método que actualiza la posición de lo negocios(especial para los negocios que cambian su posición como los taxis)
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="idNegocio"></param>
        /// <returns></returns>
        [Route("api/Negocio({latitud:double}/{longitud:double}/{idNegocio:int}")]
        public IHttpActionResult SetPositionNegocio(double latitud, double longitud, int idNegocio)
        {
            return Ok(DataManager.SetPositionNegocio(latitud, longitud, idNegocio));
        }

        /// <summary>
        /// Método que se utiliza para el login, Retorna úna lista con los negocios que tiene registrados.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <returns></returns>
        [AcceptVerbs("GET","POST")]
        [Route("api/Negocio/{usuario}/{contrasena}")]
        public IHttpActionResult LoginNegocio(string usuario, string contrasena)
        {
            return Ok(DataManager.GetLogin(usuario, contrasena));
        }
    
    }
}
