using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;

namespace SCF.credito
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            gvNotaCredito.DataSource = ControladorGeneral.RecuperarTodasNotasDeCredito();
            gvNotaCredito.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session["tablaNotaCredito"] = null;
            Session["tablaItemsNotaCredito"] = null;
            Response.Redirect("credito.aspx");
        }

        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            if (gvNotaCredito.FocusedRowIndex != -1)
            {
                DataTable tableNotaCreditoActual = GetTablaNotaCreditoActualSession();
                Session["tablaNotaCredito"] = tableNotaCreditoActual;
                Response.Write("<script>window.open('generar_pdf.aspx','_blank');</script>");
            }
            else
            {
                lblMensaje.Text = "Debe seleccionar una Nota de Credito para poder generar el PDF.";
                pcError.ShowOnPageLoad = true;
            }
        }

        private DataTable GetTablaNotaCreditoActualSession()
        {
            int codigoNotaDeCredito = Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoNotaDeCredito"));
            int numeroNotaDeCredito = Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "numeroNotaDeCredito"));
            DateTime fechaNotaDeCredito = Convert.ToDateTime(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "fechaEmisionNotaDeCredito"));
            string descripcionTipoComprobante = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "descripcionTipoComprobante").ToString();
            string descripcionTipoMoneda = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "descripcionTipoMoneda").ToString();
            Double subtotal = Convert.ToDouble(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "subtotal"));
            Double total = Convert.ToDouble(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "total"));
            string cae = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cae").ToString();
            DateTime fechaVencimientoCAE = Convert.ToDateTime(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "fechaHoraVencimientoCAE"));
            string numeroFactura = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "numeroFactura").ToString();
            string codigoFactura = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoFactura").ToString();
            string razonSocialCliente = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "razonSocialCliente").ToString();
            string domicilio = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "domicilio").ToString();
            string localidad = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "localidad").ToString();
            string nroDocumentoCliente = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "nroDocumentoCliente").ToString();
            string remitos = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "remitos").ToString();
            string numeroNotaDePedido = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "numeroNotaDePedido").ToString();
            string codigoSCF = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoSCF").ToString();
            string cotizacion = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cotizacion").ToString();
            string condicionVenta = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "condicionVenta").ToString();

            DataTable tablaNotaDeCredito = new DataTable();
            tablaNotaDeCredito.Columns.Add("codigoNotaDeCredito");
            tablaNotaDeCredito.Columns.Add("numeroNotaDeCredito");
            tablaNotaDeCredito.Columns.Add("fechaEmisionNotaDeCredito");
            tablaNotaDeCredito.Columns.Add("descripcionTipoComprobante");
            tablaNotaDeCredito.Columns.Add("descripcionTipoMoneda");
            tablaNotaDeCredito.Columns.Add("subtotal");
            tablaNotaDeCredito.Columns.Add("total");
            tablaNotaDeCredito.Columns.Add("cae");
            tablaNotaDeCredito.Columns.Add("fechaHoraVencimientoCAE");
            tablaNotaDeCredito.Columns.Add("numeroFactura");
            tablaNotaDeCredito.Columns.Add("codigoFactura");
            tablaNotaDeCredito.Columns.Add("razonSocialCliente");
            tablaNotaDeCredito.Columns.Add("domicilio");
            tablaNotaDeCredito.Columns.Add("localidad");
            tablaNotaDeCredito.Columns.Add("nroDocumentoCliente");
            tablaNotaDeCredito.Columns.Add("remitos");
            tablaNotaDeCredito.Columns.Add("numeroNotaDePedido");
            tablaNotaDeCredito.Columns.Add("codigoSCF");
            tablaNotaDeCredito.Columns.Add("cotizacion");
            tablaNotaDeCredito.Columns.Add("condicionVenta");            
            
            tablaNotaDeCredito.Rows.Add(new object[] { codigoNotaDeCredito, numeroNotaDeCredito, fechaNotaDeCredito, descripcionTipoComprobante, descripcionTipoMoneda, subtotal,
            total,cae,fechaVencimientoCAE, numeroFactura, codigoFactura, razonSocialCliente, domicilio, localidad, nroDocumentoCliente, remitos, numeroNotaDePedido, codigoSCF, cotizacion, condicionVenta});

            return tablaNotaDeCredito;
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (gvNotaCredito.FocusedRowIndex != -1)
            {
                if (gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cae").ToString() == "")
                { btnEmitirComprobante.Visible = true; }

                DataTable dtItemsNotaDeCreditoActual = ControladorGeneral.RecuperarItemsNotaDeCredito(Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoNotaDeCredito")));
                gvDetalleNotaDeCredito.DataSource = dtItemsNotaDeCreditoActual;
                gvDetalleNotaDeCredito.DataBind();

                lblNroFacturaAEmitir.Text = "0002 - " + Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "numeroNotaDeCredito")).ToString("D8");
                lblNroRemitos.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "remitos")).ToString(); //;remitos;
                lblCondicionVenta.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "condicionVenta")).ToString();
                lblLocalidad.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "localidad")).ToString();
                lblDomicilio.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "domicilio")).ToString();
                lblNombreApellidoCliente.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "razonSocialCliente")).ToString();
                lblNumeroDocumento.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "condicionVenta")).ToString();

                lblSubtotal.Text = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "subtotal").ToString();
                lblImporteTotal.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "total"));

                if (gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cae").ToString() != null)
                {
                    lblNroCAE.Text = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cae").ToString();
                    lblFechaVencimientoCAE.Text = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "nroDocumentoCliente").ToString();
                }
                
                //lblFechaVencimientoCAE.Text = Convert.ToDateTime(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "fechaVencimientoCAE")).ToString() == null ? "NO EMITIDO" : Convert.ToDateTime(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "fechaVencimientoCAE")).ToString("dd/MM/yyy");
                //lblNroCAE.Text = Convert.ToDateTime(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cae")).ToString() == null ? "NO EMITIDO" : Convert.ToDateTime(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cae")).ToString();

                pcDetalleComprobante.ShowOnPageLoad = true;
            }
        }

        protected void btnAceptarEliminarNotaCredito_Click(object sender, EventArgs e)
        {
            if (gvNotaCredito.FocusedRowIndex != -1)
            {
                pcConfirmarEliminarNotaCredito.ShowOnPageLoad = false;
                try
                {
                    if("ok" == ControladorGeneral.EliminarNotaDeCredito(int.Parse(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoNotaCredito").ToString())))
                        Response.Redirect("listado.aspx");
                    else
                    {
                        lblMensaje.Text = "La Nota de Credito posee CAE, no puede ser eliminada";
                        pcError.ShowOnPageLoad = true;
                    }
                }
                catch
                {
                    //Muestro el mensaje que me devuelve del metodo Eliminar
                    lblMensaje.Text = "No se pude eliminar la NC";
                    pcError.ShowOnPageLoad = true;
                }
            }
        }

        protected void btnEmitirComprobante_Click(object sender, EventArgs e)
        {

        }
    }
}