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
