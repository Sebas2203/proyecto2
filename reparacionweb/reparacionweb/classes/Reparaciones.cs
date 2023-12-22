using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace reparacionweb.classes
{
    public class Reparaciones
    {
        public int id { get; set; }
        public int idEquipo { get; set; }
        public string fechaSolicitud { get; set; }
        public string estado { get; set; }

        public Reparaciones(int idEquipo, string fechaSolicitud, string estado)
        {
            this.idEquipo = idEquipo;
            this.fechaSolicitud = fechaSolicitud;
            this.estado = estado;
        }

        public Reparaciones() { }

        public static int Agregar(string idEquipo, string fechaSolicitud, string estado)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarReparacion", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@idEquipo", idEquipo));
                    cmd.Parameters.Add(new SqlParameter("@fechaSolicitud", fechaSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@estado", estado));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;

            }
            finally { Conn.Close(); }

            return retorno;
        }

        public static int Modificar(int id, int idEquipo, string fechaSolicitud, string estado)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("modificarReparacion", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.Parameters.Add(new SqlParameter("@idEquipo", idEquipo));
                    cmd.Parameters.Add(new SqlParameter("@fechaSolicitud", fechaSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@estado", estado));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;

            }
            finally { Conn.Close(); }

            return retorno;
        }
    }
}