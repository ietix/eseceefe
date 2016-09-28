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
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

            loadGridTransportes();

            Session["transporteActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void loadGridTransportes()
        {
            if (rbActivoSi.Checked == true)
                LoadGrillaTransportesActivos();
            else
                LoadGrillaTransportesInactivos();
        }

        private void LoadGrillaTransportesInactivos()
        {
            btnInactivarTransporte.Visible = false;
            btnActivarTransporte.Visible = true;
            btnEditar.Visible = false;
            gvTransportes.DataSource = ControladorGeneral.RecuperarTodosTransportes(true);
            gvTransportes.DataBind();
        }

        private void LoadGrillaTransportesActivos()
        {
            btnInactivarTransporte.Visible = true;
            btnEditar.Visible = true;
            btnActivarTransporte.Visible = false;
            gvTransportes.DataSource = ControladorGeneral.RecuperarTodosTransportes(false);
            gvTransportes.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoTransporte();
        }

        private void NuevoTransporte()
        {
            Response.Redirect("transporte.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarTransporte();
        }

        private void EditarTransporte()
        {
            Transporte transporteActual = new Transporte();

            transporteActual.Codigo = int.Parse(gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "codigoTransporte").ToString());
            transporteActual.NumeroDocumento = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "numeroDocumento").ToString();
            transporteActual.Direccion = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "direccion").ToString();
            transporteActual.Localidad = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "localidad").ToString();
            transporteActual.Mail = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "mail").ToString();
            transporteActual.Provincia = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "provincia").ToString();
            transporteActual.RazonSocial = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "razonSocial").ToString();
            transporteActual.Telefono = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "telefono").ToString();
            transporteActual.Banco = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "banco").ToString();
            transporteActual.Cbu = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "cbu").ToString();
            transporteActual.PersonaContacto = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "personaContacto").ToString();
            transporteActual.NumeroCuenta = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "numeroCuenta").ToString();
            transporteActual.Observaciones = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "observaciones").ToString();
            transporteActual.Fax = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "fax").ToString();
            transporteActual.TipoDocumento = new TipoDocumento();
            transporteActual.TipoDocumento.Codigo = Convert.ToInt32(gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "codigoTipoDocumento"));
            transporteActual.TipoDocumento.Descripcion = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "tipoDocumento").ToString();


            Session.Add("transporteActual", transporteActual);
            Response.Redirect("transporte.aspx");
        }

        protected void btnActivarTransporte_Click(object sender, EventArgs e)
        {
            if (gvTransportes.FocusedRowIndex != -1)
            {
                ActivarInactivarTransporte();
                LoadGrillaTransportesInactivos();
            }
        }

        private void ActivarInactivarTransporte()
        {
            ControladorGeneral.ActivarInactivarTransporte(int.Parse(gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "codigoTransporte").ToString()));
        }

        protected void btnVerDetalleTransporte_Click(object sender, EventArgs e)
        {
            pcShowDetalleTransporte.ShowOnPageLoad = true;
            lblTipoDoc.InnerText = txtBanco.Value = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "tipoDocumento").ToString();

            txtRazonSocial.Value = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "razonSocial").ToString();
            txtEmail.Value = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "mail").ToString();
            txtCUIL.Value = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "numeroDocumento").ToString();
            txtTelFax.Value = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "telefono").ToString();
            txtPersonaCantacto.Value = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "personaContacto").ToString();
            txtNroCuenta.Value = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "numeroCuenta").ToString();
            txtBanco.Value = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "banco").ToString();
            txtCBU.Value = gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "cbu").ToString();
        }

        protected void btnAceptarEliminarTransporte_Click(object sender, EventArgs e)
        {
            if (gvTransportes.FocusedRowIndex != -1)
            {
                pcConfirmarEliminarTransporte.ShowOnPageLoad = false;
                try
                {
                    ControladorGeneral.EliminarTransporte(int.Parse(gvTransportes.GetRowValues(gvTransportes.FocusedRowIndex, "codigoTransporte").ToString()));
                    pcConfirmarEliminarTransporte.ShowOnPageLoad = false;
                    loadGridTransportes();
                }

                catch
                {
                    lblMensaje.Text = "El Transporte está asociado con una o más factura/s";
                    pcMensaje.ShowOnPageLoad = true;
                }
            }
        }

        protected void btnAceptarInactivarTransporte_Click(object sender, EventArgs e)
        {
            ActivarInactivarTransporte();
            pcShowInactivarTransporte.ShowOnPageLoad = false;
            LoadGrillaTransportesActivos();
        }

        protected void rbActivoSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivoSi.Checked == true)
                LoadGrillaTransportesActivos();
            else
                LoadGrillaTransportesInactivos();
        }

        protected void rbActivoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivoNo.Checked == true)
                LoadGrillaTransportesInactivos();
            else
                LoadGrillaTransportesActivos();
        }
    }
}