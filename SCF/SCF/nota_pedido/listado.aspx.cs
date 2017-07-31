using BibliotecaSCF.ClasesComplementarias;
using BibliotecaSCF.Controladores;
using System;
using System.Data;
using System.Drawing;

namespace SCF.nota_pedido
{
  using Microsoft.Reporting.WebForms;
  using System.Linq;

  public partial class listado : System.Web.UI.Page
    {
      protected void Page_Load(object sender, EventArgs e)
      {
        if (IsPostBack)
        {
          loadGridNotaPedidos();
        }
        else
        {
          var desde = DateTime.Now.Date;
          var hasta = desde.AddDays(1);
          deFechaDesde.Value = desde;
          deFechaHasta.Value = hasta;
        }
      }

      private void loadGridNotaPedidos()
      {
        gvNotasPedido.DataSource = ControladorGeneral.RecuperarNotasDePedidoPorFecha(DateTime.Parse(deFechaDesde.Value.ToString()), DateTime.Parse(deFechaHasta.Value.ToString()), false);
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
        var codigoNotaDePedido = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoNotaDePedido").ToString());
        var numeroInternoCliente = gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "numeroInternoCliente").ToString();
        var fechaEmision = Convert.ToDateTime(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaEmision").ToString());
        var codigoEstado = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoEstado").ToString());
        var codigoContratoMarco = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoContratoMarco").ToString());
        var codigoCliente = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoCliente").ToString());
        var fechaHoraProximaEntrega = string.IsNullOrEmpty(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaHoraProximaEntrega").ToString()) ? DateTime.MinValue : Convert.ToDateTime(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaHoraProximaEntrega").ToString());
        var observaciones = gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "observaciones").ToString();

        var tablaNotasDePedido = new DataTable();
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

      protected void btnBuscarNotasDePedido_Click(object sender, EventArgs e)
      {
        this.loadGridNotaPedidos();
      }

      protected void gvNotasPedido_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
      {
        var codigoEstado = e.GetValue("codigoEstado") == null ? 0 : Convert.ToInt32(e.GetValue("codigoEstado"));
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

      protected void btnImprimir_Click(object sender, EventArgs e)
      {
        if (gvNotasPedido.FocusedRowIndex != -1)
        {
          pcPrintNotaDePedido.ShowOnPageLoad = true;
          var tablaReportes = ControladorGeneral.RecuperarTodosReportes();
          var reportPath = string.Empty;
          var dsReporte = new dsItemsNotaDePedido();

          if (tablaReportes.Rows.Cast<DataRow>().Any(row => row["nombreReporte"].ToString() == "notaDePedido"))
          {
            reportPath = tablaReportes.Rows.Cast<DataRow>().FirstOrDefault(row => row["nombreReporte"].ToString() == "notaDePedido")["pathReporte1"].ToString();
          }

          rvNotaDePedido.LocalReport.ReportPath = Server.MapPath("..") + reportPath;
          rvNotaDePedido.ProcessingMode = ProcessingMode.Local;
          rvNotaDePedido.LocalReport.EnableExternalImages = true;

          var codigoNotaDePedido = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoNotaDePedido").ToString());

          var txtNroNotaDePedido = new ReportParameter("nroNotaDePedido", Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "numeroInternoCliente")));
          var txtFechaNotaDePedido = new ReportParameter("txtFechaNotaDePedido", Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaEmision")));
          var txtCliente = new ReportParameter("txtCliente", Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "razonSocialCliente")));

          rvNotaDePedido.LocalReport.SetParameters(new ReportParameter[] { txtNroNotaDePedido, txtFechaNotaDePedido, txtCliente });

          var tablaItemsPedido = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);
          
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
        else
        {
          lblMensaje.Text = "Debe seleccionar una nota de pedido.";
          pcMensaje.ShowOnPageLoad = true;
        }
      }

      protected void btnPrint_Click(object sender, EventArgs e)
      {

      }

      protected void btnShowPopUpObservacion_Click(object sender, EventArgs e)
      {
        txtObservacion.Value = Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "observaciones").ToString());
      }

      protected void btnGuardarObservacion_Click(object sender, EventArgs e)
      {
        var codigoNotaDePedido = int.Parse(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoNotaDePedido").ToString());
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


        var codigoNotaDePedido = Convert.ToInt32(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoNotaDePedido"));
        var observacion = Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "observaciones").ToString());

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