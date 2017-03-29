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
        public IList GetAllSubCategorias()
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    var ListaSubCategorias = (from categorias in Conexion.CAT_SUB_CATEGORIA
                                              select new {
                                                  categorias.ID_SUB_CATEGORIA,
                                                  categorias.NOMBRE
                                              }).ToList();
                    return ListaSubCategorias;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
