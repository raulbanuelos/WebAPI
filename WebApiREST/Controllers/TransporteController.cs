using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiREST.Models;

namespace WebApiREST.Controllers
{
    public class TransporteController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET","POST")]
        [Route("api/Transporte/{latitud:double}/{longitud:double}/{optional}/")]
        public IHttpActionResult GetTransporteCercas(double latitud, double longitud, string optional)
        {
            return Ok(DataManager.GetAllNegociosTaxisCercas(latitud,longitud));
        }
    }
}