﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel.SQLServer
{
    public class Pixie_SQL
    {
        private string StringDeConexion = "Data Source=74.208.227.248;Initial Catalog=PixieLocationBD;Persist Security Info=True;User ID=userPixie;Password=Bd.KJY64";

        public DataSet EjecutarStoredProcedure(string nombreProcedimientoAlmacenado, Dictionary<string, object> parametros)
        {
            //Crea objeto dataset que contendrá los resultados del procedimiento almacenado
            DataSet data = new DataSet();

            try
            {
                //validas que el string de conexión esté inicializado y que el nombre del procedimiento almacenado sea diferente de vacío
                if (this.StringDeConexion != string.Empty && !string.IsNullOrEmpty(nombreProcedimientoAlmacenado))
                {

                    //Se declara la conexión con el string definido
                    using (SqlConnection DBConnection = new SqlConnection(StringDeConexion))
                    {
                        //Inicializa el comando a ejecutar con el nombre del procedimiento almacenado y la conexión definida
                        SqlCommand sqlCommand = new SqlCommand(nombreProcedimientoAlmacenado, DBConnection);
                        //Se indica que será un procedimiento almacenado
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        //por cada parametro de la lista de parametros, se insertan en el comando a ejecutar
                        foreach (var parametro in parametros)
                        {
                            sqlCommand.Parameters.AddWithValue(parametro.Key, parametro.Value);
                        }

                        //Se inicializa el adapter
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = sqlCommand;

                        //se llena el dataSet con lo devuelto por la BD
                        adapter.Fill(data);
                    }
                }
            }
            catch (Exception)
            {
                
                return null;
            }

            return data;
        }
    }
}
