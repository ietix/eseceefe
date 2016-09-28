using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;
using Bytescout.BarCode;
using Microsoft.Reporting.WebForms;

namespace SCF.credito
{
    public partial class generar_pdf : System.Web.UI.Page
    {
        dsItemsNotaDeCredito dsReporte = new dsItemsNotaDeCredito();
        DataTable tablaReporte = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadReporte();
        }

        private void LoadReporte()
        {
            DataTable dtNotaDeCreditoActual = (DataTable)Session["tablaNotaCredito"];
            DataTable dtItemsNotaDeCreditoActual = ControladorGeneral.RecuperarItemsNotaDeCredito(Convert.ToInt32(dtNotaDeCreditoActual.Rows[0]["codigoNotaDeCredito"]));
            
            rvNotaCredito.ProcessingMode = ProcessingMode.Local;
            if (Convert.ToString(dtNotaDeCreditoActual.Rows[0]["descripcionTipoMoneda"]) == "Dolar")
            { rvNotaCredito.LocalReport.ReportPath = Server.MapPath("..") + "\\reportes\\notaCreditoA_Obs.rdlc"; }
            else { rvNotaCredito.LocalReport.ReportPath = Server.MapPath("..") + "\\reportes\\notaCreditoA.rdlc"; }
            rvNotaCredito.LocalReport.EnableExternalImages = true;

            ReportParameter txtRespInsc = new ReportParameter("txtRespInsc", "X");
            ReportParameter txtNroFactura = new ReportParameter("txtNroFactura", "0002 - " + Convert.ToInt32(dtNotaDeCreditoActual.Rows[0]["numeroNotaDeCredito"]).ToString("D8").Trim());
            ReportParameter txtCliente = new ReportParameter("txtCliente", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["razonSocialCliente"]).Trim());
            ReportParameter txtDomicilio = new ReportParameter("txtDomicilio", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["domicilio"]).Trim());
            ReportParameter txtLocalidad = new ReportParameter("txtLocalidad", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["localidad"]).Trim());
            ReportParameter txtNroDocumento = new ReportParameter("txtNroDocumento", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["nroDocumentoCliente"]).Trim());
            ReportParameter txtNroRemitos = new ReportParameter("txtNroRemitos", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["remitos"]).Trim());
            ReportParameter txtCondicionVenta = new ReportParameter("txtCondicionVenta", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["condicionVenta"]).Trim());
            ReportParameter txtSubtotal = new ReportParameter("txtSubtotal", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["subtotal"]).Trim());
            ReportParameter txtIVA = new ReportParameter("txtIVA", Convert.ToString(Convert.ToDouble(dtNotaDeCreditoActual.Rows[0]["subtotal"]) * 0.21).Trim());
            ReportParameter txtTotal = new ReportParameter("txtTotal", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["total"]).Trim());
            ReportParameter txtCAE = new ReportParameter("txtCAE", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["cae"]).Trim());
            ReportParameter txtFechaVencimientoCAE = new ReportParameter("txtFechaVencimientoCAE", Convert.ToDateTime(dtNotaDeCreditoActual.Rows[0]["fechaHoraVencimientoCAE"]).ToString("dd/MM/yyyy"));
            ReportParameter txtFechaFacturacion = new ReportParameter("txtFechaFacturacion", Convert.ToDateTime(dtNotaDeCreditoActual.Rows[0]["fechaEmisionNotaDeCredito"]).ToString("dd/MM/yyyy"));
            ReportParameter txtNroNotaPedidoCliente = new ReportParameter("txtNroNotaPedidoCliente", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["numeroNotaDePedido"]).ToString());
            ReportParameter txtRazonSocialProveedor = new ReportParameter("txtRazonSocialProveedor", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["codigoSCF"]).ToString());
            ReportParameter txtTipoMoneda = new ReportParameter("txtTipoMoneda", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["descripcionTipoMoneda"]).Trim());
            ReportParameter txtCotizacion = new ReportParameter("txtCotizacion", Convert.ToString(dtNotaDeCreditoActual.Rows[0]["cotizacion"]).Trim());
            // Create and setup an instance of Bytescout Barcode SDK
            Barcode bc = new Barcode(SymbologyType.Code128);
            bc.RegistrationName = "demo";
            bc.RegistrationKey = "demo";
            bc.DrawCaption = false;
            bc.Value = ControladorGeneral.ConvertirBarCode(Convert.ToString(dtNotaDeCreditoActual.Rows[0]["cae"]), Convert.ToDateTime(dtNotaDeCreditoActual.Rows[0]["fechaHoraVencimientoCAE"]), "03", "0002");
            byte[] imgCodigoDeBarra = bc.GetImageBytesPNG();
            string urlBarCode = Server.MapPath(".") + "\\Comprobantes_AFIP\\codeBar.png";
            File.WriteAllBytes(urlBarCode, imgCodigoDeBarra);

            string imagePath = new Uri(Server.MapPath("~/credito/Comprobantes_AFIP/codeBar.png")).AbsoluteUri;
            ReportParameter imgBarCode = new ReportParameter("imgBarCode", imagePath);

            //Agrego numero de codigo de barra
            string NumeroCodigoBarra = ControladorGeneral.ConvertirBarCode(Convert.ToString(dtNotaDeCreditoActual.Rows[0]["cae"]), Convert.ToDateTime(dtNotaDeCreditoActual.Rows[0]["fechaHoraVencimientoCAE"]), "03", "0002");
            ReportParameter txtNumeroCodigoBarra = new ReportParameter("txtNumeroCodigoBarra", NumeroCodigoBarra);

            this.rvNotaCredito.LocalReport.SetParameters(new ReportParameter[] { txtNroFactura,txtCliente,txtDomicilio,txtLocalidad,txtNroDocumento,txtNroRemitos,
            txtCondicionVenta,txtSubtotal,txtIVA,txtTotal,txtCAE,txtFechaVencimientoCAE,txtFechaFacturacion,imgBarCode,txtNumeroCodigoBarra,txtRespInsc,
            txtNroNotaPedidoCliente,txtRazonSocialProveedor,txtTipoMoneda,txtCotizacion});


            dsReporte.DataTable1.Clear();
            tablaReporte = dtItemsNotaDeCreditoActual;



            foreach (DataRow fila in tablaReporte.Rows)
            {
                DataRow filaReporte = dsReporte.DataTable1.NewRow();
                filaReporte["codigoArticulo"] = fila["codigoArticulo"];
                filaReporte["descripcionCorta"] = fila["descripcionCorta"];
                filaReporte["posicion"] = fila["posicion"];
                filaReporte["cantidad"] = fila["cantidad"];
                filaReporte["precioUnitario"] = fila["precioUnitario"];
                filaReporte["precioTotal"] = fila["precioTotal"];

                dsReporte.DataTable1.Rows.Add(filaReporte);
            }

            //for (int i = 0; i < (5 - tablaReporte.Rows.Count); i++)

            for (int i = tablaReporte.Rows.Count; i <= 10; i++)
            {
                DataRow filaReporte = dsReporte.DataTable1.NewRow();
                dsReporte.DataTable1.Rows.Add(filaReporte);
            }
            dsItemsNotaDeCredito dsReporte1 = dsReporte;

            ReportDataSource datasource = new ReportDataSource("dsItemsNotaDeCredito", dsReporte1.Tables[0]);
            rvNotaCredito.LocalReport.DataSources.Clear();
            rvNotaCredito.LocalReport.DataSources.Add(datasource);
        }
    }
}