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

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            InicioSesion.SetCorreo(tusuario.Text);
            InicioSesion.SetClave(tclave.Text);

            if (InicioSesion.ValidarLogin() > 0)
            {
                Response.Redirect("inicio.aspx");
            }
        }
    }
}