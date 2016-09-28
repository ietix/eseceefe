using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;

namespace SCF.clientes
{
    public partial class cliente : System.Web.UI.Page
    {
        Cliente oClienteActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarComboTipoDocumento();
            if (!IsPostBack)
            {
                //Cargo el form para editar
                if ((Cliente)Session["clienteActual"] != null)
                {
                    CargarDatosParaEditar((Cliente)Session["clienteActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion", 0);
                    cbTipoDocumento.SelectedIndex = 0;
                }
            }
        }

        private void CargarDatosParaEditar(Cliente oClienteActual)
        {
            cbTipoDocumento.SelectedItem = cbTipoDocumento.Items.FindByValue(oClienteActual.TipoDocumento.Codigo);

            txtNroDocumento.Value = oClienteActual.NumeroDocumento;
            txtRazonSocial.Value = oClienteActual.RazonSocial;
            txtMail.Value = oClienteActual.Mail;
            txtTelefono.Value = oClienteActual.Telefono;
            txtPersonaContacto.Value = oClienteActual.PersonaContacto;
            txtBanco.Value = oClienteActual.Banco;
            txtCBU.Value = oClienteActual.Cbu;
            txtNroCuentaBancaria.Value = oClienteActual.NumeroCuenta;
            txtObservacion.Value = oClienteActual.Observaciones;
            txtFax.Value = oClienteActual.Fax;
            txtCodigoConSCF.Value = oClienteActual.CodigoSCF;
        }

        private void CargarComboTipoDocumento()
        {
            cbTipoDocumento.DataSource = ControladorGeneral.RecuperarTodosTiposDocumentos();
            cbTipoDocumento.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //si el codigoOperacion es Null es una edicion.
            if (Session["codigoOperacion"] == null)
            {
                oClienteActual = (Cliente)Session["clienteActual"];
                ControladorGeneral.InsertarActualizarCliente(oClienteActual.Codigo, txtRazonSocial.Value, txtTelefono.Value, txtFax.Value, txtMail.Value, txtNroDocumento.Value, txtPersonaContacto.Value, txtNroCuentaBancaria.Value, txtBanco.Value, txtCBU.Value, txtObservacion.Value, 0, Convert.ToInt32(cbTipoDocumento.Value), txtCodigoConSCF.Value); //agregar tipo documento
            }
            //si el codigoOperacion es != null hago un insert.
            else
            {
                ControladorGeneral.InsertarActualizarCliente(0, txtRazonSocial.Value, txtTelefono.Value, txtMail.Value, txtFax.Value, txtNroDocumento.Value, txtPersonaContacto.Value, txtNroCuentaBancaria.Value, txtBanco.Value, txtCBU.Value, txtObservacion.Value, 0, Convert.ToInt32(cbTipoDocumento.Value), txtCodigoConSCF.Value); //agregar tipo documento
            }
            Response.Redirect("listado.aspx");
        }
    }
}