using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace reparacionweb.classes
{
    public class Asignaciones
    {
        public int id { get; set; }
        public int idReparacionesAsignaciones { get; set; }
        public int idTecnicos { get; set; }
        public string fechaAsignacion { get; set; }

        public Asignaciones(int id, int idReparacionesAsignaciones, int idTecnicos, string fechaAsignacion)
        {
            this.id = id;
            this.idReparacionesAsignaciones = idReparacionesAsignaciones;
            this.idTecnicos = idTecnicos;
            this.fechaAsignacion = fechaAsignacion;
        }

        public Asignaciones() { }

        public static int Agregar(int idReparacionesAsignaciones, int idTecnicos, string fechaAsignacion)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarAsignaciones", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@idReparacion", idReparacionesAsignaciones));
                    cmd.Parameters.Add(new SqlParameter("@idTecnico", idTecnicos));
                    cmd.Parameters.Add(new SqlParameter("@fechaAsignacion", fechaAsignacion));

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

        public static int Modificar(int id, int idReparacionesAsignaciones, int idTecnicos, string fechaAsignacion)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("modificarAsignaciones", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.Parameters.Add(new SqlParameter("@idReparacion", idReparacionesAsignaciones));
                    cmd.Parameters.Add(new SqlParameter("@idTecnico", idTecnicos));
                    cmd.Parameters.Add(new SqlParameter("@fechaAsignacion", fechaAsignacion));

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