using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    pedido.ESTATUS = 1;
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

        public int SetCambiarEstatusPedido(int idNegocio, int idPedido,int estatus)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    PEDIDOS pedido = Conexion.PEDIDOS.Where(x => x.ID_PEDIDO == idPedido && x.ID_NEGOCIO_ASIGNADO == idNegocio).FirstOrDefault();

                    //Asignamos el estatus #5 que representa el estatus aceptado
                    pedido.ESTATUS = estatus;

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
