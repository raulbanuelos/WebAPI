using System.Web.Http;

namespace WebApiREST.Controllers
{
    public class UsuarioController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public IHttpActionResult Login(string usuario, string pass)
        {
            return Ok();
        }
    }
}
