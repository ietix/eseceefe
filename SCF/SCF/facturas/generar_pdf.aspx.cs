using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;
using Microsoft.Reporting.WebForms;
using Bytescout.BarCode;
using System.IO;

namespace SCF.facturas
{
  public partial class generar_pdf : System.Web.UI.Page
  {
    dsItemsFacturaA dsReporte = new dsItemsFacturaA();
    DataTable tablaReporte = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        LoadReporte();
      }
    }

    private void LoadReporte()
    {
      var dtFacturaActual = (DataTable)Session["tablaFactura"];
      var dtItemsFacturaActual = ControladorGeneral.RecuperarItemsEntregaPorFactura(Convert.ToInt32(dtFacturaActual.Rows[0]["codigoFactura"]));
      var tablaReportes = ControladorGeneral.RecuperarReportesPorPuntoDeVenta(Convert.ToInt32(dtFacturaActual.Rows[0]["codigoPuntoDeVenta"]));
          
      rvFacturaA.ProcessingMode = ProcessingMode.Local;

      if (Convert.ToString(dtFacturaActual.Rows[0]["descripcionTipoMoneda"]) == "Dolar")
      {
        rvFacturaA.LocalReport.ReportPath = Server.MapPath("..") + Convert.ToString(tablaReportes.Rows[0]["pathReporte2"]);
      }
      else
      {
        rvFacturaA.LocalReport.ReportPath = Server.MapPath("..") + Convert.ToString(tablaReportes.Rows[0]["pathReporte1"]);
      }

      rvFacturaA.LocalReport.EnableExternalImages = true;

      var numeroPuntoDeVenta = Convert.ToInt32(dtFacturaActual.Rows[0]["numeroPuntoDeVenta"]).ToString("D4");
      var numeroFactura = Convert.ToInt32(dtFacturaActual.Rows[0]["numeroFactura"]).ToString("D8").Trim();

      var txtRespInsc = new ReportParameter("txtRespInsc", "X");
      var txtNroFactura = new ReportParameter("txtNroFactura", string.Format("{0} - {1}", numeroPuntoDeVenta, numeroFactura));
      var txtCliente = new ReportParameter("txtCliente", Convert.ToString(dtItemsFacturaActual.Rows[0]["razonSocialCliente"]).Trim());
      var txtDomicilio = new ReportParameter("txtDomicilio", Convert.ToString(dtFacturaActual.Rows[0]["domicilio"]).Trim());
      var txtLocalidad = new ReportParameter("txtLocalidad", Convert.ToString(dtFacturaActual.Rows[0]["localidad"]).Trim());
      var txtNroDocumento = new ReportParameter("txtNroDocumento", Convert.ToString(dtItemsFacturaActual.Rows[0]["nroDocumentoCliente"]).Trim());
      var txtNroRemitos = new ReportParameter("txtNroRemitos", Convert.ToString(dtFacturaActual.Rows[0]["remitos"]).Trim());
      var txtCondicionVenta = new ReportParameter("txtCondicionVenta", Convert.ToString(dtFacturaActual.Rows[0]["condicionVenta"]).Trim());
      var txtTotal = new ReportParameter("txtTotal", Convert.ToString(dtFacturaActual.Rows[0]["total"]).Trim());
      var txtCAE = new ReportParameter("txtCAE", Convert.ToString(dtFacturaActual.Rows[0]["cae"]).Trim());
      var txtFechaVencimientoCAE = new ReportParameter("txtFechaVencimientoCAE", Convert.ToDateTime(dtFacturaActual.Rows[0]["fechaVencimientoCAE"]).ToString("dd/MM/yyyy"));
      var txtFechaFacturacion = new ReportParameter("txtFechaFacturacion", Convert.ToDateTime(dtFacturaActual.Rows[0]["fechaFacturacion"]).ToString("dd/MM/yyyy"));
      var txtNroNotaPedidoCliente = new ReportParameter("txtNroNotaPedidoCliente", Convert.ToString(dtItemsFacturaActual.Rows[0]["numeroNotaDePedido"]));
      var txtRazonSocialProveedor = new ReportParameter("txtRazonSocialProveedor", Convert.ToString(dtItemsFacturaActual.Rows[0]["codigoSCF"]));
      var txtTipoMoneda = new ReportParameter("txtTipoMoneda", Convert.ToString(dtFacturaActual.Rows[0]["descripcionTipoMoneda"]).Trim());
      var txtCotizacion = new ReportParameter("txtCotizacion", Convert.ToString(dtFacturaActual.Rows[0]["cotizacion"]).Trim());
      var txtObservaciones = new ReportParameter("txtObservaciones", Convert.ToString(dtFacturaActual.Rows[0]["observaciones"]).Trim());
      var txtSubtotal = new ReportParameter("txtSubtotal");
      var txtIVA = new ReportParameter("txtIVA");

      if (Convert.ToInt32(dtFacturaActual.Rows[0]["codigoPuntoDeVenta"]) == 10)
      {
        txtSubtotal.Values.Add(" ");
        txtIVA.Values.Add(" ");
      }
      else
      {
        txtSubtotal.Values.Add(Convert.ToString(dtFacturaActual.Rows[0]["subtotal"]).Trim());
        txtIVA.Values.Add(Convert.ToString(Convert.ToDouble(dtFacturaActual.Rows[0]["subtotal"]) * 0.21).Trim());
      }

      // Create and setup an instance of Bytescout Barcode SDK
      var bc = new Barcode(SymbologyType.Code128);
      bc.RegistrationName = "demo";
      bc.RegistrationKey = "demo";
      bc.DrawCaption = false;
      bc.Value = ControladorGeneral.ConvertirBarCode(Convert.ToString(dtFacturaActual.Rows[0]["cae"]), Convert.ToDateTime(dtFacturaActual.Rows[0]["fechaVencimientoCAE"]), "01", "0002");
      byte[] imgCodigoDeBarra = bc.GetImageBytesPNG();
      var urlBarCode = Server.MapPath(".") + "\\Comprobantes_AFIP\\codeBar.png";
      File.WriteAllBytes(urlBarCode, imgCodigoDeBarra);

      var imagePath = new Uri(Server.MapPath("~/facturas/Comprobantes_AFIP/codeBar.png")).AbsoluteUri;
      var imgBarCode = new ReportParameter("imgBarCode", imagePath);

      //Agrego numero de codigo de barra
      var NumeroCodigoBarra = ControladorGeneral.ConvertirBarCode(Convert.ToString(dtFacturaActual.Rows[0]["cae"]), Convert.ToDateTime(dtFacturaActual.Rows[0]["fechaVencimientoCAE"]), "01", "0002");
      var txtNumeroCodigoBarra = new ReportParameter("txtNumeroCodigoBarra", NumeroCodigoBarra);

      this.rvFacturaA.LocalReport.SetParameters(new ReportParameter[] 
      { 
        txtNroFactura, txtCliente, txtDomicilio, txtLocalidad, txtNroDocumento, txtNroRemitos, txtCondicionVenta, 
        txtSubtotal, txtIVA, txtTotal, txtCAE, txtFechaVencimientoCAE, txtFechaFacturacion, imgBarCode, txtNumeroCodigoBarra, 
        txtRespInsc, txtNroNotaPedidoCliente, txtRazonSocialProveedor, txtTipoMoneda, txtCotizacion, txtObservaciones
      });

      dsReporte.DataTable1.Clear();
      tablaReporte = dtItemsFacturaActual;

      foreach (DataRow fila in tablaReporte.Rows)
      {
        var filaReporte = dsReporte.DataTable1.NewRow();
        filaReporte["codigoArticulo"] = fila["codigoArticulo"];
        filaReporte["descripcionCorta"] = fila["descripcionCorta"];
        filaReporte["posicion"] = fila["posicion"];
        filaReporte["cantidad"] = fila["cantidad"];
        filaReporte["precioUnitario"] = fila["precioUnitario"];
        filaReporte["precioTotal"] = fila["precioTotal"];

        dsReporte.DataTable1.Rows.Add(filaReporte);
      }

      //for (int i = 0; i < (5 - tablaReporte.Rows.Count); i++)

      for (var i = tablaReporte.Rows.Count; i <= 10; i++)
      {
        var filaReporte = dsReporte.DataTable1.NewRow();
        dsReporte.DataTable1.Rows.Add(filaReporte);
      }

      var dsReporte1 = dsReporte;

      var datasource = new ReportDataSource("dsItemsFacturaA", dsReporte1.Tables[0]);
      rvFacturaA.LocalReport.DataSources.Clear();
      rvFacturaA.LocalReport.DataSources.Add(datasource);
    }
  }
}