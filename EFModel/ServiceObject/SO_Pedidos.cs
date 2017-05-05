using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EFModel.ServiceObject
{
    public class SO_Pedidos
    {
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
        public Task<int> GetEstatusPedido(int idPedido)
        {
            return Task.Run(() => {
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
            });
            
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

        public int GetPedidoAsignadoPorNegocio(int idNegocio)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    var resultado = (from p in Conexion.PEDIDOS
                                     where p.ID_NEGOCIO_ASIGNADO == idNegocio && p.ESTATUS == 6
                                     select new
                                     {
                                         p.ID_PEDIDO
                                     }).FirstOrDefault();

                    return Convert.ToInt32(resultado);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int SetCambiarEstatusPedido(int idNegocio, int idPedido,int estatus)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    PEDIDOS pedido = Conexion.PEDIDOS.Where(x => x.ID_PEDIDO == idPedido && x.ID_NEGOCIO_ASIGNADO == idNegocio).FirstOrDefault();
                    
                    pedido.ESTATUS = estatus;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception er)
            {
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
    }
}
