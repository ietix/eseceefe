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

namespace SCF.remitos
{
    public partial class generar_pdf : System.Web.UI.Page
    {        
        dsItemsRemito dsReporte = new dsItemsRemito();
        DataTable tablaReporte = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReporte("remito.rdlc");
            }
        }

        private void LoadReporte(string urlRemito)
        {           
            DataTable dtRemitoActual = (DataTable)Session["tablaRemito"];
            DataTable dtItemsRemitoActual = ControladorGeneral.RecuperarItemsEntrega(Convert.ToInt32(dtRemitoActual.Rows[0]["codigoEntrega"]));
            //numeroNotaDePedido;razonSocialProveedor
            rvRemito.ProcessingMode = ProcessingMode.Local;
            rvRemito.LocalReport.EnableExternalImages = true;
            rvRemito.LocalReport.ReportPath = Server.MapPath("..") + "\\reportes\\" + urlRemito;
            ReportParameter txtNroRemito = new ReportParameter("txtNroRemito", "0001 - " + Convert.ToInt32(dtRemitoActual.Rows[0]["numeroRemito"]).ToString("D8"));
            ReportParameter txtCliente = new ReportParameter("txtCliente", Convert.ToString(dtRemitoActual.Rows[0]["razonSocialCliente"]));
            ReportParameter txtDomicilio = new ReportParameter("txtDomicilio", Convert.ToString(dtRemitoActual.Rows[0]["domicilio"]));
            ReportParameter txtLocalidad = new ReportParameter("txtLocalidad", Convert.ToString(dtRemitoActual.Rows[0]["localidad"]));
            ReportParameter txtNroDocumento = new ReportParameter("txtNroDocumento", Convert.ToString(dtItemsRemitoActual.Rows[0]["nroDocumentoCliente"]));
            ReportParameter txtCondicionVenta = new ReportParameter("txtCondicionVenta", "15 días");
            ReportParameter txtFechaRemito = new ReportParameter("txtFechaRemito", Convert.ToDateTime(dtRemitoActual.Rows[0]["fechaEmision"]).ToString("dd/MM/yyyy"));
            ReportParameter txtRespInsc = new ReportParameter("txtRespInsc", "X");
            ReportParameter txtTransporte = new ReportParameter("txtTransporte", Convert.ToString(dtRemitoActual.Rows[0]["razonSocialTransporte"]));
            ReportParameter txtCai = new ReportParameter("txtCai", dtRemitoActual.Rows[0]["cai"].ToString());
            ReportParameter txtFechaVencimientoCai = new ReportParameter("txtFechaVencimientoCai", Convert.ToDateTime(dtRemitoActual.Rows[0]["fechaVencimientoCai"]).ToString("dd/MM/yyyy"));
            ReportParameter txtObservaciones = new ReportParameter("txtObservaciones", Convert.ToString(dtRemitoActual.Rows[0]["observaciones"]));
            //Mod 10/31/2016
            ReportParameter txtNumeroNotaDePedido = new ReportParameter("txtNumeroNotaDePedido", Convert.ToString(dtItemsRemitoActual.Rows[0]["numeroNotaDePedido"]));
            ReportParameter txtRazonSocialProveedor = new ReportParameter("txtRazonSocialProveedor", Convert.ToString(dtItemsRemitoActual.Rows[0]["codigoSCF"]));
            //
            // Create and setup an instance of Bytescout Barcode SDK
            Barcode bc = new Barcode(SymbologyType.Code128);
            bc.RegistrationName = "demo";
            bc.RegistrationKey = "demo";
            bc.DrawCaption = false;
            bc.Value = ControladorGeneral.ConvertirBarCode(Convert.ToString(dtRemitoActual.Rows[0]["cai"]), Convert.ToDateTime(dtRemitoActual.Rows[0]["fechaEmision"]),"91","0001");
            byte[] imgCodigoDeBarra = bc.GetImageBytesPNG();
            string urlBarCode = Server.MapPath(".") + "\\Comprobantes_AFIP\\codeBar.png";
            File.WriteAllBytes(urlBarCode, imgCodigoDeBarra);

            string imagePath = new Uri(Server.MapPath("~/remitos/Comprobantes_AFIP/codeBar.png")).AbsoluteUri;
            ReportParameter imgBarCode = new ReportParameter("imgBarCode", imagePath);

            //Agrego numero de codigo de barra
            string NumeroCodigoBarra = ControladorGeneral.ConvertirBarCode(Convert.ToString(dtRemitoActual.Rows[0]["cai"]), Convert.ToDateTime(dtRemitoActual.Rows[0]["fechaVencimientoCai"]), "91", "0001");
            ReportParameter txtNumeroCodigoBarra = new ReportParameter("txtNumeroCodigoBarra", NumeroCodigoBarra);


            this.rvRemito.LocalReport.SetParameters(new ReportParameter[] { txtNroRemito,txtCliente,txtDomicilio,txtLocalidad,txtNroDocumento,
            txtCondicionVenta,txtFechaRemito,txtRespInsc, txtTransporte, txtCai, txtFechaVencimientoCai,imgBarCode,txtNumeroCodigoBarra,
            txtNumeroNotaDePedido, txtRazonSocialProveedor, txtObservaciones});

            dsReporte.DataTable1.Clear();
            tablaReporte = dtItemsRemitoActual;

            foreach (DataRow fila in tablaReporte.Rows)
            {
                DataRow filaReporte = dsReporte.DataTable1.NewRow();
                filaReporte["codigoArticulo"] = fila["codigoArticuloCliente"];
                filaReporte["descripcion"] = fila["descripcionCorta"];
                filaReporte["posicion"] = fila["posicion"];
                filaReporte["cantidad"] = fila["cantidad"];
                
                dsReporte.DataTable1.Rows.Add(filaReporte);
            }

            //for (int i = 0; i < (5 - tablaReporte.Rows.Count); i++)
            //for (int i = 0; i < (tablaReporte.Rows.Count); i++)
            for (int i = tablaReporte.Rows.Count; i <= 10; i++)
            {
                DataRow filaReporte = dsReporte.DataTable1.NewRow();
                dsReporte.DataTable1.Rows.Add(filaReporte);
            }
            dsItemsRemito dsReporte1 = dsReporte;

            ReportDataSource datasource = new ReportDataSource("dsItemsRemito", dsReporte1.Tables[0]);
            rvRemito.LocalReport.DataSources.Clear();
            rvRemito.LocalReport.DataSources.Add(datasource);

            // Variables
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            byte[] bytes = rvRemito.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
 

            // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=" + urlRemito + "_SCF" + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush(); // send it to the client to download

        }
    }
}