using System.Collections.Generic;
using System.Web.Http;
using WebApiREST.Models;
namespace WebApiREST.Controllers
{
    public class NegocioController : ApiController
    {
        /// <summary>
        /// Método que se utiliza para las busquedas de los negocios a partir de una categoria
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        [System.Web.Http.AcceptVerbs("GET","POST")]
        [Route("api/Negocio/GetTaxi/{latitud:double}/{longitud:double}/{palabra}")]
        public IHttpActionResult GetNegocio(double latitud, double longitud,string palabra)
        {
            return Ok(DataManager.GetNegociosRelacionados(palabra, latitud, longitud));
        }

        /// <summary>
        /// Método que se utiliza para obtener todos los negocios que estan cercas de una ubicación.
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [AcceptVerbs("POST","GET")]
        [Route("api/Negocio/{latitud:double}/{longitud:double}/{optional}")]
        public IHttpActionResult GetNegocios(double latitud, double longitud,string optional)
        {
            return Ok(DataManager.GetAllNegociosCercas(latitud, longitud));
        }

        /// <summary>
        /// Método que se utiliza para insertar un registro de negocio.
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="horarios"></param>
        /// <returns></returns>
        [System.Web.Http.AcceptVerbs("GET")]
        [Route("api/Negocio/{latitud:double}/{longitud:double}/{nombre}/{descripcion}/{horarios}/{telefono}")]
        public IHttpActionResult SetNegocio(double latitud,double longitud, string nombre,string descripcion, string horarios,string telefono)
        {
            return Ok(DataManager.SetNegocio(latitud, longitud, nombre, descripcion, horarios,telefono));
        }

        /// <summary>
        /// Método que se utiliza para guardar una calificacion a un negocio.
        /// </summary>
        /// <param name="calificacion"></param>
        /// <param name="comentarios"></param>
        /// <param name="idNegocio"></param>
        /// <returns></returns>
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
        [AcceptVerbs("GET","POST")]
        [Route("api/Negocio/ActualizaPosicion/{latitud:double}/{longitud:double}/{idNegocio:int}")]
        public IHttpActionResult SetPositionNegocio(double latitud, double longitud, int idNegocio)
        {
            RequestPixie obj = new RequestPixie();
            obj = DataManager.SetPositionNegocio(latitud, longitud, idNegocio);
            List<RequestPixie> Lista = new List<RequestPixie>();
            Lista.Add(obj);
            return Ok(Lista);
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
            List<RequestPixie> lista = new List<RequestPixie>();

            lista.Add(DataManager.GetLogin(usuario, contrasena));

            return Ok(lista);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idNegocio"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("api/Negocio/VerificarPedidosAsignados/{idNegocio:int}")]
        public IHttpActionResult GetPermisosAsignados(int idNegocio)
        {
            return Ok(DataManager.GetPedidosAsignados(idNegocio));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idNegocio"></param>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("api/Negocio/AceptarPedido/{idNegocio:int}/{idPedido:int}")]
        public IHttpActionResult SetAceptarPedido(int idNegocio, int idPedido)
        {
            List<RequestPixie> lista = new List<RequestPixie>();
            lista.Add(DataManager.SetAceptarServicio(idNegocio, idPedido));
            return Ok(lista);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idNegocio"></param>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("api/Negocio/IniciarServicio/{idNegocio:int}/{idPedido:int}")]
        public IHttpActionResult SetIniciarServicio(int idNegocio, int idPedido)
        {
            List<RequestPixie> lista = new List<RequestPixie>();
            lista.Add(DataManager.SetIniciarServicio(idNegocio, idPedido));
            return Ok(lista);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="idNegocio"></param>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("api/Negocio/TerminarPedido/{latitud:double}/{longitud:double}/{idNegocio:int}/{idPedido:int}")]
        public IHttpActionResult SetTerminarPedido(double latitud, double longitud,int idNegocio, int idPedido)
        {
            List<RequestPixie> lista = new List<RequestPixie>();
            lista.Add(DataManager.SetTerminarPedido(idNegocio, idPedido, latitud, longitud));
            return Ok(lista);
        }
    }
}
