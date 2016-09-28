using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCF
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioLogueado"] == null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/login.aspx");
            }
            else
            {
                lblUsuarioLogueado.InnerText = " " + Session["usuarioLogueado"].ToString();
            }
        }

        protected void lnkSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}