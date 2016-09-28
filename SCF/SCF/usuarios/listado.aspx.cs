using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;

namespace SCF.usuarios
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            loadGridUsuarios();

            Session["usuarioActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void loadGridUsuarios()
        {
            gvUsuarios.DataSource = ControladorGeneral.RecuperarTodosUsuarios();
            gvUsuarios.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoArticulo();
        }

        private void NuevoArticulo()
        {
            Response.Redirect("usuario.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarArticulo();
        }

        private void EditarArticulo()
        {
            Usuario usuariosActual = new Usuario();

            usuariosActual.Codigo = int.Parse(gvUsuarios.GetRowValues(gvUsuarios.FocusedRowIndex, "codigoUsuario").ToString());
            usuariosActual.NombreUsuario = gvUsuarios.GetRowValues(gvUsuarios.FocusedRowIndex, "nombreUsuario").ToString();
            usuariosActual.Contraseña = gvUsuarios.GetRowValues(gvUsuarios.FocusedRowIndex, "contraseña").ToString();
            
            Session.Add("usuarioActual", usuariosActual);

            Response.Redirect("usuario.aspx");
        }

        

        protected void btnAceptarEliminarUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}