using System.Web.Http;
using WebApiREST.Models;

namespace WebApiREST.Controllers
{
    public class NegocioEstatusController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idNegocio"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("api/NegocioEstatus/{idNegocio:int}/{estatus:int}/")]
        public IHttpActionResult CambiarEstatusNegocio(int idNegocio, int estatus)
        {
            //Estatus Negocio
            //1.-Libre
            //2.-Asignado
            //3.-Ocupado
            //4.-No Disponible
            return Ok(DataManager.CambiarEstatusNegocio(idNegocio,estatus));
        }
    }
}