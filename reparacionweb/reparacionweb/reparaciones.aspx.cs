using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace reparacionweb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                Llenartipos();
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void Llenartipos()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT*FROM equipos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            tidEquipo.DataSource = dt;

                            tidEquipo.DataTextField = dt.Columns["tipoEquipo"].ToString();
                            tidEquipo.DataValueField = dt.Columns["id"].ToString();
                            tidEquipo.DataBind();
                        }
                    }
                }
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT*FROM reparaciones"))
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

        protected void button1_Click(object sender, EventArgs e)
        {
            if (classes.Reparaciones.Agregar(tidEquipo.Text, tfechaSolicitud.Text, testado.Text) > 0)
            {
                LlenarGrid();
                alertas("Reparacion ingresada con exito");
            }
            else
            {
                alertas("Error al ingresar reparacion");
            }
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            if (classes.Reparaciones.Modificar(int.Parse(tid.Text), int.Parse(tidEquipo.Text), tfechaSolicitud.Text, testado.Text) > 0)
            {
                LlenarGrid();
                alertas("Reparacion modificada con exito");
            }
            else
            {
                alertas("Error al modificadar reparacion");
            }
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}