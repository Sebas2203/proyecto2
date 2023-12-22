using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace reparacionweb.classes
{
    public class Detalles
    {
        public int id { get; set; }
        public int idReparacion { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string descripcion { get; set; }

        public Detalles(int id, int idReparacion, string fechaInicio, string fechaFin, string descripcion)
        {
            this.id = id;
            this.idReparacion = idReparacion;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.descripcion = descripcion;
        }

        public Detalles() { }

        public static int Agregar(int idReparacion, string fechaInicio, string fechaFin, string descripcion)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarDetallesReparacion", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@idReparacion", idReparacion));
                    cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));

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


        public static int Modificar(int id, int idReparacion, string fechaInicio, string fechaFin, string descripcion)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("modificarDetallesReparacion", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.Parameters.Add(new SqlParameter("@idReparacion", idReparacion));
                    cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));

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