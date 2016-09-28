using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;
using System.Data;
using System.Drawing;
using BibliotecaSCF.ClasesComplementarias;

namespace SCF.nota_pedido
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }

            loadGridNotaPedidos();
        }

        private void loadGridNotaPedidos()
        {
            gvNotasPedido.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido(false);
            gvNotasPedido.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevaNotaPedido();
        }

        private void NuevaNotaPedido()
        {
            Session["tablaNotaDePedido"] = null;
            Session["tablaItemsNotaDePedido"] = null;
            Response.Redirect("nota_pedido.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarNotaPedido();
        }

        private void EditarNotaPedido()
        {
            int codigoNotaDePedido = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoNotaDePedido").ToString());
            string numeroInternoCliente = gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "numeroInternoCliente").ToString();
            DateTime fechaEmision = Convert.ToDateTime(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaEmision").ToString());
            int codigoEstado = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoEstado").ToString());
            int codigoContratoMarco = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoContratoMarco").ToString());
            int codigoCliente = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoCliente").ToString());
            DateTime fechaHoraProximaEntrega = string.IsNullOrEmpty(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaHoraProximaEntrega").ToString()) ? DateTime.MinValue : Convert.ToDateTime(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaHoraProximaEntrega").ToString());
            string observaciones = gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "observaciones").ToString();

            DataTable tablaNotasDePedido = new DataTable();
            tablaNotasDePedido.Columns.Add("codigoNotaDePedido");
            tablaNotasDePedido.Columns.Add("numeroInternoCliente");
            tablaNotasDePedido.Columns.Add("fechaEmision");
            tablaNotasDePedido.Columns.Add("codigoEstado");
            tablaNotasDePedido.Columns.Add("codigoContratoMarco");
            tablaNotasDePedido.Columns.Add("codigoCliente");
            tablaNotasDePedido.Columns.Add("fechaHoraProximaEntrega");
            tablaNotasDePedido.Columns.Add("observaciones");

            tablaNotasDePedido.Rows.Add(new object[] { codigoNotaDePedido, numeroInternoCliente, fechaEmision, codigoEstado, codigoContratoMarco, codigoCliente, fechaHoraProximaEntrega, observaciones });

            Session["tablaNotaDePedido"] = tablaNotasDePedido;

            Response.Redirect("nota_pedido.aspx");
        }

        protected void btnAceptarEliminarNotaPedido_Click(object sender, EventArgs e)
        {
            if (gvNotasPedido.FocusedRowIndex != -1)
            {
                pcConfirmarEliminarNotaPedido.ShowOnPageLoad = false;
                try
                {
                    ControladorGeneral.EliminarNotaDePedido(int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoNotaDePedido").ToString()));
                    Response.Redirect("listado.aspx");
                }

                catch
                {
                    //Muestro el mensaje que me devuelve del metodo Eliminar
                    lblMensaje.Text = "La nota de pedido está asociado a uno o varios remito/s";
                    pcMensaje.ShowOnPageLoad = true;
                }
            }
        }

        protected void gvNotasPedido_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            int codigoEstado = e.GetValue("codigoEstado") == null ? 0 : Convert.ToInt32(e.GetValue("codigoEstado"));
            Color color;

            switch (codigoEstado)
            {
                case Constantes.Estados.VIGENTE:
                    color = Color.LightGreen;
                    break;
                case Constantes.Estados.ENTREGADA:
                    color = Color.Cyan;
                    break;
                case Constantes.Estados.ANULADA:
                    color = Color.LightGray;
                    break;
                case Constantes.Estados.PROXIMA_VENCER:
                    color = Color.Yellow;
                    break;
                case Constantes.Estados.VENCIDA:
                    color = Color.OrangeRed;
                    break;
                default:
                    color = Color.White;
                    break;
            }

            e.Row.BackColor = color;
        }

        protected void gvNotasPedido_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {

        }

        protected void btnShowPopUpObservacion_Click(object sender, EventArgs e)
        {
            txtObservacion.Value = Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "observaciones").ToString());
        }

        protected void btnGuardarObservacion_Click(object sender, EventArgs e)
        {
            int codigoNotaDePedido = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoNotaDePedido").ToString());
            ControladorGeneral.ActivarAnularNotaDePedido(codigoNotaDePedido, txtObservacion.InnerText);
            loadGridNotaPedidos();
        }

        protected void pcShowObservacion_Load(object sender, EventArgs e)
        {
            if (gvNotasPedido.FocusedRowIndex != -1)
            {
                txtObservacion.Value = Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "observaciones").ToString());
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            pcShowDetalleNotaPedido.ShowOnPageLoad = true;


            int codigoNotaDePedido = Convert.ToInt32(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoNotaDePedido"));
            string observacion = Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "observaciones").ToString());

            txtNotaDePedido.Text = gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "numeroInternoCliente").ToString();
            txtFechaEmision.Value = Convert.ToDateTime(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaEmision"));
            txtNombreCliente.Text = gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "razonSocialCliente").ToString();
            txtContratoMarco.Text = gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "descripcionContratoMarco").ToString();
            txtObservacion.InnerText = observacion;


            gvDetalleNotaPedido.DataSource = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);
            gvDetalleNotaPedido.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }
    }
}