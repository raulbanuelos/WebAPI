using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel.ServiceObject
{
    public class SO_Categoria
    {
        /// <summary>
        /// Método el cual obtiene todas las sub categorias.
        /// </summary>
        /// <returns>Lista anónima con la información de las sub categorias. Retorna un nulo si hubo algún error.</returns>
        public IList GetAllSubCategorias()
        {
            try
            {
                //Realizamos la conexión a través de Entity Framewokr.
                using (var Conexion = new BDEntities())
                {

                    //Realizamos la consulta.
                    var ListaSubCategorias = (from categorias in Conexion.CAT_SUB_CATEGORIA
                                              select new {
                                                  categorias.ID_SUB_CATEGORIA,
                                                  categorias.NOMBRE
                                              }).ToList();

                    //Retornamos el resultado de la consulta.
                    return ListaSubCategorias;
                }
            }
            catch (Exception)
            {
                //Si se generó algún error, retornamos un nulo.
                return null;
            }
        }
    }
}
