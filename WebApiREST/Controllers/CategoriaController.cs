using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiREST.Models;

namespace WebApiREST.Controllers
{
    public class CategoriaController : ApiController
    {
        [Route("api/Categoria/")]
        public IHttpActionResult GetSubCategoria()
        {
            return Ok(DataManager.GetAllSubCategorias());
        }
    }
}
