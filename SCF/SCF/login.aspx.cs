using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;

namespace SCF
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dtUsuarioActual = ControladorGeneral.RecuperarLogueoUsuario(txtUsuario.Value.Trim(), txtContraseña.Value.Trim());
            if (dtUsuarioActual != null)
            {
                Session.Add("usuarioLogueado", dtUsuarioActual.Rows[0][1].ToString());
                Response.Redirect("index.aspx");
            }            
            else
            {
                divAlertLogin.Visible = true;
            }
        }
    }
}