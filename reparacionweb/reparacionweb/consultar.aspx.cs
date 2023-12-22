using reparacionweb.classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace reparacionweb
{
    public partial class estudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //mostrar el nombre de la persona que ingresó
            lusuario.Text = InicioSesion.GetNombre();

            if (IsPostBack)
            {
                LlenarGrid();
                //LlenarGrid1();
            }
        }

        //protected void LlenarGrid1()
        //{
        //    string rol = classes.Tecnicos.;
        //    int idtec = 3;
        //    string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        SqlCommand cmd = new SqlCommand("consultar", con)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };
        //        cmd.Parameters.Add(new SqlParameter("@ROl", rol));
        //        cmd.Parameters.Add(new SqlParameter("@IDTEC", idtec));

        //        using (SqlDataAdapter sda = new SqlDataAdapter())
        //        {
        //            cmd.Connection = con;
        //            sda.SelectCommand = cmd;
        //            using (DataTable dt = new DataTable())
        //            {
        //                sda.Fill(dt);
        //                datagrid.DataSource = dt;
        //                datagrid.DataBind();  // Refrescar los datos
        //            }
        //        }
        //    }
        //}


        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("consultar"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }


    }
}