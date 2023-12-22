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
    public partial class asignaciones1 : System.Web.UI.Page
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
                            tidReparacionAsignada.DataSource = dt;

                            tidReparacionAsignada.DataTextField = dt.Columns["idEquipo"].ToString();
                            tidReparacionAsignada.DataValueField = dt.Columns["id"].ToString();
                            tidReparacionAsignada.DataBind();
                        }
                    }
                }
                using (SqlCommand cmd = new SqlCommand("SELECT*FROM tecnicos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            tidTecnicos.DataSource = dt;

                            tidTecnicos.DataTextField = dt.Columns["nombre"].ToString();
                            tidTecnicos.DataValueField = dt.Columns["id"].ToString();
                            tidTecnicos.DataBind();
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
                using (SqlCommand cmd = new SqlCommand("SELECT*FROM asignaciones"))
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
            if (classes.Asignaciones.Agregar(int.Parse(tidReparacionAsignada.Text), int.Parse(tidTecnicos.Text), tfechaAsignacion.Text) > 0)
            {
                LlenarGrid();
                alertas("Asignacion ingresada con exito");
            }
            else
            {
                alertas("Error al ingresar asignacion");
            }
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            if (classes.Asignaciones.Modificar(int.Parse(tid.Text), int.Parse(tidReparacionAsignada.Text), int.Parse(tidTecnicos.Text), tfechaAsignacion.Text) > 0)
            {
                LlenarGrid();
                alertas("Asignacion modificada con exito");
            }
            else
            {
                alertas("Error al modificadar asignacion");
            }
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}