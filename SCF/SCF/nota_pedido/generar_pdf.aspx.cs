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
using org.pdfclown.documents;
using org.pdfclown.documents.contents.composition;
using org.pdfclown.documents.contents.fonts;
using org.pdfclown.documents.contents.xObjects;
using org.pdfclown.files;
using org.pdfclown.util.math.geom;
using System.Drawing;

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
      var tablaReportes = ControladorGeneral.RecuperarTodosReportes();
      var reportPath = string.Empty;

      if (tablaReportes.Rows.Cast<DataRow>().Any(row => row["nombreReporte"].ToString() == "notaDePedido"))
      {
        reportPath = tablaReportes.Rows.Cast<DataRow>().FirstOrDefault(row => row["nombreReporte"].ToString() == "notaDePedido")["pathReporte1"].ToString();
      }

      this.rvNotaDePedido.ProcessingMode = ProcessingMode.Local;
      this.rvNotaDePedido.LocalReport.ReportPath = Server.MapPath("..") + reportPath;
      this.rvNotaDePedido.LocalReport.EnableExternalImages = true;

      var codigoNotaDePedido = Convert.ToString(dtNotaDePedidoActual.Rows[0]["codigoNotaDePedido"]);

      var txtNroNotaDePedido = new ReportParameter("nroNotaDePedido", Convert.ToString(dtNotaDePedidoActual.Rows[0]["numeroInternoCliente"]));
      var txtFechaNotaDePedido = new ReportParameter("txtFechaNotaDePedido", Convert.ToDateTime(dtNotaDePedidoActual.Rows[0]["fechaEmision"]).ToString("dd/MM/yyyy"));
      var txtCliente = new ReportParameter("txtCliente", Convert.ToString(dtNotaDePedidoActual.Rows[0]["razonSocialCliente"]));

      this.rvNotaDePedido.LocalReport.SetParameters(new ReportParameter[] { txtNroNotaDePedido, txtFechaNotaDePedido, txtCliente });

      var tablaItemsPedido = ControladorGeneral.RecuperarItemsNotaDePedido(Convert.ToInt32(codigoNotaDePedido));
          
      dsReporte.DataTable1.Clear();

      foreach (DataRow fila in tablaItemsPedido.Rows)
      {
        var filaReporte = dsReporte.DataTable1.NewRow();
        filaReporte["codigoArticulo"] = fila["codigoArticulo"];
        filaReporte["descripcion"] = fila["descripcionCorta"];
        filaReporte["posicion"] = fila["posicion"];
        filaReporte["cantidad"] = fila["cantidad"];
            
        dsReporte.DataTable1.Rows.Add(filaReporte);
      }

      var dtReporte = dsReporte;

      var dataSource = new ReportDataSource("DataSet1", dtReporte.Tables[0]);
      rvNotaDePedido.LocalReport.DataSources.Clear();
      rvNotaDePedido.LocalReport.DataSources.Add(dataSource);
      rvNotaDePedido.LocalReport.Refresh();
    }

    private void Populate(Document document, XObject form)
    {
      // 1. Add a page to the document!
      org.pdfclown.documents.Page page = new org.pdfclown.documents.Page(document); // Instantiates the page inside the document context.
      document.Pages.Add(page); // Puts the page in the pages collection.

      // 2. Create a content composer for the content stream!
      PrimitiveComposer composer = new PrimitiveComposer(page);

      // 3. Inserting contents...
      SizeF pageSize = page.Size;
      // 3.1. Showing the form on the page...
      {
        SizeF formSize = form.Size;
        // Form 1.
        composer.ShowXObject(form, new PointF(pageSize.Width/2,pageSize.Height/2), GeomUtils.Scale(formSize, new SizeF(300,0)), XAlignmentEnum.Center, YAlignmentEnum.Middle, 45);
        // Form 2.
        composer.ShowXObject(form, new PointF(0,pageSize.Height), GeomUtils.Scale(formSize, new SizeF(0,300)), XAlignmentEnum.Left, YAlignmentEnum.Bottom, 0);
        // Form 3.
        composer.ShowXObject(form, new PointF(pageSize.Width,pageSize.Height), new SizeF(80,200), XAlignmentEnum.Right, YAlignmentEnum.Bottom, 0);
      }
      // 3.2. Showing the comments on the page...
      {
        BlockComposer blockComposer = new BlockComposer(composer);
        RectangleF frame = new RectangleF(
          18,
          18,
          pageSize.Width * .5f,
          pageSize.Height * .5f
          );
        blockComposer.Begin(frame,XAlignmentEnum.Justify,YAlignmentEnum.Top);
        StandardType1Font bodyFont = new StandardType1Font(document, StandardType1Font.FamilyEnum.Courier, true, false);
        composer.SetFont(bodyFont,24);
        blockComposer.ShowText("Page-to-form sample");
        SizeF breakSize = new SizeF(0,8);
        blockComposer.ShowBreak(breakSize);
        composer.SetFont(bodyFont,8);
        blockComposer.ShowText("This sample shows how to convert a page to a reusable form that can be placed multiple times on other pages scaling, rotating, anchoring and aligning it.");
        blockComposer.ShowBreak(breakSize);
        blockComposer.ShowText("On this page you can see some of the above-mentioned transformations:");
        breakSize.Width = 8;
        blockComposer.ShowBreak(breakSize);
        blockComposer.ShowText("1. anchored to the center of the page, rotated by 45 degrees counterclockwise, 300 point wide (preserved proportions);"); blockComposer.ShowBreak(breakSize);
        blockComposer.ShowText("2. anchored to the bottom-left corner of the page, 300 point high (preserved proportions);"); blockComposer.ShowBreak(breakSize);
        blockComposer.ShowText("3. anchored to the bottom-right of the page, 80 point wide and 200 point high (altered proportions).");
        blockComposer.End();
      }

      // 4. Flush the contents into the content stream!
      composer.Flush();
    }
  }
}