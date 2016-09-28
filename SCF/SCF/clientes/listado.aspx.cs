    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;

namespace SCF.clientes
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

            loadGridClientes();

            Session["clienteActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void loadGridClientes()
        {
            if (rbActivoSi.Checked == true)
                LoadGrillaClientesActivos();
            else
                LoadGrillaClientesInactivos();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoCliente();
        }

        private void NuevoCliente()
        {
            Response.Redirect("cliente.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarCliente();
        }

        private void EditarCliente()
        {
            Cliente clienteActual = new Cliente();

            clienteActual.Codigo = int.Parse(gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "codigoCliente").ToString());
            clienteActual.NumeroDocumento = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "cuil").ToString();
            clienteActual.Mail = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "mail").ToString();
            clienteActual.RazonSocial = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "razonSocial").ToString();
            clienteActual.Telefono = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "telefono").ToString();
            clienteActual.Banco = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "banco").ToString();
            clienteActual.Cbu = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "cbu").ToString();
            clienteActual.PersonaContacto = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "personaContacto").ToString();
            clienteActual.NumeroCuenta = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "numeroCuenta").ToString();
            clienteActual.Observaciones = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "observaciones").ToString();
            clienteActual.Fax = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "fax").ToString();
            clienteActual.TipoDocumento = new TipoDocumento();
            clienteActual.TipoDocumento.Codigo = Convert.ToInt32(gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "codigoTipoDocumento"));
            clienteActual.TipoDocumento.Descripcion = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "tipoDocumento").ToString();
            clienteActual.CodigoSCF = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "codigoSCF").ToString();

            Session.Add("clienteActual", clienteActual);
            Response.Redirect("cliente.aspx");
        }

        protected void btnAceptarEliminarCliente_Click(object sender, EventArgs e)
        {
            if (gvClientes.FocusedRowIndex != -1)
            {
                pcConfirmarEliminarCliente.ShowOnPageLoad = false;

                try
                {
                    ControladorGeneral.EliminarCliente(int.Parse(gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "codigoCliente").ToString()));
                    pcConfirmarEliminarCliente.ShowOnPageLoad = false;
                    loadGridClientes();

                }

                catch
                {

                    //Muestro el mensaje que me devuelve del metodo Eliminar
                    lblMensaje.Text = "El Cliente está asociado a un artículo o nota de pedido";
                    pcMensaje.ShowOnPageLoad = true;
                }
            }
        }

        protected void rbActivoSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivoSi.Checked == true)
                LoadGrillaClientesActivos();
            else
                LoadGrillaClientesInactivos();
        }

        protected void rbActivoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivoNo.Checked == true)
                LoadGrillaClientesInactivos();
            else
                LoadGrillaClientesActivos();
        }

        private void LoadGrillaClientesInactivos()
        {
            btnInactivarCliente.Visible = false;
            btnActivarCliente.Visible = true;
            btnEditar.Visible = false;
            gvClientes.DataSource = ControladorGeneral.RecuperarTodosClientes(true);
            gvClientes.DataBind();
        }

        private void LoadGrillaClientesActivos()
        {
            btnInactivarCliente.Visible = true;
            btnEditar.Visible = true;
            btnActivarCliente.Visible = false;
            gvClientes.DataSource = ControladorGeneral.RecuperarTodosClientes(false);
            gvClientes.DataBind();
        }

        protected void btnActivarCliente_Click(object sender, EventArgs e)
        {
            if (gvClientes.FocusedRowIndex != -1)
            {
                ActivarInactivarCliente();
                LoadGrillaClientesInactivos();
            }
        }

        private void ActivarInactivarCliente()
        {
            ControladorGeneral.ActivarInactivarCliente(int.Parse(gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "codigoCliente").ToString()));
        }

        protected void btnAceptarInactivarCliente_Click(object sender, EventArgs e)
        {
            ActivarInactivarCliente();
            pcShowInactivarCliente.ShowOnPageLoad = false;
            LoadGrillaClientesActivos();
        }

        protected void btnVerDetalleCliente_Click(object sender, EventArgs e)
        {
            pcShowDetalleCliente.ShowOnPageLoad = true;
            lblTipoDoc.InnerText = txtBanco.Value = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "tipoDocumento").ToString();

            txtRazonSocial.Value = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "razonSocial").ToString();
            txtEmail.Value = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "mail").ToString();
            txtCUIL.Value = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "cuil").ToString();
            txtTelFax.Value = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "telefono").ToString() + "/" + gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "fax").ToString();
            txtPersonaCantacto.Value = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "personaContacto").ToString();
            txtNroCuenta.Value = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "numeroCuenta").ToString();
            txtBanco.Value = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "banco").ToString();
            txtCBU.Value = gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "cbu").ToString();

        }

        protected void btnDireccionCliente_Click(object sender, EventArgs e)
        {
            cargarGrillaRelacionDireccionCliente();
        }

        private void cargarGrillaRelacionDireccionCliente()
        {
            if (gvClientes.FocusedRowIndex != -1)
            {
                gvDireccionCliente.DataSource = ControladorGeneral.RecuperarDireccionesPorCliente(Convert.ToInt32(gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "codigoCliente")));
                gvDireccionCliente.DataBind();
            }
            pcRelacionDireccionCliente.ShowOnPageLoad = true;
        }

        protected void btnConfirmarEliminarRelacionDireccionCliente_Click(object sender, EventArgs e)
        {
            if (gvDireccionCliente.FocusedRowIndex != -1)
            {
                try
                {
                    string rta = ControladorGeneral.EliminarDireccionPorCliente(Convert.ToInt32(gvClientes.GetRowValues(gvClientes.FocusedRowIndex, "codigoCliente")), int.Parse(gvDireccionCliente.GetRowValues(gvDireccionCliente.FocusedRowIndex, "codigoDireccionCliente").ToString()));
                    pcError.ShowOnPageLoad = true;

                    if (rta == "ok")
                    {
                        lblMensaje.Text = "La dirección se eliminó correctamente.";
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo eliminar la dirección.";
                    }

                    loadGridClientes();
                }
                catch
                {

                }
            }
        }

        [WebMethod]
        public static string InsertarActualizarDireccionCliente(string provincia, string localidad, string direccion, string codigoCliente)
        {
            try
            {
                ControladorGeneral.InsertarDireccionPorCliente(Convert.ToInt32(codigoCliente), direccion, localidad, provincia);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}