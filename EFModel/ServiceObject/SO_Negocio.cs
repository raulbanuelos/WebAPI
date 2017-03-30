using EFModel.SQLServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel.ServiceObject
{
    public class SO_Negocio
    {
        /// <summary>
        /// Método que se utiliza para obtener todos los negocios.
        /// </summary>
        /// <returns></returns>
        public IList GetAllNegocios()
        {
            using (var Conexion = new BDEntities())
            {
                var listaNegocios = (from negocio in Conexion.CAT_NEGOCIO
                                     join relacion in Conexion.TBL_RELACIION on negocio.ID_NEGOCIO equals relacion.ID_NEGOCIO
                                     join subcategoria in Conexion.CAT_SUB_CATEGORIA on relacion.ID_SUB_CATEGORIA equals subcategoria.ID_SUB_CATEGORIA
                                     select new
                                     {
                                         negocio.LATITUD,
                                         negocio.LONGITUD,
                                         negocio.ID_NEGOCIO,
                                         negocio.DESCRIPCION,
                                         negocio.NOMBRE,
                                         negocio.HORARIOS,
                                         relacion.ID_SUB_CATEGORIA,
                                     }).ToList();
                return listaNegocios;
            }
        }



        public string SetNegocios(CAT_NEGOCIO objNegocio)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    Conexion.CAT_NEGOCIO.Add(objNegocio);
                    int r = Conexion.SaveChanges();

                    return r > 0 ? "S" : "N";
                    
                }
            }
            catch (Exception)
            {
                return "N";
            }
        }

        public IList GetNegociosRelacionados(int idCategoria)
        {
            try {
                using (var Conexion = new BDEntities())
                {
                    var listaNegocios = (from negocio in Conexion.CAT_NEGOCIO
                                         join relacion in Conexion.TBL_RELACIION on negocio.ID_NEGOCIO equals relacion.ID_NEGOCIO
                                         join subcategoria in Conexion.CAT_SUB_CATEGORIA on relacion.ID_SUB_CATEGORIA equals subcategoria.ID_SUB_CATEGORIA
                                         where subcategoria.ID_SUB_CATEGORIA == idCategoria
                                         select new {
                                             negocio.LATITUD,
                                             negocio.LONGITUD,
                                             negocio.ID_NEGOCIO,
                                             negocio.DESCRIPCION,
                                             negocio.NOMBRE,
                                             negocio.HORARIOS,
                                             relacion.ID_SUB_CATEGORIA,
                                         }).ToList();
                    return listaNegocios;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList GetNegociosOcupados()
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    var lista = (from a in Conexion.CAT_NEGOCIO
                                 join b in Conexion.TBL_RELACIION on a.ID_NEGOCIO equals b.ID_NEGOCIO
                                 where a.ESTATUS == 3
                                 select new {
                                     a.ID_NEGOCIO,
                                     a.LATITUD,
                                     a.LONGITUD,
                                     a.DESCRIPCION,
                                     a.NOMBRE,
                                     a.HORARIOS,
                                     b.ID_SUB_CATEGORIA
                                 }).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PEDIDOS GetNegocioPedido(int idNegocio)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    var lista = (from a in Conexion.PEDIDOS
                                 where a.ID_NEGOCIO_ASIGNADO == idNegocio && a.ESTATUS == 1
                                 select a).FirstOrDefault();
                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Método que obtiene los transportes que estan libres.
        /// </summary>
        /// <param name="idSubCategoria"></param>
        /// <returns></returns>
        public DataSet GetTransporteLibre()
        {
            try
            {
                DataSet ds = new DataSet();
                Pixie_SQL conexionSQL = new Pixie_SQL();
                Dictionary<string, object> Parametros = new Dictionary<string, object>();

                ds = conexionSQL.EjecutarStoredProcedure("SP_Negocio_GetTaxiLibre", Parametros);
                return ds;
            }
            catch (Exception) {
                return null;
            }
        }

        public string SetPositionNegocio(double latitud, double longitud, int idNegocio)
        {
            string r = string.Empty;
            CAT_NEGOCIO ObjNegocio = null;
            try
            {
                using (var Conexion = new BDEntities())
                {
                    ObjNegocio = Conexion.CAT_NEGOCIO.Where(p => p.ID_NEGOCIO == idNegocio).FirstOrDefault();
                }
                if (ObjNegocio != null)
                {
                    ObjNegocio.LATITUD = Convert.ToDouble(latitud);
                    ObjNegocio.LONGITUD = Convert.ToDouble(longitud);
                    using (var Conexion = new BDEntities())
                    {
                        Conexion.Entry(ObjNegocio).State = System.Data.Entity.EntityState.Modified;
                        Conexion.SaveChanges();
                        return "S";
                    }
                }
                else
                    return "N";
            }
            catch (Exception)
            {
                return "N";
            }
        }

        public string SetCalificacion(double calificacion, int idNegocio, string comentarios)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    TBL_CALIFICACION_NEGOCIO obj = new TBL_CALIFICACION_NEGOCIO();
                    obj.CALIFICACION = Convert.ToDouble(calificacion);
                    obj.ID_NEGOCIO = idNegocio;
                    obj.COMETARIOS = comentarios;
                    obj.FECHA = DateTime.Now;

                    Conexion.TBL_CALIFICACION_NEGOCIO.Add(obj);
                    Conexion.SaveChanges();
                    return "S";
                }
            }
            catch (Exception)
            {
                return "N";
            }
        }


    }
}
