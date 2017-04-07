using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel.ServiceObject
{
    public class SO_Usuario_Aplicacion
    {
        public IList LoginUsuarioAplicacion(string correo, string pass)
        {
            
            try
            {
                using (var conexion = new BDEntities())
                {
                    var usu = (from c in conexion.CAT_USUARIO_APLICACION
                           where c.CORREO == correo && c.CONTRASENA == pass
                           select c).ToList();
                    return usu;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Método para insetar un usuario de aplicación.
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="pass"></param>
        /// <param name="usuario"></param>
        /// <param name="nombre"></param>
        /// <param name="aPaterno"></param>
        /// <param name="aMaterno"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="movil"></param>
        /// <returns></returns>
        public int SetUsuarioAplicacion(string correo, string pass,string usuario,string nombre,string aPaterno,string aMaterno,DateTime fechaNacimiento,string movil)
        {
            CAT_USUARIO_APLICACION objUsuario = new CAT_USUARIO_APLICACION();
            try
            {
                using (var conexion = new BDEntities())
                {
                    objUsuario.CORREO = correo;
                    objUsuario.CONTRASENA = pass;
                    objUsuario.USUARIO = usuario;
                    objUsuario.NOMBRE = nombre;
                    objUsuario.APELLIDO_PATERNO = aPaterno;
                    objUsuario.APELLIDO_MATERNO = aMaterno;
                    objUsuario.FECHA_NACIMIENTO = fechaNacimiento;
                    objUsuario.MOVIL = movil;
                    objUsuario.IS_ACTIVO = false;
                    objUsuario.CODIGO_ACTIVACION = "CODIGO";
                    objUsuario.FECHA_INGRESO = DateTime.Now;
                    conexion.CAT_USUARIO_APLICACION.Add(objUsuario);
                    conexion.SaveChanges();
                    return objUsuario.ID_USUARIO_APLICACION;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Método que se utiliza para verificar si el correo existe.
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public bool ExistsCorreo(string correo)
        {
            try
            {
                //Realizamos la conexión a través de Entity Framework.
                using (var Conexion = new BDEntities())
                {
                    //Realizamos la consulta y el resultado lo asignamos a un objeto anónimo.
                    var obj = Conexion.CAT_USUARIO_APLICACION.Where(x => x.CORREO.Equals(correo)).FirstOrDefault();

                    //Comparamos si el resultado de la consulta es diferente de Nulo retornamos un true, de lo contrario retornamos un false.
                    return obj != null ? true : false;
                }
            }
            catch (Exception)
            {
                //Retornamos un false.
                return false;
            }
        }

        /// <summary>
        /// Método que se utiliza para verificar si el usuario existe.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ExistsUsuario(string usuario)
        {
            try
            {
                //Realizamos la conexión a través de Entity Framework.
                using (var Conexion = new BDEntities())
                {
                    //Realizamos la consulta y el resultado lo asignamos a un objeto anónimo.
                    var obj = Conexion.CAT_USUARIO_APLICACION.Where(x => x.USUARIO.Equals(usuario)).FirstOrDefault();

                    //Comparamos si el resultado de la consulta es diferente de Nulo retornamos un true, de lo contrario retornamos un false.
                    return obj != null ? true : false;
                }
            }
            catch (Exception)
            {
                //Retornamos un false.
                return false;
            }
        }

        public object ChecarCodigo(int idUsuario, string codigo)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    var obj = Conexion.CAT_USUARIO_APLICACION.Where(x => x.ID_USUARIO_APLICACION.Equals(idUsuario) && x.CODIGO_ACTIVACION.Equals(codigo)).FirstOrDefault();

                    return obj != null ? true : false;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ActivarCuenta(int idCodigo)
        {
            try
            {
                using (var Conexion = new BDEntities())
                {
                    CAT_USUARIO_APLICACION obj = Conexion.CAT_USUARIO_APLICACION.Where(x => x.ID_USUARIO_APLICACION.Equals(idCodigo)).FirstOrDefault();

                    obj.IS_ACTIVO = true;
                    
                    Conexion.Entry(obj).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
