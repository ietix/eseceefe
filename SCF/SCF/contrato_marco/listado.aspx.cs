using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;

namespace SCF.contrato_marco
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            Session["tablaItemsContratoMarco"] = null;

            gvContratosMarco.DataSource = ControladorGeneral.RecuperarTodosContratosMarcos(true);
            gvContratosMarco.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("contrato.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptarEliminarContratoMarco_Click(object sender, EventArgs e)
        {
            int codigoContratoMarco = Convert.ToInt32(gvContratosMarco.GetRowValues(gvContratosMarco.FocusedRowIndex, "codigoContratoMarco"));
            string rta = ControladorGeneral.EliminarContratoMarco(codigoContratoMarco);

            if (rta == "ok")
            {
                lblError.Value = "El contrato marco se ha eliminado correctamente.";
            }
            else
            {
                lblError.Value = "No se puede eliminar el contrato marco ya que esta asociado a una nota de pedido.";
            }

            pcError.ShowOnPageLoad = true;

            gvContratosMarco.DataSource = ControladorGeneral.RecuperarTodosContratosMarcos(true);
            gvContratosMarco.DataBind();
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            pcShowDetalleContratoMarco.ShowOnPageLoad = true;

            string descripcion = gvContratosMarco.GetRowValues(gvContratosMarco.FocusedRowIndex, "descripcion").ToString();
            DateTime fechaInicio = Convert.ToDateTime(gvContratosMarco.GetRowValues(gvContratosMarco.FocusedRowIndex, "fechaInicio"));
            DateTime fechaFin = Convert.ToDateTime(gvContratosMarco.GetRowValues(gvContratosMarco.FocusedRowIndex, "fechaFin"));
            string razonSocialCliente = gvContratosMarco.GetRowValues(gvContratosMarco.FocusedRowIndex, "razonSocialCliente").ToString();
            string comprador = gvContratosMarco.GetRowValues(gvContratosMarco.FocusedRowIndex, "comprador").ToString();
            int codigoContratoMarco = Convert.ToInt32(gvContratosMarco.GetRowValues(gvContratosMarco.FocusedRowIndex, "codigoContratoMarco"));

            txtDescripcion.Value = descripcion;
            txtFechaFin.Value = fechaFin.ToString();
            txtFechaInicio.Value = fechaInicio.ToString();
            txtRazonSocialCliente.Value = razonSocialCliente;
            txtComprador.Value = comprador;

            DataTable tablaItemsCM = ControladorGeneral.RecuperarItemsContratoMarco(codigoContratoMarco);

            gvItemsContratoMarco.DataSource = tablaItemsCM;
            gvItemsContratoMarco.DataBind();
        }
    }
}