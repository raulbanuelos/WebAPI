using System;
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
        Negocio[] negocios = new Negocio[] {
            new Negocio { Latitud = 21.870794,Longitud=-102.301992,Descripcion="Oficinas Pixie Lab",idNegocio=1},
            new Negocio { Latitud = 21.871276,Longitud=-102.301816,Descripcion="La última luna",idNegocio=2},
        };

        public IEnumerable<Negocio> GetAllNegocios()
        {
            //return negocios;
            return DataManager.GetAllNegocio();
        }

        [Route("api/Negocio/{palabra}/{latitud:double}/{longitud:double}")]
        public IHttpActionResult GetNegocio(int idCategoria,double latitud,double longitud)
        {
            return Ok(DataManager.GetNegociosRelacionados(idCategoria, latitud,longitud));
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [Route("api/Negocio/{latitud:double}/{longitud:double}/{nombre}/{descripcion}/{horarios}")]
        public IHttpActionResult SetNegocio(double latitud,double longitud, string nombre,string descripcion, string horarios)
        {
            return Ok(DataManager.SetNegocio(latitud, longitud, nombre, descripcion, horarios));
        }

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
