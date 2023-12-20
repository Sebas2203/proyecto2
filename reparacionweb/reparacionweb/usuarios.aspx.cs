using reparacionweb.classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace reparacionweb
{
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
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
                using (SqlCommand cmd = new SqlCommand("SELECT*FROM usuarios"))
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
            if (classes.Usuarios.Agregar(tnombre.Text, tcorreo.Text, int.Parse(ttelefono.Text)) > 0)
            {
                LlenarGrid();
                alertas("Usuario ingresado con exito");
            }
            else
            {
                alertas("Error al ingresar usuario");
            }
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            if (classes.Usuarios.Borrar(int.Parse(tid.Text)) > 0)
            {
                LlenarGrid();
                alertas("Usuario borrado con exito");
            }
            else
            {
                alertas("Error al borrar usuario");
            }
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            if (classes.Usuarios.Modificar(int.Parse(tid.Text), tnombre.Text, tcorreo.Text, int.Parse(ttelefono.Text)) != 0)
            {
                LlenarGrid();
                alertas("Usuario modificado con exito");
            }
            else
            {
                alertas("Error al modificado usuario");
            }
        }

        protected void button4_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tid.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios WHERE id ='" + codigo + "'"))


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