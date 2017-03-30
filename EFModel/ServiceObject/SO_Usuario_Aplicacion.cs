using System;
using System.Collections;
using System.Collections.Generic;
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
                           where c.CORREO == correo && c.CONTRASENA == pass && c.IS_ACTIVO == true
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
                    objUsuario.NOMBRE = nombre;
                    objUsuario.APELLIDO_PATERNO = aPaterno;
                    objUsuario.APELLIDO_MATERNO = aMaterno;
                    objUsuario.FECHA_NACIMIENTO = fechaNacimiento;
                    objUsuario.MOVIL = movil;
                    objUsuario.IS_ACTIVO = false;
                    objUsuario.CODIGO_ACTIVACION = "CODIGO";
                    objUsuario.FECHA_INGRESO = DateTime.Now;
                    conexion.CAT_USUARIO_APLICACION.Add(objUsuario);
                    int r = conexion.SaveChanges();
                    return r;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
