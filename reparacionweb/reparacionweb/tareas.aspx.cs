using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace reparacionweb
{
    public partial class asignaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("reparaciones.aspx");
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("asignaciones.aspx");
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalles.aspx");
        }
    }
}