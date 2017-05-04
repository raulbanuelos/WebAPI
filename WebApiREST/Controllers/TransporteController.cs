using System.Web.Http;
using WebApiREST.Models;

namespace WebApiREST.Controllers
{
    public class TransporteController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="optional"></param>
        /// <returns></returns>
        [System.Web.Http.AcceptVerbs("GET","POST")]
        [Route("api/Transporte/{latitud:double}/{longitud:double}/{optional}/")]
        public IHttpActionResult GetTransporteCercas(double latitud, double longitud, string optional)
        {
            return Ok(DataManager.GetAllNegociosTaxisCercas(latitud,longitud));
        }
    }
}