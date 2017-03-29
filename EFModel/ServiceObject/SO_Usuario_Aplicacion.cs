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

        public int SetUsuarioAplicacion(string correo, string pass)
        {
            CAT_USUARIO_APLICACION usuario = new CAT_USUARIO_APLICACION();
            try
            {
                using (var conexion = new BDEntities())
                {
                    usuario.CORREO = correo;
                    usuario.CONTRASENA = pass;
                    usuario.FECHA_INGRESO = DateTime.Now;
                    conexion.CAT_USUARIO_APLICACION.Add(usuario);
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
