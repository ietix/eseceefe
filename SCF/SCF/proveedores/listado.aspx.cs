using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;

namespace SCF.proveedores
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            loadGridProveedores();

            Session["proveedorActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void loadGridProveedores()
        {
            if (rbActivoSi.Checked == true)
                LoadGrillaProveedoresActivos();
            else
                LoadGrillaProveedoresInactivos();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoProveedor();
        }

        private void NuevoProveedor()
        {
            Response.Redirect("proveedor.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarProveedor();
        }

        private void EditarProveedor()
        {
            Proveedor proveedorActual = new Proveedor();

            proveedorActual.Codigo = int.Parse(gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "codigoProveedor").ToString());
            proveedorActual.NumeroDocumento = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "cuil").ToString();

            proveedorActual.TipoDocumento = new TipoDocumento();
            proveedorActual.TipoDocumento.Codigo = Convert.ToInt32(gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "codigoTipoDocumento"));
            proveedorActual.TipoDocumento.Descripcion = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "tipoDocumento").ToString();

            proveedorActual.Direccion = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "direccion").ToString();
            proveedorActual.Localidad = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "localidad").ToString();
            proveedorActual.Mail = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "mail").ToString();
            proveedorActual.Provincia = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "provincia").ToString();
            proveedorActual.RazonSocial = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "razonSocial").ToString();
            proveedorActual.Telefono = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "telefono").ToString();
            proveedorActual.Banco = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "banco").ToString();
            proveedorActual.Cbu = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "cbu").ToString();
            proveedorActual.PersonaContacto = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "personaContacto").ToString();
            proveedorActual.NumeroCuenta = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "numeroCuenta").ToString();
            proveedorActual.Observaciones = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "observaciones").ToString();
            proveedorActual.Fax = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "fax").ToString();


            Session.Add("proveedorActual", proveedorActual);

            Response.Redirect("proveedor.aspx");
        }

        protected void btnAceptarEliminarProveedor_Click(object sender, EventArgs e)
        {
            if (gvProveedores.FocusedRowIndex != -1)
            {
                pcConfirmarEliminarProveedor.ShowOnPageLoad = false;
                try
                {
                    ControladorGeneral.EliminarProveedor(int.Parse(gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "codigoProveedor").ToString()));
                    Response.Redirect("listado.aspx");
                }

                catch
                {
                    //Muestro el mensaje que me devuelve del metodo Eliminar
                    lblMensaje.Text = "El Proveedor está asociado a un artículo";
                    pcMensaje.ShowOnPageLoad = true;
                }
            }
        }

        protected void btnActivarProveedor_Click(object sender, EventArgs e)
        {
            if (gvProveedores.FocusedRowIndex != -1)
            {
                ControladorGeneral.ActivarInactivarProveedor(int.Parse(gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "codigoProveedor").ToString()));
                LoadGrillaProveedoresInactivos();
            }
        }

        protected void rbActivoSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivoSi.Checked == true)
                LoadGrillaProveedoresActivos();
            else
                LoadGrillaProveedoresInactivos();
        }

        protected void rbActivoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivoNo.Checked == true)
                LoadGrillaProveedoresInactivos();
            else
                LoadGrillaProveedoresActivos();
        }

        private void LoadGrillaProveedoresInactivos()
        {
            btnInactivarProveedor.Visible = false;
            btnEditar.Visible = false;
            btnActivarProveedor.Visible = true;
            gvProveedores.DataSource = ControladorGeneral.RecuperarTodosProveedores(true);
            gvProveedores.DataBind();
        }

        private void LoadGrillaProveedoresActivos()
        {
            btnInactivarProveedor.Visible = true;
            btnEditar.Visible = true;
            btnActivarProveedor.Visible = false;
            gvProveedores.DataSource = ControladorGeneral.RecuperarTodosProveedores(false);
            gvProveedores.DataBind();
        }

        protected void btnAceptarInactivarProveedor_Click(object sender, EventArgs e)
        {
            ControladorGeneral.ActivarInactivarProveedor(int.Parse(gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "codigoProveedor").ToString()));
            pcShowInactivarProveedor.ShowOnPageLoad = false;
            LoadGrillaProveedoresActivos();
        }

        protected void btnVerDetalleProveedor_Click(object sender, EventArgs e)
        {
            pcShowDetalleProveedor.ShowOnPageLoad = true;

            int codigoArticulo = int.Parse(gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "codigoProveedor").ToString());
            lblTipoDoc.InnerText = txtBanco.Value = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "tipoDocumento").ToString();


            txtRazonSocial.Value = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "razonSocial").ToString();
            txtEmail.Value = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "mail").ToString();
            txtCUIL.Value = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "cuil").ToString();
            txtTelFax.Value = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "telefono").ToString() + "/" + gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "fax").ToString();
            txtPersonaCantacto.Value = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "personaContacto").ToString();
            txtNroCuenta.Value = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "numeroCuenta").ToString();
            txtBanco.Value = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "banco").ToString();
            txtCBU.Value = gvProveedores.GetRowValues(gvProveedores.FocusedRowIndex, "cbu").ToString();


        }


    }
}