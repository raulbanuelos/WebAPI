using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiREST.Controllers
{
    public class UsuarioController : ApiController
    {
        public IHttpActionResult Login(string usuario, string pass)
        {
            return Ok();
        }
    }
}
