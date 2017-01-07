using BibliotecaSCF.ClasesComplementarias;
using BibliotecaSCF.Controladores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCF.remitos
{
    public partial class listado : System.Web.UI.Page
    {
      protected void Page_Load(object sender, EventArgs e)
      {
        CargarCombo();
      }

      private void CargarCombo()
      {
        cbPuntoDeVenta.DataSource = ControladorGeneral.RecuperarPuntosDeVentaPorTipoComprobante(null);
        cbPuntoDeVenta.DataBind();
      }

      private void CargarGrilla()
      {
        var puntoDeVenta = Convert.ToInt32(cbPuntoDeVenta.SelectedItem.Value);
        gvEntregas.DataSource = ControladorGeneral.RecuperarEntregaPorPuntoDeVenta(puntoDeVenta);
        gvEntregas.DataBind();
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

          var dataRow = tablaPuntoDeVenta.NewRow();
          dataRow["codigoPuntoDeVenta"] = cbPuntoDeVenta.SelectedItem.Value;
          dataRow["numeroPuntoDeVenta"] = cbPuntoDeVenta.SelectedItem.GetValue("numeroPuntoDeVenta");
          dataRow["descripcion"] = cbPuntoDeVenta.SelectedItem.GetValue("descripcion");
          tablaPuntoDeVenta.Rows.Add(dataRow);

          Session["puntoDeVenta"] = tablaPuntoDeVenta;
          Session["tablaEntrega"] = null;
          Session["tablaItemsEntrega"] = null;
          Response.Redirect("remito.aspx");
        }
      }

      protected void btnVerDetalle_Click(object sender, EventArgs e)
      {
        pcShowDetalleRemito.ShowOnPageLoad = true;

        var codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
        var codigoNotaDePedido = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoNotaDePedido"));
        var numeroNotaDePedido = Convert.ToString(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "numeroNotaDePedido"));
        var codigoCliente = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoCliente"));
        var razonSocialCliente = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "razonSocialCliente").ToString();
        var fechaEmision = Convert.ToDateTime(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "fechaEmision"));
        var numeroRemito = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "numeroRemito"));
        var codigoEstado = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEstado"));
        var observaciones = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "observaciones").ToString();

        txtCodigo.Text = numeroRemito.ToString();
        txtFechaRemito.Value = fechaEmision;
        txtNotaDePedido.Text = numeroNotaDePedido.ToString();
        txtObservacion.InnerText = observaciones;

        var tablaItemsEntrega = ControladorGeneral.RecuperarItemsEntrega(codigoEntrega);

        gvItemsRemito.DataSource = tablaItemsEntrega;
        gvItemsRemito.DataBind();
      }

      protected void btnEditar_Click(object sender, EventArgs e)
      {
        if (string.IsNullOrEmpty(cbPuntoDeVenta.Text))
        {
          lblMensaje.Text = "Debe seleccionar un punto de venta!!!";
          pcError.ShowOnPageLoad = true;
        }
        else
        {
          var codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
          var codigoNotaDePedido = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoNotaDePedido"));
          var codigoCliente = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoCliente"));
          var razonSocialCliente = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "razonSocialCliente").ToString();
          var fechaEmision = Convert.ToDateTime(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "fechaEmision"));
          var numeroRemito = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "numeroRemito"));
          var codigoEstado = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEstado"));
          var observaciones = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "observaciones").ToString();
          var codigoTransporte = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoTransporte"));
          var codigoDireccion = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoDireccion"));
          var cai = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "cai").ToString();
          var fechaVencimientoCai = Convert.ToDateTime(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "fechaVencimientoCai"));
          var codigoPuntoDeVenta = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoPuntoDeVenta"));
          var numeroPuntoDeVenta = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "numeroPuntoDeVenta").ToString();

          var tablaEntrega = new DataTable();
          tablaEntrega.Columns.Add("codigoEntrega");
          tablaEntrega.Columns.Add("codigoNotaDePedido");
          tablaEntrega.Columns.Add("codigoCliente");
          tablaEntrega.Columns.Add("razonSocialCliente");
          tablaEntrega.Columns.Add("fechaEmision");
          tablaEntrega.Columns.Add("numeroRemito");
          tablaEntrega.Columns.Add("codigoEstado");
          tablaEntrega.Columns.Add("observaciones");
          tablaEntrega.Columns.Add("codigoTransporte");
          tablaEntrega.Columns.Add("codigoDireccion");
          tablaEntrega.Columns.Add("cai");
          tablaEntrega.Columns.Add("fechaVencimientoCai");
          tablaEntrega.Columns.Add("codigoPuntoDeVenta");
          tablaEntrega.Columns.Add("numeroPuntoDeVenta");

          tablaEntrega.Rows.Add(new object[] { codigoEntrega, codigoNotaDePedido, codigoCliente, razonSocialCliente, fechaEmision, numeroRemito, codigoEstado, observaciones, codigoTransporte, 
            codigoDireccion, cai, fechaVencimientoCai, codigoPuntoDeVenta, numeroPuntoDeVenta });

          Session["tablaEntrega"] = tablaEntrega;
          Session["puntoDeVenta"] = null;

          Response.Redirect("remito.aspx");
        }
      }

      protected void btnAceptarEliminarRemito_Click(object sender, EventArgs e)
      {
          if (gvEntregas.FocusedRowIndex != -1)
          {
              int codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
              string mensaje = ControladorGeneral.EliminarEntrega(codigoEntrega);
              pcError.ShowOnPageLoad = true;

              if (mensaje == "ok")
              {
                  lblMensaje.Text = "Se ha eliminado correctamente.";
                  pcError.ShowOnPageLoad = true;
              }
              else
              {
                  lblMensaje.Text = "No se permite elimnar el remito ya que está asociado a una factura";
                  pcError.ShowOnPageLoad = true;
              }

              pcConfirmarEliminarRemito.ShowOnPageLoad = false;
          }
      }

      protected void btnEntregada_Click(object sender, EventArgs e)
      {
          int codigoEstado = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEstado"));
          if (codigoEstado != Constantes.Estados.ANULADA)
          {
              int codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
              string observaciones = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "observaciones").ToString();
              ControladorGeneral.EntregadaPendienteEntrega(codigoEntrega, observaciones);
              CargarGrilla();
          }
          else
          {
              lblMensaje.Text = "No se permite entregar un remito que esta anulado.";
              pcError.ShowOnPageLoad = true;
          }
      }

      /*Se elimina la siguiente llamada al boton y se agrega la opcion que levanta el popup para devolver items del remito..*/
      protected void btnAnulada_Click(object sender, EventArgs e)
      {
          int codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
          string observaciones = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "observaciones").ToString();
          ControladorGeneral.ActivarAnularEntrega(codigoEntrega, observaciones);
          CargarGrilla();
      }

      protected void gvEntregas_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
      {
          int codigoEstado = e.GetValue("codigoEstado") == null ? 0 : Convert.ToInt32(e.GetValue("codigoEstado"));
          Color color;

          switch (codigoEstado)
          {
              case Constantes.Estados.VIGENTE:
                  color = Color.Yellow;
                  break;
              case Constantes.Estados.ENTREGADA:
                  color = Color.Green;
                  break;
              case Constantes.Estados.ANULADA:
                  color = Color.LightGray;
                  break;
              default:
                  color = Color.White;
                  break;
          }

          e.Row.BackColor = color;
      }

      protected void btnDevolucion_Click(object sender, EventArgs e)
      {
          pcDevolucionItemsRemito.ShowOnPageLoad = true;
          CargarItemsRemitoEnVariblaSession();
      }

      private void CargarItemsRemitoEnVariblaSession()
      {

      }

      protected void btnSeleccionarArticulos_Click(object sender, EventArgs e)
      {

      }

      protected void btnEliminarArticulos_Click(object sender, EventArgs e)
      {

      }

      protected void btnGuardar_Click(object sender, EventArgs e)
      {

      }

      protected void gvItemsEntrega_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
      {

      }

      protected void gvItemsEntrega_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
      {

      }

      protected void cbPuntoDeVenta_SelectedIndexChanged(object sender, EventArgs e)
      {
        CargarGrilla();
      }

      protected void btnGenerarPDF_Click(object sender, EventArgs e)
      {
        if (gvEntregas.FocusedRowIndex != -1)
        {
          var tableRemitoActual = GetTablaRemitoActualSession();
          var codigoPuntoDeVenta = Convert.ToInt32(tableRemitoActual.Rows[0]["codigoPuntoDeVenta"]);
          var tablaReporte = ControladorGeneral.RecuperarReportesPorPuntoDeVenta(codigoPuntoDeVenta);

          Session["tablaReporte"] = tablaReporte;
          Session["tablaRemito"] = tableRemitoActual;
          Response.Write("<script>window.open('generar_pdf.aspx','_blank');</script>");
          Response.Write("<script>window.open('generar_pdf_D.aspx','_blank');</script>");
          Response.Write("<script>window.open('generar_pdf_T.aspx','_blank');</script>");
        }
        else
        {
          lblMensaje.Text = "Debe seleccionar una factura para poder generar el PDF.";
          pcError.ShowOnPageLoad = true;
        }
      }

      private DataTable GetTablaRemitoActualSession()
      {
        var codigoEntrega = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEntrega"));
        var codigoNotaDePedido = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoNotaDePedido"));
        var codigoCliente = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoCliente"));
        var razonSocialCliente = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "razonSocialCliente").ToString();
        var fechaEmision = Convert.ToDateTime(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "fechaEmision"));
        var numeroRemito = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "numeroRemito"));
        var codigoEstado = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoEstado"));
        var observaciones = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "observaciones").ToString();
        var razonSocialTransporte = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "razonSocialTransporte").ToString();
        var domicilio = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "domicilio").ToString();
        var localidad = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "localidad").ToString();
        var cai = gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "cai").ToString();
        var fechaVencimientoCAI = Convert.ToDateTime(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "fechaVencimientoCai"));
        var codigoPuntoDeVenta = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "codigoPuntoDeVenta"));
        var numeroPuntoDeVenta = Convert.ToInt32(gvEntregas.GetRowValues(gvEntregas.FocusedRowIndex, "numeroPuntoDeVenta"));

        var tablaEntrega = new DataTable();
        tablaEntrega.Columns.Add("codigoEntrega");
        tablaEntrega.Columns.Add("codigoNotaDePedido");
        tablaEntrega.Columns.Add("codigoCliente");
        tablaEntrega.Columns.Add("razonSocialCliente");
        tablaEntrega.Columns.Add("fechaEmision");
        tablaEntrega.Columns.Add("numeroRemito");
        tablaEntrega.Columns.Add("codigoEstado");
        tablaEntrega.Columns.Add("observaciones");
        tablaEntrega.Columns.Add("razonSocialTransporte");
        tablaEntrega.Columns.Add("domicilio");
        tablaEntrega.Columns.Add("localidad");
        tablaEntrega.Columns.Add("cai");
        tablaEntrega.Columns.Add("fechaVencimientoCai");
        tablaEntrega.Columns.Add("codigoPuntoDeVenta");
        tablaEntrega.Columns.Add("numeroPuntoDeVenta");

        tablaEntrega.Rows.Add(new object[] { codigoEntrega, codigoNotaDePedido, codigoCliente, razonSocialCliente, fechaEmision, numeroRemito, codigoEstado, observaciones, razonSocialTransporte,
        domicilio, localidad, cai, fechaVencimientoCAI, codigoPuntoDeVenta, numeroPuntoDeVenta});

        return tablaEntrega;
      }
    }
}