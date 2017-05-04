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
        public IList GetCalificacionNegocio(int idNegocio)
        {
            try
            {
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
