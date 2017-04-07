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

        #region Métodos

        /// <summary>
        /// Método que 
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <param name="isActivo"></param>
        /// <returns></returns>
        public IList GetAllNegociosByCategoria(int idCategoria,bool isActivo,int estatus)
        {
            try
            {
                //Realizamos la conexión a través de Entity Framework.
                using (var Conexion = new BDEntities())
                {
                    //Realizamos la consulta.
                    var listaNegocios = (from negocio in Conexion.CAT_NEGOCIO
                                         join relacion in Conexion.TBL_RELACIION on negocio.ID_NEGOCIO equals relacion.ID_NEGOCIO
                                         join subcategoria in Conexion.CAT_SUB_CATEGORIA on relacion.ID_SUB_CATEGORIA equals subcategoria.ID_SUB_CATEGORIA
                                         where negocio.IS_ACTIVO == isActivo && subcategoria.ID_SUB_CATEGORIA == idCategoria && negocio.ESTATUS == estatus
                                         select new
                                         {
                                             negocio.LATITUD,
                                             negocio.LONGITUD,
                                             negocio.ID_NEGOCIO,
                                             negocio.DESCRIPCION,
                                             negocio.NOMBRE,
                                             negocio.HORARIOS,
                                             negocio.TELEFONO,
                                             relacion.ID_SUB_CATEGORIA,
                                             negocio.ESTATUS,
                                         }).ToList();
                    return listaNegocios;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Método que se utiliza para obtener todos los negocios.
        /// </summary>
        /// <returns>Lista anónima con la información de los negocios.Retorna un nulo si se generó algun error.</returns>
        public IList GetAllNegocios()
        {
            try
            {
                //Realizamos la conexión a través de Entity Framework.
                using (var Conexion = new BDEntities())
                {

                    //Realizamos la consulta.
                    var listaNegocios = (from negocio in Conexion.CAT_NEGOCIO
                                         join relacion in Conexion.TBL_RELACIION on negocio.ID_NEGOCIO equals relacion.ID_NEGOCIO
                                         join subcategoria in Conexion.CAT_SUB_CATEGORIA on relacion.ID_SUB_CATEGORIA equals subcategoria.ID_SUB_CATEGORIA
                                         where negocio.IS_ACTIVO == true
                                         select new
                                         {
                                             negocio.LATITUD,
                                             negocio.LONGITUD,
                                             negocio.ID_NEGOCIO,
                                             negocio.DESCRIPCION,
                                             negocio.NOMBRE,
                                             negocio.HORARIOS,
                                             negocio.TELEFONO,
                                             relacion.ID_SUB_CATEGORIA,
                                         }).ToList();

                    //Retornamos el resultado de la consulta.
                    return listaNegocios;
                }
            }
            catch (Exception)
            {
                //Si se generó algún error retornamos un nulo.
                return null;
            }
        }

        /// <summary>
        /// Método que agrega un objeto de tipo Negocio a la tabla de negocios.
        /// </summary>
        /// <param name="objNegocio">Objeto que representa el negocio que se requiere insertar.</param>
        /// <returns>Retorna el número de registros insertados. Si se generó algún errror retorna un 0</returns>
        public int SetNegocios(CAT_NEGOCIO objNegocio)
        {
            try
            {
                //Realizamos la conexión a través de Entity Framework.
                using (var Conexion = new BDEntities())
                {
                    //Agregamos el objeto recibido a la tabla.
                    Conexion.CAT_NEGOCIO.Add(objNegocio);

                    //Ejecutamos el método para guardar los cambios, el resultado nos indica cuantos registros se afectaron.
                    int r = Conexion.SaveChanges();

                    return r;
                }
            }
            catch (Exception)
            {
                //Si se generó algún error retornamos una 0
                return 0;
            }
        }

        /// <summary>
        /// Método que obtiene todos los negocios relacionados a parte de una categoria.
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns>Lista anónima con la información de los negocios. Si se generó algún error retorna un nulo.</returns>
        public IList GetNegociosRelacionados(string palabra)
        {
            try
            {
                //Realizamos la conexión a través de Entity Framework.
                using (var Conexion = new BDEntities())
                {
                    //Realizamos la consulta.
                    var listaNegocios = (from negocio in Conexion.CAT_NEGOCIO
                                         join relacion in Conexion.TBL_RELACIION on negocio.ID_NEGOCIO equals relacion.ID_NEGOCIO
                                         join subcategoria in Conexion.CAT_SUB_CATEGORIA on relacion.ID_SUB_CATEGORIA equals subcategoria.ID_SUB_CATEGORIA
                                         where subcategoria.NOMBRE.Contains(palabra) && negocio.IS_ACTIVO == true
                                         select new
                                         {
                                             negocio.LATITUD,
                                             negocio.LONGITUD,
                                             negocio.ID_NEGOCIO,
                                             negocio.DESCRIPCION,
                                             negocio.NOMBRE,
                                             negocio.HORARIOS,
                                             negocio.TELEFONO,
                                             relacion.ID_SUB_CATEGORIA,
                                         }).ToList();

                    //Retornamos el resultado de la consulta.
                    return listaNegocios;
                }
            }
            catch (Exception)
            {
                //Si se generó algún error, retornamos un nulo.
                return null;
            }
        }

        /// <summary>
        /// Método que obtiene todos los negocios que estan ocupados.
        /// </summary>
        /// <returns></returns>
        public IList GetNegociosOcupados()
        {
            try
            {
                //Realizamos la conexión a través de Entity Framework.
                using (var Conexion = new BDEntities())
                {
                    //Realizamos la consulta.
                    var lista = (from a in Conexion.CAT_NEGOCIO
                                 join b in Conexion.TBL_RELACIION on a.ID_NEGOCIO equals b.ID_NEGOCIO
                                 where a.ESTATUS == 3 && a.IS_ACTIVO == true
                                 select new
                                 {
                                     a.ID_NEGOCIO,
                                     a.LATITUD,
                                     a.LONGITUD,
                                     a.DESCRIPCION,
                                     a.NOMBRE,
                                     a.HORARIOS,
                                     a.TELEFONO,
                                     b.ID_SUB_CATEGORIA
                                 }).ToList();

                    //Retornamos el resultado de la consulta.
                    return lista;
                }
            }
            catch (Exception)
            {
                //Si se generó algún error, retornamos un nulo.
                return null;
            }
        }

        /// <summary>
        /// Método que retorna la información de un pedido.
        /// </summary>
        /// <param name="idNegocio">Entero que representa el id del negocio </param>
        /// <returns></returns>
        public PEDIDOS GetNegocioPedido(int idNegocio)
        {
            try
            {
                //Realizamos la conexión a través de Entity Framework.
                using (var Conexion = new BDEntities())
                {

                    //Realizamos la consulta.
                    var lista = (from a in Conexion.PEDIDOS
                                 where a.ID_NEGOCIO_ASIGNADO == idNegocio && a.ESTATUS == 1
                                 select a).FirstOrDefault();

                    //Retornamos la lista obtenida.
                    return lista;
                }
            }
            catch (Exception)
            {
                //Si se generó algún error, retornamos un nulo.
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
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="idNegocio"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="calificacion"></param>
        /// <param name="idNegocio"></param>
        /// <param name="comentarios"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método que cambia el estatus de un negocio.
        /// </summary>
        /// <param name="idNegocio">Entero que representa el id del negocio.</param>
        /// <param name="estatus">Entero que representa el estatus: 1=Libre, 2=Asignado, 3=Ocupado, 4=No disponible</param>
        /// <returns></returns>
        public int SetCambiarEstatus(int idNegocio, int estatus)
        {
            try
            {
                //Realizamos la conexión a travéz de Entity Framework.
                using (var Conexion = new BDEntities())
                {
                    //Obtenemos el registro.
                    CAT_NEGOCIO obj = Conexion.CAT_NEGOCIO.Where(x => x.ID_NEGOCIO == idNegocio).FirstOrDefault();

                    //Cambiamos el valor al estatus deceado.
                    obj.ESTATUS = estatus;

                    //Ejecutamos el método y retornamos el valor.
                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

    }
}
