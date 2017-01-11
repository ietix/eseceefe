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
        CargarCombo();

        if (!string.IsNullOrEmpty(Request.QueryString["codigoPuntoDeVenta"]))
        {
          var tablaPuntoDeVenta = (DataTable)Session["puntoDeVenta"];
          cbPuntoDeVenta.Text = string.Format("{0} ({1})", tablaPuntoDeVenta.Rows[0]["numeroPuntoDeVenta"].ToString(), tablaPuntoDeVenta.Rows[0]["descripcion"].ToString());
          gvNotaCredito.DataSource = ControladorGeneral.RecuperarNotaDeCreditoPorPuntoDeVenta(Convert.ToInt32(Request.QueryString["codigoPuntoDeVenta"]));
          gvNotaCredito.DataBind();
        }
      }

      private void CargarGrilla()
      {
        var puntoDeVenta = Convert.ToInt32(cbPuntoDeVenta.SelectedItem.Value);
        gvNotaCredito.DataSource = ControladorGeneral.RecuperarNotaDeCreditoPorPuntoDeVenta(puntoDeVenta);
        gvNotaCredito.DataBind();
      }

      private void CargarCombo()
      {
        cbPuntoDeVenta.DataSource = ControladorGeneral.RecuperarPuntosDeVentaPorTipoComprobante(3);
        cbPuntoDeVenta.DataBind();
      }

      protected void btnNuevo_Click(object sender, EventArgs e)
      {
        if (string.IsNullOrEmpty(cbPuntoDeVenta.Text))
        {
          lblMensaje.Text = "Debe seleccionar un punto de venta!!!";
          pcError.ShowOnPageLoad = true;
        }
        else
        {
          var tablaPuntoDeVenta = new DataTable();

          tablaPuntoDeVenta.Columns.Add("codigoPuntoDeVenta");
          tablaPuntoDeVenta.Columns.Add("numeroPuntoDeVenta");
          tablaPuntoDeVenta.Columns.Add("descripcion");
          tablaPuntoDeVenta.Columns.Add("codigoPuntoDeVentaSuperior");

          var dataRow = tablaPuntoDeVenta.NewRow();
          dataRow["codigoPuntoDeVenta"] = cbPuntoDeVenta.SelectedItem.Value;
          dataRow["numeroPuntoDeVenta"] = cbPuntoDeVenta.SelectedItem.GetValue("numeroPuntoDeVenta");
          dataRow["descripcion"] = cbPuntoDeVenta.SelectedItem.GetValue("descripcion");
          dataRow["codigoPuntoDeVentaSuperior"] = cbPuntoDeVenta.SelectedItem.GetValue("codigoPuntoDeVentaParent");
          tablaPuntoDeVenta.Rows.Add(dataRow);

          Session["puntoDeVenta"] = tablaPuntoDeVenta;
          Session["tablaNotaCredito"] = null;
          Session["tablaItemsNotaCredito"] = null;
          Response.Redirect("credito.aspx");
        }
      }

      protected void btnGenerarPDF_Click(object sender, EventArgs e)
      {
        if (gvNotaCredito.FocusedRowIndex != -1)
        {
          var tableNotaCreditoActual = GetTablaNotaCreditoActualSession();
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
        var codigoNotaDeCredito = Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoNotaDeCredito"));
        var numeroNotaDeCredito = Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "numeroNotaDeCredito"));
        var fechaNotaDeCredito = Convert.ToDateTime(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "fechaEmisionNotaDeCredito"));
        var descripcionTipoComprobante = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "descripcionTipoComprobante").ToString();
        var descripcionTipoMoneda = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "descripcionTipoMoneda").ToString();
        var subtotal = Convert.ToDouble(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "subtotal"));
        var total = Convert.ToDouble(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "total"));
        var cae = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cae").ToString();
        var fechaVencimientoCAE = Convert.ToDateTime(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "fechaHoraVencimientoCAE"));
        var numeroFactura = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "numeroFactura").ToString();
        var codigoFactura = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoFactura").ToString();
        var razonSocialCliente = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "razonSocialCliente").ToString();
        var domicilio = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "domicilio").ToString();
        var localidad = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "localidad").ToString();
        var nroDocumentoCliente = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "nroDocumentoCliente").ToString();
        var remitos = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "remitos").ToString();
        var numeroNotaDePedido = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "numeroNotaDePedido").ToString();
        var codigoSCF = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoSCF").ToString();
        var cotizacion = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cotizacion").ToString();
        var condicionVenta = gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "condicionVenta").ToString();
        var codigoPuntoDeVenta = Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoPuntoDeVenta"));
        var numeroPuntoDeVenta = Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "numeroPuntoDeVenta"));

        var tablaNotaDeCredito = new DataTable();
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
        tablaNotaDeCredito.Columns.Add("codigoPuntoDeVenta");
        tablaNotaDeCredito.Columns.Add("numeroPuntoDeVenta");
            
        tablaNotaDeCredito.Rows.Add(new object[] { codigoNotaDeCredito, numeroNotaDeCredito, fechaNotaDeCredito, descripcionTipoComprobante, descripcionTipoMoneda, subtotal,
        total,cae,fechaVencimientoCAE, numeroFactura, codigoFactura, razonSocialCliente, domicilio, localidad, nroDocumentoCliente, remitos, numeroNotaDePedido, codigoSCF, cotizacion, condicionVenta, codigoPuntoDeVenta, numeroPuntoDeVenta});

        return tablaNotaDeCredito;
      }

      protected void btnVerDetalle_Click(object sender, EventArgs e)
      {
        if (gvNotaCredito.FocusedRowIndex != -1)
        {
          if (gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "cae").ToString() == "")
          {
            btnEmitirComprobante.Visible = true;
          }

          var dtItemsNotaDeCreditoActual = ControladorGeneral.RecuperarItemsNotaDeCredito(Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "codigoNotaDeCredito")));
          var numeroPuntoDeVenta = Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "numeroPuntoDeVenta"));
          gvDetalleNotaDeCredito.DataSource = dtItemsNotaDeCreditoActual;
          gvDetalleNotaDeCredito.DataBind();

          lblNroFacturaAEmitir.Text = string.Format("{0} - {1}", numeroPuntoDeVenta.ToString("D4"), Convert.ToInt32(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "numeroNotaDeCredito")).ToString("D8"));
          lblNroRemitos.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "remitos")); //;remitos;
          lblCondicionVenta.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "condicionVenta"));
          lblLocalidad.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "localidad"));
          lblDomicilio.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "domicilio"));
          lblNombreApellidoCliente.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "razonSocialCliente"));
          lblNumeroDocumento.Text = Convert.ToString(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "condicionVenta"));

          lblSubtotal.Text = Convert.ToDecimal(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "subtotal")).ToString("C");
          lblImporteTotal.Text = Convert.ToDecimal(gvNotaCredito.GetRowValues(gvNotaCredito.FocusedRowIndex, "total")).ToString("C");

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
            { Response.Redirect("listado.aspx"); }
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

      protected void cbPuntoDeVenta_SelectedIndexChanged(object sender, EventArgs e)
      {
        CargarGrilla();
      }

      protected void btnEmitirComprobante_Click(object sender, EventArgs e)
      {

      }
    }
}