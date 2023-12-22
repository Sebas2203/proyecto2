using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace reparacionweb.classes
{
    public class InicioSesion
    {
        //atributos
        private static int id;
        private static string Clave;
        private static string Correo;
        private static string Nombre;
        private static string NombreUsuario;

        //constructor para inicializar las variavles
        public InicioSesion(string clave, string correo, string nombre)
        {
            Clave = clave;
            Correo = correo;
            Nombre = nombre;
        }

        //getter = mostrar los atributos (funcion -return)
        //setter = asignar valores a los atributos (procedimientos -void)

        //get - set clave
        public static string GetClave()
        {
            return Clave;
        }
        public static void SetClave(string clave)
        {
            Clave = clave;
        }

        //get - set correo 
        public static string GetCorreo()
        {
            return Correo;
        }
        public static void SetCorreo(string correo)
        {
            Correo = correo;
        }

        //get - set nombre
        public static string GetNombre()
        {
            return Nombre;
        }
        public static void SetNombre(string nombre)
        {
            Nombre = nombre;
        }

        public static int ValidarLogin()
        {
            int retorno = 0;
            //int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("validar", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@correo", Correo));
                    cmd.Parameters.Add(new SqlParameter("@clave", Clave));

                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader lectura = cmd.ExecuteReader())
                    {
                        if (lectura.Read())
                        {
                            retorno = 1;
                            Nombre = lectura.GetString(0);

                        }
                        else
                        {
                            retorno = -1;
                        }

                    }


                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }
    }
}