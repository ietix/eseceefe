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
    public partial class usuario : System.Web.UI.Page
    {
        Usuario oUsuarioActual;
        //private int codigoOperacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Cargo el form para editar
                if ((Usuario)Session["usuarioActual"] != null)
                {
                    CargarDatosParaEditar((Usuario)Session["usuarioActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion", 0);
                }
            }
        }

        private void CargarDatosParaEditar(Usuario oUsuarioActual)
        {
            txtUsuario.Value = oUsuarioActual.NombreUsuario;
            txtContraseña.Value = oUsuarioActual.Contraseña;
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //si el codigoOperacion es Null es una edicion.
            if (Session["codigoOperacion"] == null)
            {
                oUsuarioActual = (Usuario)Session["usuarioActual"];
                ControladorGeneral.InsertarActualizarUsuario(oUsuarioActual.Codigo, txtUsuario.Value,txtContraseña.Value);
            }
            //si el codigoOperacion es != null hago un insert.
            else
            {
                ControladorGeneral.InsertarActualizarUsuario(0, txtUsuario.Value, txtContraseña.Value);
            }
            Response.Redirect("listado.aspx");
        }
    }
}