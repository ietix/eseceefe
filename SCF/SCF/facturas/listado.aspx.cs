using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;

namespace SCF.facturas
{
  public partial class listado : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      CargarCombo();
    }

    private void CargarGrilla()
    {
      var puntoDeVenta = Convert.ToInt32(cbPuntoDeVenta.SelectedItem.Value);
      gvFacturas.DataSource = ControladorGeneral.RecuperarFacturaPorPuntoDeVenta(puntoDeVenta);
      gvFacturas.DataBind();
    }

    private void CargarCombo()
    {
      cbPuntoDeVenta.DataSource = ControladorGeneral.RecuperarPuntosDeVentaPorTipoComprobante(1);
      cbPuntoDeVenta.DataBind();
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
      Session["tablaFactura"] = null;
      Response.Redirect("factura.aspx");
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
      DataTable tablaFactura = GetTablaFacturaActualSession();

      Session["tablaFactura"] = tablaFactura;
    }

    private DataTable GetTablaFacturaActualSession()
    {
      var codigoFactura = Convert.ToInt32(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "codigoFactura"));
      var numeroFactura = Convert.ToInt32(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "numeroFactura"));
      var fechaFacturacion = Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "fechaFacturacion"));
      var descripcionTipoComprobante = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "descripcionTipoComprobante"));
      var descripcionTipoMoneda = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "descripcionTipoMoneda"));
      var descripcionConcepto = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "descripcionConcepto"));
      var descripcionIVA = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "descripcionIVA"));
      var subtotal = Convert.ToDouble(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "subtotal"));
      var total = Convert.ToDouble(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "total"));
      var cae = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae"));
      var fechaVencimientoCAE = Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "fechaVencimientoCAE"));
      var condicionVenta = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "condicionVenta").ToString();
      var remitos = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "remitos"));
      var domicilio = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "domicilio"));
      var localidad = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "localidad"));
      var cotizacion = Convert.ToDouble(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cotizacion"));
      var observaciones = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "observaciones"));

      var tablaFactura = new DataTable();
      tablaFactura.Columns.Add("codigoFactura");
      tablaFactura.Columns.Add("numeroFactura");
      tablaFactura.Columns.Add("fechaFacturacion");
      tablaFactura.Columns.Add("descripcionTipoComprobante");
      tablaFactura.Columns.Add("descripcionTipoMoneda");
      tablaFactura.Columns.Add("descripcionConcepto");
      tablaFactura.Columns.Add("descripcionIVA");
      tablaFactura.Columns.Add("subtotal");
      tablaFactura.Columns.Add("total");
      tablaFactura.Columns.Add("cae");
      tablaFactura.Columns.Add("fechaVencimientoCAE");
      tablaFactura.Columns.Add("condicionVenta");
      tablaFactura.Columns.Add("remitos");
      tablaFactura.Columns.Add("domicilio");
      tablaFactura.Columns.Add("localidad");
      tablaFactura.Columns.Add("cotizacion");
      tablaFactura.Columns.Add("observaciones");

      tablaFactura.Rows.Add(new object[] { codigoFactura, numeroFactura, fechaFacturacion, descripcionTipoComprobante, descripcionTipoMoneda, descripcionConcepto, descripcionIVA, subtotal,
      total, cae, fechaVencimientoCAE, condicionVenta, remitos, domicilio, localidad, cotizacion, observaciones});

      return tablaFactura;
    }

    protected void btnConfirmarEliminarFactura_Click(object sender, EventArgs e)
    {
      if (gvFacturas.FocusedRowIndex != -1)
      {
        pcConfirmarEliminarFactura.ShowOnPageLoad = false;

        try
        {
          if (gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString() == "")
          {
            ControladorGeneral.EliminarFactura(int.Parse(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "codigoFactura").ToString()));
            Response.Redirect("listado.aspx");
          }
          else
          {
            lblMensaje.Text = "La factura posee CAE, no puede ser eliminada";
            pcMensaje.ShowOnPageLoad = true;
          }
        }
        catch
        {
          //Muestro el mensaje que me devuelve del metodo Eliminar
          lblMensaje.Text = "La factura esta asociada a un recibo o nota de credito";
          pcMensaje.ShowOnPageLoad = true;
        }
      }
    }

    protected void btnDetalle_Click(object sender, EventArgs e)
    {
      if (gvFacturas.FocusedRowIndex != -1)
      {
        if (gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString() == "")
        { btnEmitirComprobante.Visible = true; }

        DataTable dtItemsFacturaActual = ControladorGeneral.RecuperarItemsEntregaPorFactura(Convert.ToInt32(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "codigoFactura")));
        gvDetalleFactura.DataSource = dtItemsFacturaActual;
        gvDetalleFactura.DataBind();

        string nroAMostrar = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString();
        lblNroFacturaAEmitir.Text = "0002 - " + Convert.ToInt32(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "numeroFactura")).ToString("D8");
        lblNroRemitos.Text = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "remitos")).ToString(); //;remitos;
        lblCondicionVenta.Text = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "condicionVenta")).ToString(); ;
        lblLocalidad.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["localidadCliente"]);
        lblDomicilio.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["direccionCliente"]);
        lblNombreApellidoCliente.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["razonSocialCliente"]);
        lblNumeroDocumento.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["nroDocumentoCliente"]);

        lblSubtotal.Text = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "subtotal").ToString();
        lblImporteTotal.Text = Convert.ToString(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "total"));
                
        if (gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString() != null)
        {
          lblNroCAE.Text = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString();
          lblFechaVencimientoCAE.Text = gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "fechaVencimientoCAE").ToString();
        }
                
        //lblFechaVencimientoCAE.Text = Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "fechaVencimientoCAE")).ToString() == null ? "NO EMITIDO" : Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "fechaVencimientoCAE")).ToString("dd/MM/yyy");
        //lblNroCAE.Text = Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae")).ToString() == null ? "NO EMITIDO" : Convert.ToDateTime(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae")).ToString();

        pcDetalleComprobante.ShowOnPageLoad = true;
      }
    }

    protected void cbPuntoDeVenta_SelectedIndexChanged(object sender, EventArgs e)
    {
      CargarGrilla();
    }

    protected void btnEmitirComprobante_Click(object sender, EventArgs e)
    {
      try
      {
        string status = ControladorGeneral.EmitirFactura(Convert.ToInt32(gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "codigoFactura")));
        lblError.Text = status;
        pcError.ShowOnPageLoad = true;
      }
      catch
      {
        lblError.Text = "Ha ocurrido un error. No hay conexion con los servidor de AFIP, vuelva a intentar.";
        pcError.ShowOnPageLoad = true;
      }
    }

    protected void btnGenerarPDF_Click(object sender, EventArgs e)
    {
      if (gvFacturas.FocusedRowIndex != -1)
      {
        if (gvFacturas.GetRowValues(gvFacturas.FocusedRowIndex, "cae").ToString() != "")
        {
          DataTable tableFacturaActual = GetTablaFacturaActualSession();
          Session["tablaFactura"] = tableFacturaActual;

          Response.Write("<script>window.open('generar_pdf.aspx','_blank');</script>");
        }
        else
        {
          lblError.Text = "La factura no tiene CAE. No es posible generar el PDF";
          pcError.ShowOnPageLoad = true;
        }
      }
      else
      {
        lblError.Text = "Debe seleccionar una factura para poder generar el PDF.";
        pcError.ShowOnPageLoad = true;
      }
    }
  }
}