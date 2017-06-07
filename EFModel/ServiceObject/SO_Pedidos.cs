using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EFModel.ServiceObject
{
    public class SO_Pedidos
    {
        public SO_Pedidos()
        {

        }

        /// <summary>
        /// Método para generar un pedido.
        /// </summary>
        /// <param name="latitud">Latitud del usuario</param>
        /// <param name="longitud">Longitud del usuario</param>
        /// <param name="idUsuarioAplicacion">Id de la persona que pide el servicio</param>
        /// <returns>Entero que representa el id del servicio generado.</returns>
        public int SetPedido(double latitud, double longitud, int idUsuarioAplicacion, double latitudDestino, double longitudDestino)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    PEDIDOS pedido = new PEDIDOS();
                    pedido.ESTATUS = 6;
                    pedido.FECHA_PEDIDO = DateTime.Now;
                    pedido.LATITUD_INICIAL = latitud;
                    pedido.LONGITUD_INICIAL = longitud;
                    pedido.ID_USUARIO_APLICACION = idUsuarioAplicacion;
                    pedido.LATITUD_DESTINO = latitudDestino;
                    pedido.LONGITUD_DESTINO = longitudDestino;
                    Conexion.PEDIDOS.Add(pedido);
                    Conexion.SaveChanges();
                    return pedido.ID_PEDIDO;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Método para verificar el estatus del pedido.
        /// </summary>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        public int GetEstatusPedido(int idPedido)
        {
           
                try
                {
                    using (var Conexion = new BDEntities())
                    {
                        int estatus = (from a in Conexion.PEDIDOS
                                       where a.ID_PEDIDO == idPedido
                                       select a.ESTATUS).FirstOrDefault();
                        return estatus;
                    }

                }
                catch (Exception)
                {
                    return 0;
                }
            
            
        }

        /// <summary>
        /// Método en el cual se asigna un taxista a un pedido. Aun no se da como aceptado.
        /// </summary>
        /// <param name="idNegocio"></param>
        /// <param name="idPedido"></param>
        public void SetOperadorServicio(int idNegocio, int idPedido)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    PEDIDOS pedido = Conexion.PEDIDOS.Where(x => x.ID_PEDIDO == idPedido).FirstOrDefault();

                    pedido.ID_NEGOCIO_ASIGNADO = idNegocio;

                    //Asignamos el estatus #6 que representa el estatus "SIN ASIGNAR"
                    pedido.ESTATUS = 6;

                    Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Método que verifica si un negocio a recibido un pedido.
        /// </summary>
        /// <param name="idNegocio"></param>
        /// <returns></returns>
        public int GetPedidoAsignadoPorNegocio(int idNegocio)
        {
            try
            {
                //Establecemos la conexión a través de EntityFramework.
                using (var Conexion = new BDEntities())
                {
                    //Realizamos la consulta y el resultado lo guardamos en una variable local.
                    int resultado = (from p in Conexion.PEDIDOS
                                     where p.ID_NEGOCIO_ASIGNADO == idNegocio && p.ESTATUS == 6
                                     select p.ID_PEDIDO).FirstOrDefault();

                    //Retornamos el resultado de la consulta.
                    return resultado;
                }
            }
            catch (Exception)
            {
                //Si ocurre algún error, retornamos un cero.
                return 0;
            }
        }

        /// <summary>
        /// Método que cambia el estatus de un pedido.
        /// </summary>
        /// <param name="idNegocio"></param>
        /// <param name="idPedido"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        public int SetCambiarEstatusPedido(int idNegocio, int idPedido,int estatus)
        {
            try
            {
                //Inicializamos la conexión a través de EntityFramework.
                using (var Conexion = new BDEntities())
                {
                    //Realizamos la consulta obteniendo el registro del pedidos.
                    PEDIDOS pedido = Conexion.PEDIDOS.Where(x => x.ID_PEDIDO == idPedido && x.ID_NEGOCIO_ASIGNADO == idNegocio).FirstOrDefault();
                    
                    //Cambiamos el estatus del registro por el recibido en el parámetro.
                    pedido.ESTATUS = estatus;

                    //Ejecutamos el método para guardar los cambios, el resultado no indica el número de registros afectados.
                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                //Si ocurre algún error, retornamos un cero.
                return 0;
            }
        }

        /// <summary>
        /// Método que actualiza la fecha final de un pedido.
        /// </summary>
        /// <param name="idNegocio"></param>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        public int SetFechaFinalPedido(int idNegocio, int idPedido,double latitudDestino, double longitudDestino)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    PEDIDOS pedido = Conexion.PEDIDOS.Where(x => x.ID_PEDIDO == idPedido && x.ID_NEGOCIO_ASIGNADO == idNegocio).FirstOrDefault();

                    pedido.FECHA_FINAL = DateTime.Now;
                    pedido.LATITUD_DESTINO = latitudDestino;
                    pedido.LONGITUD_DESTINO = longitudDestino;

                    Conexion.Entry(pedido).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Método que actualiza la fecha inicial del pedido.
        /// </summary>
        /// <param name="idNegocio"></param>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        public int SetFechaInicialPedido(int idNegocio, int idPedido)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    PEDIDOS pedido = Conexion.PEDIDOS.Where(x => x.ID_PEDIDO == idPedido && x.ID_NEGOCIO_ASIGNADO == idNegocio).FirstOrDefault();

                    pedido.FECHA_INICIAL = DateTime.Now;

                    Conexion.Entry(pedido).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Método que retorna la información de un pedido
        /// </summary>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        public IList GetPedido(int idPedido)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    var Lista = (from a in Conexion.PEDIDOS
                                 join b in Conexion.CAT_USUARIO_APLICACION on a.ID_USUARIO_APLICACION equals b.ID_USUARIO_APLICACION
                                 where a.ID_PEDIDO == idPedido
                                 select new {
                                     ID_PEDIDO = a.ID_PEDIDO,
                                     ID_USUARIO_APLICACION = b.ID_USUARIO_APLICACION,
                                     LATITUD_DESTINO = a.LATITUD_DESTINO,
                                     LATITUD_INICIAL = a.LATITUD_INICIAL,
                                     LONGITUD_DESTINO = a.LONGITUD_DESTINO,
                                     LONGITUD_INICIAL = a.LONGITUD_INICIAL,
                                     NOMBRE_USUARIO = b.NOMBRE + " " + b.APELLIDO_PATERNO + " " + b.APELLIDO_MATERNO
                                 }).ToList();
                    return Lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
