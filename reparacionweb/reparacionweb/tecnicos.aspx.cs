using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using reparacionweb.classes;

namespace reparacionweb
{
    public partial class tecnicos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT*FROM tecnicos"))
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
            if (classes.Tecnicos.Agregar(tnombre.Text, tespecialidad.Text) > 0)
            {
                LlenarGrid();
                alertas("Técnico ingresado con exito");
            }
            else
            {
                alertas("Error al ingresar técnico");
            }
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            if (classes.Tecnicos.Borrar(int.Parse(tid.Text)) > 0)
            {
                LlenarGrid();
                alertas("Técnico borrado con exito");
            }
            else
            {
                alertas("Error al borrar técnico");
            }
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            if (classes.Tecnicos.Modificar(int.Parse(tid.Text), tnombre.Text, tespecialidad.Text) > 0)
            {
                LlenarGrid();
                alertas("Técnico modificado con exito");
            }
            else
            {
                alertas("Error al modificado técnico");
            }
        }

        protected void button4_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tid.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tecnicos WHERE id ='" + codigo + "'"))


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