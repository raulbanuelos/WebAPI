using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel.ServiceObject
{
    public class SO_Usuario
    {
        public TBL_USUARIO Login(string usuario, string pass)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    var elUsuario = (from tblUsuario in Conexion.TBL_USUARIO
                                     where tblUsuario.USUARIO == usuario && tblUsuario.PASSWORD == pass
                                     select tblUsuario).ToList().FirstOrDefault();
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
                                     s.ID_SUB_CATEGORIA
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
    }
}
