using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel.ServiceObject
{
    public class SO_Calificacion
    {
        /// <summary>
        /// Método que devuelve la lista de calificaciones de un negocio.
        /// </summary>
        /// <param name="idNegocio"></param>
        /// <returns></returns>
        public IList GetCalificacionNegocio(int idNegocio)
        {
            try
            {
                //Establecemos la conexión a la base de datos
                using (var Conexion = new BDEntities())
                {
                    var Lista = (from a in Conexion.TBL_CALIFICACION_NEGOCIO
                                 where a.ID_NEGOCIO == idNegocio
                                 select new {
                                     a.CALIFICACION
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
