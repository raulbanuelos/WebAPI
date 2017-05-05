using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        [AcceptVerbs("GET", "POST")]
        [Route("api/UsuarioAplicacion/{correo}/{pass}/{usuario}/{nombre}/{aPaterno}/{aMaterno}/{movil}/{fechaNacimiento}")]
        public IHttpActionResult SetUsuarioAplicacion(string correo, string pass,string usuario,string nombre,string aPaterno,string aMaterno, string movil,string fechaNacimiento)
        {
            return Ok(DataManager.SetUsuarioAplicacion(correo, pass,usuario,nombre,aPaterno,aMaterno,Convert.ToDateTime(fechaNacimiento),movil));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitudInicial"></param>
        /// <param name="longitudInicial"></param>
        /// <param name="latitudDestino"></param>
        /// <param name="longitudDestino"></param>
        /// <param name="idUsuarioAplicacion"></param>
        /// <returns></returns>
        [Route("api/UsuarioAplicacion/{latitudInicial:double}/{longitudInicial:double}/{latitudDestino:double}/{longitudDestino:double}/{idUsuarioAplicacion:int}")]
        public async Task<IHttpActionResult> GetTaxi(double latitudInicial, double longitudInicial, double latitudDestino, double longitudDestino, int idUsuarioAplicacion)
        {
            List<RequestPixie> Lista = new List<RequestPixie>();

            RequestPixie p = await DataManager.GetAuto(longitudInicial, latitudInicial, longitudDestino, latitudDestino, idUsuarioAplicacion);
            
            Lista.Add(p);

            return Ok(Lista);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("api/UsuarioAplicacion/{correo}/{pass}")]
        public IHttpActionResult LoginUsuarioAplication(string correo, string pass)
        {
            return Ok(DataManager.LoginUsuarioAplicacion(correo, pass));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("api/UsuarioAplicacion/VerificaCodigo/{idUsuario:int}/{codigo}")]
        public IHttpActionResult VerificaCodigo(int idUsuario, string codigo)
        {
            return Ok(DataManager.VerificarCodigo(idUsuario, codigo));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idNegocio"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("api/UsuarioAplicacion/GetUbicacionNegocio/{idNegocio:int}")]
        public IHttpActionResult GetUbicacionNegocio(int idNegocio)
        {
            List<RequestPixie> Lista = new List<RequestPixie>();

            Lista.Add((DataManager.GetUbicacionNegocio(idNegocio)));

            return Ok(Lista);
        }
    }
}