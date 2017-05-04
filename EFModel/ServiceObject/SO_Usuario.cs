using System;
using System.Collections;
using System.Linq;

namespace EFModel.ServiceObject
{
    public class SO_Usuario
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public IList Login(string usuario, string pass)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    var elUsuario = (from tblUsuario in Conexion.TBL_USUARIO
                                     where tblUsuario.USUARIO == usuario && tblUsuario.PASSWORD == pass
                                     select tblUsuario).ToList();
                    return elUsuario;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Método para obtener los negocios por usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public IList GetNegociosUsuario(string usuario)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    var Lista = (from a in Conexion.TBL_USUARIO
                                 join b in Conexion.TR_USUARIO_NEGOCIO on a.ID_USUARIO equals b.ID_USUARIO
                                 join c in Conexion.CAT_NEGOCIO on b.ID_NEGOCIO equals c.ID_NEGOCIO
                                 join r in Conexion.TBL_RELACIION on c.ID_NEGOCIO equals r.ID_NEGOCIO
                                 join s in Conexion.CAT_SUB_CATEGORIA on r.ID_SUB_CATEGORIA equals s.ID_SUB_CATEGORIA
                                 where a.USUARIO == usuario
                                 select new {
                                     c.ID_NEGOCIO,
                                     c.DESCRIPCION,
                                     c.NOMBRE,
                                     c.HORARIOS,
                                     c.LATITUD,
                                     c.LONGITUD,
                                     c.TELEFONO,
                                     s.ID_SUB_CATEGORIA,
                                     c.ESTATUS,
                                     c.IS_ACTIVO
                                 }).ToList();
                    return Lista;
                }
            }
            catch (Exception)
            {
                //Resgistrar el error
                return null;
            }
        }

        /// <summary>
        /// Método que obtiene el usuario que corresponde a un negocio.
        /// </summary>
        /// <param name="idNegocio"></param>
        /// <returns></returns>
        public IList GetUsuarioNegocio(int idNegocio)
        {
            try
            {
                //Inicializamos la conexión a la base de datos a través de EntityFramework.
                using (var Conexion = new BDEntities())
                {
                    //Realizamos la consulta. El resultado lo guardamos en una variable anónima.
                    var Lista = (from a in Conexion.CAT_NEGOCIO
                                 join r in Conexion.TR_USUARIO_NEGOCIO on a.ID_NEGOCIO equals r.ID_NEGOCIO
                                 join u in Conexion.TBL_USUARIO on r.ID_USUARIO equals u.ID_USUARIO
                                 where a.ID_NEGOCIO == idNegocio
                                 select u).ToList();

                    //Retornamos el resultado de la consulta.
                    return Lista;
                }
            }
            catch (Exception)
            {
                //Si ocurre algún error, retornamos un nulo.
                return null;
            }
        }
    }
}
