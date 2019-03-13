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
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SCF.nota_pedido
{
  public partial class generar_pdf : System.Web.UI.Page
  {
    dsItemsNotaDePedido dsReporte = new dsItemsNotaDePedido();
    
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        LoadReporte();
      }
    }

    private void LoadReporte()
    {
      var dtNotaDePedidoActual = (DataTable)Session["tablaNotaDePedido"];
      var doc = new Document(iTextSharp.text.PageSize.A4);
      var reportPath = Server.MapPath("~/nota_pedido");
      var writer = PdfWriter.GetInstance(doc, new FileStream(reportPath + @"/test.pdf", FileMode.Create));

      doc.AddTitle("Nota de Pedido");
      doc.SetMargins(0, 0, 0, 0);
      doc.Open();

      var background = iTextSharp.text.Image.GetInstance(reportPath + @"/NotaDePedido.jpg");
      var codigoNotaDePedido = Convert.ToInt32(dtNotaDePedidoActual.Rows[0]["codigoNotaDePedido"]);
      var numeroNotaDePedido = dtNotaDePedidoActual.Rows[0]["numeroInternoCliente"];
      var tablaItemsPedido = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);

      background.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
      background.Alignment = iTextSharp.text.Image.UNDERLYING;
      doc.Add(background);

      // Creamos el tipo de Font que vamos utilizar
      var standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
      var title = new Paragraph(10, new string(' ', 140) + "NOTA DE PEDIDO");
      var noteNumber = new Paragraph(39, new string(' ', 137) + numeroNotaDePedido.ToString());
      var noteDate = new Paragraph(37, new string(' ', 143) + Convert.ToDateTime(dtNotaDePedidoActual.Rows[0]["fechaEmision"]).ToString("dd/MM/yyyy"));
      var customer = new Paragraph(92, new string(' ', 28) + Convert.ToString(dtNotaDePedidoActual.Rows[0]["razonSocialCliente"]), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
      var separator = new Paragraph(80, new string(' ', 1));
      title.Alignment = Element.ALIGN_LEFT;
      title.SpacingBefore = 9;
      doc.Add(title);
      doc.Add(noteNumber);
      doc.Add(noteDate);
      doc.Add(customer);
      doc.Add(separator);

      // Creamos una tabla que contendrá el nombre, apellido y país
      // de nuestros visitante.
      float[] relWidths = new float[] { 10, 70, 10, 10 };
      var tblPrueba = new PdfPTable(relWidths);
      tblPrueba.WidthPercentage = 92;

      foreach (DataRow fila in tablaItemsPedido.Rows)
      {
        var codArticulo = new PdfPCell(new Phrase(Convert.ToString(fila["codigoArticulo"]), standardFont));
        codArticulo.BorderWidth = 0;
        codArticulo.Column.Alignment = Element.ALIGN_CENTER;

        var codDescripcion = new PdfPCell(new Phrase(new string(' ', 5) + Convert.ToString(fila["descripcionCorta"]), standardFont));
        codDescripcion.BorderWidth = 0;

        var codPosicion = new PdfPCell(new Phrase(Convert.ToString(fila["posicion"]), standardFont));
        codPosicion.BorderWidth = 0;
        codPosicion.Column.Alignment = Element.ALIGN_CENTER;

        var codCantidad = new PdfPCell(new Phrase(Convert.ToString(fila["cantidad"]), standardFont));
        codCantidad.BorderWidth = 0;
        codCantidad.Column.Alignment = Element.ALIGN_CENTER;

        tblPrueba.AddCell(codArticulo);
        tblPrueba.AddCell(codDescripcion);
        tblPrueba.AddCell(codPosicion);
        tblPrueba.AddCell(codCantidad);
      }

      doc.Add(tblPrueba);
      doc.Close();
      writer.Close();

      Response.Clear();
      Response.ContentType = "application/pdf";
      Response.WriteFile(reportPath + @"/test.pdf");
      Response.End();
    }

    //private void LoadReporte()
    //{
    //  var dtNotaDePedidoActual = (DataTable)Session["tablaNotaDePedido"];
    //  var tablaReportes = ControladorGeneral.RecuperarTodosReportes();
    //  var reportPath = string.Empty;

    //  if (tablaReportes.Rows.Cast<DataRow>().Any(row => row["nombreReporte"].ToString() == "notaDePedido"))
    //  {
    //    reportPath = tablaReportes.Rows.Cast<DataRow>().FirstOrDefault(row => row["nombreReporte"].ToString() == "notaDePedido")["pathReporte1"].ToString();
    //  }

    //  this.rvNotaDePedido.ProcessingMode = ProcessingMode.Local;
    //  this.rvNotaDePedido.LocalReport.ReportPath = Server.MapPath("..") + reportPath;
    //  this.rvNotaDePedido.LocalReport.EnableExternalImages = true;

    //  var codigoNotaDePedido = Convert.ToString(dtNotaDePedidoActual.Rows[0]["codigoNotaDePedido"]);

    //  var txtNroNotaDePedido = new ReportParameter("nroNotaDePedido", Convert.ToString(dtNotaDePedidoActual.Rows[0]["numeroInternoCliente"]));
    //  var txtFechaNotaDePedido = new ReportParameter("txtFechaNotaDePedido", Convert.ToDateTime(dtNotaDePedidoActual.Rows[0]["fechaEmision"]).ToString("dd/MM/yyyy"));
    //  var txtCliente = new ReportParameter("txtCliente", Convert.ToString(dtNotaDePedidoActual.Rows[0]["razonSocialCliente"]));

    //  this.rvNotaDePedido.LocalReport.SetParameters(new ReportParameter[] { txtNroNotaDePedido, txtFechaNotaDePedido, txtCliente });

    //  var tablaItemsPedido = ControladorGeneral.RecuperarItemsNotaDePedido(Convert.ToInt32(codigoNotaDePedido));

    //  dsReporte.DataTable1.Clear();

    //  foreach (DataRow fila in tablaItemsPedido.Rows)
    //  {
    //    var filaReporte = dsReporte.DataTable1.NewRow();
    //    filaReporte["codigoArticulo"] = fila["codigoArticulo"];
    //    filaReporte["descripcion"] = fila["descripcionCorta"];
    //    filaReporte["posicion"] = fila["posicion"];
    //    filaReporte["cantidad"] = fila["cantidad"];
            
    //    dsReporte.DataTable1.Rows.Add(filaReporte);
    //  }

    //  var dtReporte = dsReporte;

    //  var dataSource = new ReportDataSource("DataSet1", dtReporte.Tables[0]);
    //  rvNotaDePedido.LocalReport.DataSources.Clear();
    //  rvNotaDePedido.LocalReport.DataSources.Add(dataSource);
    //  rvNotaDePedido.LocalReport.Refresh();
    //}
  }
}