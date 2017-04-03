using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFModel.ServiceObject;
using EFModel;
using System.Collections;
using System.Data;

namespace WebApiREST.Models
{
    enum EstatusServicio
    {

    }
    public static class DataManager
    {

        /// <summary>
        /// Método que inserta un negocio en la tabla.
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="horarios"></param>
        /// <returns></returns>
        public static List<string> SetNegocio(double latitud, double longitud, string nombre, string descripcion, string horarios, string telefono)
        {
            CAT_NEGOCIO obj = new CAT_NEGOCIO();
            obj.LATITUD = latitud;
            obj.LONGITUD = longitud;
            obj.NOMBRE = nombre;
            obj.DESCRIPCION = descripcion;
            obj.HORARIOS = horarios;
            obj.FECHA_CREACION = DateTime.Now;
            obj.ID_USUARIO_CREACION = 1;
            obj.TELEFONO = telefono;
            obj.FECHA_ACTUALIZACION = DateTime.Now;
            obj.ID_USUARIO_ACTUALIZACION = 1;
            obj.CODIGO_ACTIVACION = "CODIGO";
            obj.IS_ACTIVO = false;
            obj.ESTATUS = 1;
            SO_Negocio SONegocio = new SO_Negocio();

            int r = SONegocio.SetNegocios(obj);

            List<string> lista = new List<string>();

            if (r > 0)
            {
                lista.Add("Tu negocio a sido registrado, pronto nos comunicaremos al número telefónico que registraste para activar tu cuenta.");
            }
            else
            {
                lista.Add("Upps! Hubo algún problema al registrar tu negocio.");
            }

            return lista;
        }

        /// <summary>
        /// Método que se utiliza para obtener todos los negocios cercas de una ubicación.
        /// </summary>
        /// <param name="latitud_actual"></param>
        /// <param name="longitud_actual"></param>
        /// <returns></returns>
        public static List<Negocio> GetAllNegociosCercas(double latitud_actual, double longitud_actual)
        {
            SO_Negocio ServicioNegocio = new SO_Negocio();
            IList informacionBD = ServicioNegocio.GetAllNegocios();
            List<Negocio> ListaResultante = new List<Negocio>();

            if (informacionBD != null)
            {
                foreach (var negocio in informacionBD)
                {
                    System.Type tipo = negocio.GetType();

                    double latitud = Convert.ToDouble(tipo.GetProperty("LATITUD").GetValue(negocio, null));
                    double longitud = Convert.ToDouble(tipo.GetProperty("LONGITUD").GetValue(negocio, null));
                    double distancia = MedirDistancia(latitud_actual, latitud, longitud_actual, longitud);
                    if (distancia <= 2) //distancia <= 1.5
                    {
                        Negocio obj = new Negocio();
                        obj.Latitud = Convert.ToDouble(tipo.GetProperty("LATITUD").GetValue(negocio, null));
                        obj.Longitud = longitud;
                        obj.idNegocio = Convert.ToInt32(tipo.GetProperty("ID_NEGOCIO").GetValue(negocio, null));
                        obj.Descripcion = Convert.ToString(tipo.GetProperty("DESCRIPCION").GetValue(negocio, null));
                        obj.Titulo = Convert.ToString(tipo.GetProperty("NOMBRE").GetValue(negocio, null));
                        obj.Horario = Convert.ToString(tipo.GetProperty("HORARIOS").GetValue(negocio, null));
                        obj.idCategoria = Convert.ToInt32(tipo.GetProperty("ID_SUB_CATEGORIA").GetValue(negocio, null));
                        obj.Telefono = Convert.ToString(tipo.GetProperty("TELEFONO").GetValue(negocio, null));
                        ListaResultante.Add(obj);
                    }
                }
            }

            return ListaResultante;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="calificacion"></param>
        /// <param name="idNegocio"></param>
        /// <param name="Comentarios"></param>
        /// <returns></returns>
        public static List<string> SetCalificacion(double calificacion, int idNegocio, string Comentarios)
        {
            SO_Negocio ServicioNegocio = new SO_Negocio();

            string s = ServicioNegocio.SetCalificacion(calificacion, idNegocio, Comentarios);

            List<string> lista = new List<string>();

            if (s == "S")
            {
                lista.Add("S");
            }
            else {
                lista.Add("N");
            }

            return lista;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<FO_ItemCombo> GetAllSubCategorias()
        {
            List<FO_ItemCombo> ListaResultante = new List<FO_ItemCombo>();

            SO_Categoria ServiceCategoria = new SO_Categoria();

            IList InformacionBD = ServiceCategoria.GetAllSubCategorias();

            if (InformacionBD != null)
            {
                foreach (var categoria in InformacionBD)
                {
                    System.Type tipo = categoria.GetType();

                    FO_ItemCombo obj = new FO_ItemCombo();
                    obj.Descripcion = Convert.ToString(tipo.GetProperty("NOMBRE").GetValue(categoria, null));
                    obj.Valor = Convert.ToInt32(tipo.GetProperty("ID_SUB_CATEGORIA").GetValue(categoria, null));

                    ListaResultante.Add(obj);
                }
            }
            return ListaResultante;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="palabra"></param>
        /// <param name="latitud_actual"></param>
        /// <param name="longitud_actual"></param>
        /// <returns></returns>
        public static List<Negocio> GetNegociosRelacionados(string palabra, double latitud_actual, double longitud_actual)
        {
            SO_Negocio SONegocio = new SO_Negocio();
            IList listaResultante = SONegocio.GetNegociosRelacionados(palabra);
            List<Negocio> listan = new List<Negocio>();

            if (listaResultante != null)
            {
                foreach (var negocio in listaResultante)
                {
                    System.Type tipo = negocio.GetType();

                    double latitud = Convert.ToDouble(tipo.GetProperty("LATITUD").GetValue(negocio, null));
                    double longitud = Convert.ToDouble(tipo.GetProperty("LONGITUD").GetValue(negocio, null));
                    double distancia = MedirDistancia(latitud_actual, latitud, longitud_actual, longitud);
                    if (distancia <= 1.5) //distancia <= 1.5
                    {
                        Negocio obj = new Negocio();
                        obj.Latitud = Convert.ToDouble(tipo.GetProperty("LATITUD").GetValue(negocio, null));
                        obj.Longitud = longitud;
                        obj.idNegocio = Convert.ToInt32(tipo.GetProperty("ID_NEGOCIO").GetValue(negocio, null));
                        obj.Descripcion = Convert.ToString(tipo.GetProperty("DESCRIPCION").GetValue(negocio, null));
                        obj.Titulo = Convert.ToString(tipo.GetProperty("NOMBRE").GetValue(negocio, null));
                        obj.Horario = Convert.ToString(tipo.GetProperty("HORARIOS").GetValue(negocio, null));
                        obj.idCategoria = Convert.ToInt32(tipo.GetProperty("ID_SUB_CATEGORIA").GetValue(negocio, null));
                        obj.Telefono = Convert.ToString(tipo.GetProperty("TELEFONO").GetValue(negocio, null));
                        listan.Add(obj);
                    }
                }
            }

            return listan;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="idNegocio"></param>
        /// <returns></returns>
        public static List<string> SetPositionNegocio(double latitud, double longitud, int idNegocio)
        {
            SO_Negocio ServiceNegocio = new SO_Negocio();

            string r = ServiceNegocio.SetPositionNegocio(latitud, longitud, idNegocio);

            List<string> lista = new List<string>();
            lista.Add(r);

            return lista;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LATITUD_1"></param>
        /// <param name="LATITUD_2"></param>
        /// <param name="LONGITUD_1"></param>
        /// <param name="LONGITUD_2"></param>
        /// <returns></returns>
        private static double MedirDistancia(double LATITUD_1, double LATITUD_2, double LONGITUD_1, double LONGITUD_2)
        {
            double distancia = 0;
            distancia = (Math.Acos(Math.Sin(GradosARadianes(LATITUD_1)) * Math.Sin(GradosARadianes(LATITUD_2)) + Math.Cos(GradosARadianes(LATITUD_1)) * Math.Cos(GradosARadianes(LATITUD_2)) * Math.Cos(GradosARadianes(LONGITUD_1) - GradosARadianes(LONGITUD_2))) * 6378);
            return distancia;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grados"></param>
        /// <returns></returns>
        private static double GradosARadianes(double grados)
        {
            return (grados * Math.PI) / 180;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static List<Negocio> GetLogin(string usuario, string pass)
        {
            SO_Usuario ServicioUsuario = new SO_Usuario();

            TBL_USUARIO InformacionBD = ServicioUsuario.Login(usuario, pass);

            if (InformacionBD != null)
            {
                IList InformacionNegocioBD = ServicioUsuario.GetNegociosUsuario(usuario);
                if (InformacionNegocioBD != null)
                {
                    List<Negocio> ListaNegocios = new List<Negocio>();
                    foreach (var negocio in InformacionNegocioBD)
                    {
                        System.Type tipo = negocio.GetType();

                        Negocio obj = new Negocio();
                        obj.idNegocio = Convert.ToInt32(tipo.GetProperty("ID_NEGOCIO").GetValue(negocio, null));
                        obj.Descripcion = Convert.ToString(tipo.GetProperty("DESCRIPCION").GetValue(negocio, null));
                        obj.Titulo = Convert.ToString(tipo.GetProperty("NOMBRE").GetValue(negocio, null));
                        obj.Horario = Convert.ToString(tipo.GetProperty("HORARIOS").GetValue(negocio, null));
                        obj.idCategoria = Convert.ToInt32(tipo.GetProperty("ID_SUB_CATEGORIA").GetValue(negocio, null));
                        obj.Latitud = Convert.ToDouble(tipo.GetProperty("LATITUD").GetValue(negocio, null));
                        obj.Longitud = Convert.ToDouble(tipo.GetProperty("LONGITUD").GetValue(negocio, null));
                        obj.Telefono = Convert.ToString(tipo.GetProperty("TELEFONO").GetValue(negocio, null));
                        ListaNegocios.Add(obj);
                    }
                    return ListaNegocios;
                }
                else
                {
                    //Existe el usuario pero no tiene negocios registrrados.
                    return null;
                }
            }
            else {
                //No se reconocieron las credenciales
                return null;
            }
        }

        /// <summary>
        /// Método que da de alta un usuario de la aplicación.
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static List<string> SetUsuarioAplicacion(string correo, string pass, string usuario, string nombre, string aPaterno, string aMaterno, DateTime fechaNacimiento, string movil)
        {
            SO_Usuario_Aplicacion ServicioUsuario = new SO_Usuario_Aplicacion();
            List<string> lista = new List<string>();

            if (ServicioUsuario.ExistsUsuario(usuario))
            {
                lista.Add("El usuario que intentas registrar ya esta ocupado");
                return lista;
            }

            if (ServicioUsuario.ExistsCorreo(correo))
            {
                lista.Add("El correo que intentas registrar ya esta ocupado");
                return lista;
            }

            int a = ServicioUsuario.SetUsuarioAplicacion(correo, pass, usuario, nombre, aPaterno, aMaterno, fechaNacimiento, movil);

            string respuesta = a > 0 ? "Has sido registrado!" : "Upps, al parecer hubo algún problema";

            lista.Add(respuesta);

            return lista;
        }

        public static Negocio GetAuto(double longitudInicial, double latitudInicial, double longitudDestino, double latitudDestino, int idUsuarioAplicacion)
        {
            //Declaramos los servicios que utilizaremos en el método.
            SO_Negocio ServicioNegocio = new SO_Negocio();
            SO_Pedidos ServicioPedido = new SO_Pedidos();

            //Declaramos una lista de tipo Negocios que será la que contendrá los candidatos a responder al cliente.
            List<Negocio> ListaNegocio = new List<Negocio>();

            //Declaramos un objeto de tipo negocio que representa el negocio que responde al cliente.
            Negocio negocioResponde = new Negocio();

            //Ejecutamos el método para dar de alta un pedido, el resultado devuelto por el método representa el id del pedido insertado.
            int idPedido = ServicioPedido.SetPedido(latitudInicial, longitudInicial, idUsuarioAplicacion, latitudDestino, longitudDestino);

            //Ejecutamos el método para obtener todos los transportes libres, el resultado lo asignamos a una lista anónima.
            DataSet Negocios = ServicioNegocio.GetTransporteLibre();

            //Comparamos que la lista de negocios libres sea diferente de nulo, y que el idPedido sea diferente de cero.
            if (Negocios != null && idPedido != 0)
            {
                if (Negocios.Tables.Count > 0 && Negocios.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow fila in Negocios.Tables[0].Rows)
                    {
                        //Obtenermos los valores de las propiedades LATITUD y LONGITUD
                        double latitud_negocio = fila["LATITUD"] != DBNull.Value ? Convert.ToDouble(fila["LATITUD"]) : 0;
                        double longitud_negocio = fila["LONGITUD"] != DBNull.Value ? Convert.ToDouble(fila["LONGITUD"]) : 0;

                        //Ejecutamos el método para medir la distancia del punto actual del negocio a la posicion actual del cliente.
                        double distancia = MedirDistancia(latitudInicial, latitud_negocio, longitudInicial, longitud_negocio);

                        //Comparamos si la distancia el igual o menor a 1.8 KM, si es así, lo agregaremos a la lista de candidatos.
                        if (distancia <= 1.8)
                        {
                            //Declaramos un objeto de tipo Negocio.
                            Negocio obj = new Negocio();

                            //Asignamos los valores de  elemento iterado con las correspondientes del objeto.
                            obj.Latitud = latitud_negocio;
                            obj.Longitud = longitud_negocio;
                            obj.idNegocio = fila["ID_NEGOCIO"] != DBNull.Value ? Convert.ToInt32(fila["ID_NEGOCIO"]) : 0;
                            obj.Descripcion = fila["DESCRIPCION"] != DBNull.Value ? Convert.ToString(fila["DESCRIPCION"]) : string.Empty;
                            obj.Titulo = fila["NOMBRE"] != DBNull.Value ? Convert.ToString(fila["NOMBRE"]) : string.Empty;
                            obj.Horario = fila["HORARIOS"] != DBNull.Value ? Convert.ToString(fila["HORARIOS"]) : string.Empty;
                            obj.idCategoria = fila["ID_SUB_CATEGORIA"] != DBNull.Value ? Convert.ToInt32(fila["ID_SUB_CATEGORIA"]) : 0;
                            obj.Telefono = fila["TELEFONO"] != DBNull.Value ? Convert.ToString(fila["TELEFONO"]) : string.Empty;
                            obj.Distancia = distancia;

                            //Agregamos el objeto a la lista.
                            ListaNegocio.Add(obj);
                        }
                    }
                }
            }

            //Comenzamos la busqueda de los taxis que van a dejar pasaje cercas de donde la esta pidiendo el usuario.
            IList informacionBD = ServicioNegocio.GetNegociosOcupados();

            if (informacionBD != null)
            {
                foreach (var negocio in informacionBD)
                {
                    System.Type tipo = negocio.GetType();

                    double latitudActualNegocio = Convert.ToDouble(tipo.GetProperty("LATITUD").GetValue(negocio, null));
                    double longitudActualNegocio = Convert.ToDouble(tipo.GetProperty("LONGITUD").GetValue(negocio, null));

                    //Ejecutamos el método para medir la distancia del punto actual del negocio a la posicion actual del cliente.
                    double distancia = MedirDistancia(latitudInicial, latitudActualNegocio, longitudInicial, longitudActualNegocio);

                    if (distancia <= 2.5)
                    {
                        int ty = Convert.ToInt32(tipo.GetProperty("ID_NEGOCIO").GetValue(negocio, null));
                        PEDIDOS pedido = ServicioNegocio.GetNegocioPedido(ty);

                        if (pedido != null)
                        {

                            double distancia2 = MedirDistancia(latitudInicial, Convert.ToDouble(pedido.LATITUD_DESTINO), longitudInicial, Convert.ToDouble(pedido.LONGITUD_DESTINO));
                            if (distancia2 <= 1.5)
                            {
                                Negocio obj = new Negocio();
                                obj.idNegocio = ty;
                                obj.Descripcion = Convert.ToString(tipo.GetProperty("DESCRIPCION").GetValue(negocio, null));
                                obj.Titulo = Convert.ToString(tipo.GetProperty("NOMBRE").GetValue(negocio, null));
                                obj.Horario = Convert.ToString(tipo.GetProperty("HORARIOS").GetValue(negocio, null));
                                obj.idCategoria = Convert.ToInt32(tipo.GetProperty("ID_SUB_CATEGORIA").GetValue(negocio, null));
                                obj.Latitud = Convert.ToDouble(tipo.GetProperty("LATITUD").GetValue(negocio, null));
                                obj.Longitud = Convert.ToDouble(tipo.GetProperty("LONGITUD").GetValue(negocio, null));
                                obj.Distancia = distancia + distancia2;
                                ListaNegocio.Add(obj);
                            }
                        }
                    }
                }
            }



            //Ordenamos la lista de posibles candidatos de acuerdo a la distancia. Menor - Mayor
            ListaNegocio = ListaNegocio.OrderBy(x => x.Distancia).ToList();

            //Declaramos una bandera la cual nos indica si el servicio fué aceptado por el negocio.
            bool aceptado = false;

            //Iteramos la lista de candidatos para ver quien responde.
            foreach (Negocio ne in ListaNegocio)
            {
                //Obtenemos la hora actual.
                DateTime tiempoInicial = DateTime.Now;

                //Obtenemos la hora actual y le sumamos 10 segundos.
                DateTime tiempoFinal = tiempoInicial.AddSeconds(60);

                //Ejecutamos el método para asignarle al servicio el negocio iterado.
                ServicioPedido.SetOperadorServicio(ne.idNegocio, idPedido);

                aceptado = false;

                //Mientras se ejetute el while, sera el tiempo que estará la alerta en la aplicación del operador.
                while (tiempoInicial <= tiempoFinal && !aceptado)
                {
                    //Esperamos 1 segundo.
                    RespiroSistema(1);

                    //Obtenermos la hora actual.
                    tiempoInicial = DateTime.Now;

                    //Obtenemos el id del estatus del servicio
                    int idEstatus = ServicioPedido.GetEstatusPedido(idPedido);

                    //Comparamos si el estatus es el #5, el cual representa que el negocio ya aceptó.
                    if (idEstatus == 5)
                    {
                        //Asignamos el valor true a la bandera para indicar que ya fué aceptado.
                        aceptado = true;

                        //Asignamos el negocio iterado al objeto de negocioResponde.
                        negocioResponde = ne;
                    }

                }
                //Comparamos si el servicio fué aceptado, si así lo fué rompemos el ciclo
                if (aceptado && negocioResponde != null)
                    break;
            }

            //Verificamos si el servicio fué aceptado y nos aseguramos que el objeto de negocioResponde sea distinto de nulo.
            if (aceptado && negocioResponde != null)

                //Retornamos el objeto de negocioResponde.
                return negocioResponde;
            else

                //Retornamos un nulo.
                return null;

        }

        public static void RespiroSistema(double nSecs)
        {
            // Esperar los segundos indicados

            // Crear la cadena para convertir en TimeSpan
            string s = "0.00:00:" + nSecs.ToString().Replace(",", ".");
            TimeSpan ts = TimeSpan.Parse(s);

            // Añadirle la diferencia a la hora actual
            DateTime t1 = DateTime.Now.Add(ts);

            // Esta asignación solo es necesaria
            // si la comprobación se hace al principio del bucle
            DateTime t2 = DateTime.Now;

            // Mientras no haya pasado el tiempo indicado
            while (t2 < t1)
            {
                // Un respiro para el sitema
                System.Windows.Forms.Application.DoEvents();
                // Asignar la hora actual
                t2 = DateTime.Now;
            }

        }

        public static List<UsuarioAplicacion> LoginUsuarioAplicacion(string correo, string pass)
        {
            SO_Usuario_Aplicacion ServiceObject = new SO_Usuario_Aplicacion();

            IList InformacionBD = ServiceObject.LoginUsuarioAplicacion(correo, pass);
            List<UsuarioAplicacion> lista = new List<UsuarioAplicacion>();
            if (InformacionBD != null)
            {
                foreach (var usuario in InformacionBD)
                {
                    System.Type tipo = usuario.GetType();

                    UsuarioAplicacion obj = new UsuarioAplicacion();
                    obj.idUsuarioAplicacion = (int)tipo.GetProperty("ID_USUARIO_APLICACION").GetValue(usuario, null);
                    obj.Correo = (string)tipo.GetProperty("CORREO").GetValue(usuario, null);
                    obj.Contrasena = (string)tipo.GetProperty("CONTRASENA").GetValue(usuario, null);

                    lista.Add(obj);
                }
            }


            return lista;
        }

        /// <summary>
        /// Método que cambia el estatus de un pedido.
        /// </summary>
        /// <param name="idPedido">Entero que representa el id del pedido.</param>
        /// <param name="idNegocio"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        public static List<string> CambiarEstatusPedido(int idPedido, int idNegocio, int estatus)
        {
            SO_Pedidos ServicioPedido = new SO_Pedidos();
            List<string> listaResultante = new List<string>();
            int r = ServicioPedido.SetCambiarEstatusPedido(idNegocio, idPedido, estatus);
            string a = r > 0 ? "S" : "N";
            listaResultante.Add(a);
            return listaResultante;

        }

        /// <summary>
        /// Método que cambia el estatus del servicio.
        /// </summary>
        /// <param name="idNegocio">Id del negocio que se requiere cambiar es estatus.</param>
        /// <param name="estatus">Entero que representa el estatus: 1=Libre, 2=Asignado, 3=Ocupado, 4=No disponible</param>
        /// <returns></returns>
        public static List<string> CambiarEstatusNegocio(int idNegocio, int estatus)
        {
            //Inicializamos los servicios del negocio.
            SO_Negocio ServicioNegocio = new SO_Negocio();

            //Declaramos una lista la cual será la que retornemos en el método.
            List<string> Lista = new List<string>();

            //Ejecutamos el método y el resultado lo asignamos a una variable local.
            int r = ServicioNegocio.SetCambiarEstatus(idNegocio, estatus);

            //Comparamos si el resultado es mayor a 0 asignamos una "S", sino una "N".
            string s = r > 0 ? "S" : "N";

            //Agregamos la variable a la lista.
            Lista.Add(s);

            //Retornamos la lista creada.
            return Lista;
        }
    }
}