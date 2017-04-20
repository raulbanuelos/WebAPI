using System.Web.Http;
using WebApiREST.Models;

namespace WebApiREST.Controllers
{
    public class PedidoController : ApiController
    {
        [AcceptVerbs("GET", "POST")]
        [Route("api/Pedido/{idPedido:int}/{idNegocio:int}/{estatus:int}")]
        public IHttpActionResult CambiarEstatusPedido(int idPedido, int idNegocio,int estatus)
        {
            //Estatus Pedido
            //1.-En Curso
            //2.-Cancelado
            //3.-Terminado
            //6.-Sin Asignar
            //5.-Asignado(Ya acepto el taxista)
            return Ok(DataManager.CambiarEstatusPedido(idPedido,idNegocio,estatus));
        }

        [AcceptVerbs("GET", "POST")]
        [Route("api/Pedido/ObtenerPedidosUsuario/{idUsuarioAplicacion:int}")]
        public IHttpActionResult ObtenerSolicitutesPorUsuario(int idUsuario)
        {
            return Ok(DataManager.GetPedidosUsuario(idUsuario));
        }
    }
}