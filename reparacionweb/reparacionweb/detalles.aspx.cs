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
    public partial class detalles : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT*FROM reparaciones"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            tidReparacion.DataSource = dt;

                            tidReparacion.DataTextField = dt.Columns["idEquipo"].ToString();
                            tidReparacion.DataValueField = dt.Columns["id"].ToString();
                            tidReparacion.DataBind();
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
                using (SqlCommand cmd = new SqlCommand("SELECT*FROM detallesReparacion"))
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
            if (classes.Detalles.Agregar(int.Parse(tidReparacion.Text), tfechaInicio.Text, tfechaFin.Text, tdescripcion.Text) > 0)
            {
                LlenarGrid();
                alertas("Detalle ingresado con exito");
            }
            else
            {
                alertas("Error al ingresar detalle");
            }
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            if (classes.Detalles.Modificar(int.Parse(tid.Text), int.Parse(tidReparacion.Text), tfechaInicio.Text, tfechaFin.Text, tdescripcion.Text) > 0)
            {
                LlenarGrid();
                alertas("Detalle modificado con exito");
            }
            else
            {
                alertas("Error al modificadar detalle");
            }
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}