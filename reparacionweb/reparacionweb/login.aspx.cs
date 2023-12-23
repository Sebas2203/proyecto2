using reparacionweb.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace reparacionweb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
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
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            InicioSesion.SetCorreo(tusuario.Text);
            InicioSesion.SetClave(tclave.Text);

            if (InicioSesion.ValidarLogin() > 0)
            {
                Response.Redirect("inicio.aspx");
            }
            else
            {
                alertas("Usuario Incorrecto");
            }
        }
    }
}