using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;

namespace SCF.transportes
{
    public partial class transporte : System.Web.UI.Page
    {
        Transporte oTransporteActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarComboTipoDocumento();
            if (!IsPostBack)
            {
                //Cargo el form para editar
                if ((Transporte)Session["transporteActual"] != null)
                {
                    CargarDatosParaEditar((Transporte)Session["transporteActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion", 0);
                    cbTipoDocumento.SelectedIndex = 0;
                }
            }
        }

        private void CargarDatosParaEditar(Transporte transporte)
        {
            cbTipoDocumento.SelectedItem = cbTipoDocumento.Items.FindByValue(transporte.TipoDocumento.Codigo);

            txtNroDocumento.Value = transporte.NumeroDocumento;
            txtRazonSocial.Value = transporte.RazonSocial;
            txtCiudad.Value = transporte.Localidad;
            txtDireccion.Value = transporte.Direccion;
            txtMail.Value = transporte.Mail;
            txtProvincia.Value = transporte.Provincia;
            txtTelefono.Value = transporte.Telefono;
            txtPersonaContacto.Value = transporte.PersonaContacto;
            txtBanco.Value = transporte.Banco;
            txtCBU.Value = transporte.Cbu;
            txtNroCuentaBancaria.Value = transporte.NumeroCuenta;
            txtObservacion.Value = transporte.Observaciones;
            txtFax.Value = transporte.Fax;

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
                oTransporteActual = (Transporte)Session["transporteActual"];
                ControladorGeneral.InsertarActualizarTransporte(oTransporteActual.Codigo, txtRazonSocial.Value, txtProvincia.Value, txtCiudad.Value, txtDireccion.Value, txtTelefono.Value,
                    txtFax.Value, txtMail.Value, txtNroDocumento.Value, txtPersonaContacto.Value, txtNroCuentaBancaria.Value, txtBanco.Value, txtCBU.Value, txtObservacion.Value, Convert.ToInt32(cbTipoDocumento.Value)); //agregar tipo documento
            }
            //si el codigoOperacion es != null hago un insert.
            else
            {
                ControladorGeneral.InsertarActualizarTransporte(0, txtRazonSocial.Value, txtProvincia.Value, txtCiudad.Value, txtDireccion.Value, txtTelefono.Value, txtMail.Value, txtFax.Value,
                    txtNroDocumento.Value, txtPersonaContacto.Value, txtNroCuentaBancaria.Value, txtBanco.Value, txtCBU.Value, txtObservacion.Value, Convert.ToInt32(cbTipoDocumento.Value)); //agregar tipo documento
            }
            Response.Redirect("listado.aspx");
        }
    }
}