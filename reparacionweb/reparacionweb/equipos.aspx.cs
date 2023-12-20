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
    public partial class equipos : System.Web.UI.Page
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

        protected void LlenarGrid()
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
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        protected void Llenartipos()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT*FROM usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            tidUsuario.DataSource = dt;

                            tidUsuario.DataTextField = dt.Columns["nombre"].ToString();
                            tidUsuario.DataValueField = dt.Columns["id"].ToString();
                            tidUsuario.DataBind();
                        }
                    }
                }
            }
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            if (classes.Equipos.Agregar(int.Parse(tidUsuario.SelectedValue), ttipoEquipo.Text, tmodelo.Text) != 0)
            {
                LlenarGrid();
                alertas("Equipo ingresado con exito");
            }
            else
            {
                alertas("Error al ingresar equipo");
            }
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            if (classes.Equipos.Borrar(int.Parse(tid.Text)) > 0)
            {
                LlenarGrid();
                alertas("Equipo borrado con exito");
            }
            else
            {
                alertas("Error al borrar equipo");
            }
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            if (classes.Equipos.Modificar(int.Parse(tid.Text), int.Parse(tidUsuario.Text), ttipoEquipo.Text, tmodelo.Text) > 0)
            {
                LlenarGrid();
                alertas("Equipos modificado con exito");
            }
            else
            {
                alertas("Error al modificado Equipos");
            }
        }

        protected void button4_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tid.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM equipos WHERE id ='" + codigo + "'"))


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