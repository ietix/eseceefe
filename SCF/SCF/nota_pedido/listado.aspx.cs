﻿using BibliotecaSCF.ClasesComplementarias;
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

      /// <summary>
      /// Print a Nota de Pedido
      /// </summary>
      /// <param name="sender">The object that raised the event</param>
      /// <param name="e">The arguments sent by event</param>
      protected void btnImprimir_Click(object sender, EventArgs e)
      {
        if (gvNotasPedido.FocusedRowIndex != -1)
        {
          DataTable tableNotaDePedidoActual = GetTablaNotaDePedidoCurrentSession();
          Session["tablaNotaDePedido"] = tableNotaDePedidoActual;

          Response.Write("<script>window.open('generar_pdf.aspx','_blank');</script>");
        }
        else
        {
          lblMensaje.Text = "Debe seleccionar una nota de pedido para poder generar el PDF.";
          pcMensaje.ShowOnPageLoad = true;
        }
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

      /// <summary>
      /// Gets a table containing the current selected Nota de Pedido
      /// </summary>
      /// <returns>A datatable</returns>
      private DataTable GetTablaNotaDePedidoCurrentSession()
      {
        var codigoNotaDePedido = Convert.ToInt32(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoNotaDePedido"));
        var numeroInternoCliente = Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "numeroInternoCliente"));
        var fechaEmision = Convert.ToDateTime(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaEmision"));
        var codigoEstado = Convert.ToInt32(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoEstado"));
        var codigoContratoMarco = Convert.ToInt32(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoContratoMarco"));
        var descripcionContratoMarco = Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "descripcionContratoMarco"));
        var codigoCliente = Convert.ToInt32(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "codigoCliente"));
        var razonSocialCliente = Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "razonSocialCliente"));
        var fechaHoraProximaEntrega = string.IsNullOrEmpty(Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaHoraProximaEntrega"))) ? DateTime.MinValue : Convert.ToDateTime(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "fechaHoraProximaEntrega"));
        var observaciones = Convert.ToString(gvNotasPedido.GetRowValues(gvNotasPedido.FocusedRowIndex, "observaciones"));
        
        var tablaNotaPedido = new DataTable();
        tablaNotaPedido.Columns.Add("codigoNotaDePedido");
        tablaNotaPedido.Columns.Add("numeroInternoCliente");
        tablaNotaPedido.Columns.Add("fechaEmision");
        tablaNotaPedido.Columns.Add("codigoEstado");
        tablaNotaPedido.Columns.Add("codigoContratoMarco");
        tablaNotaPedido.Columns.Add("descripcionContratoMarco");
        tablaNotaPedido.Columns.Add("codigoCliente");
        tablaNotaPedido.Columns.Add("razonSocialCliente");
        tablaNotaPedido.Columns.Add("fechaHoraProximaEntrega");
        tablaNotaPedido.Columns.Add("observaciones");

        tablaNotaPedido.Rows.Add(new object[] { codigoNotaDePedido, numeroInternoCliente, fechaEmision, codigoEstado, codigoContratoMarco, descripcionContratoMarco, codigoCliente, razonSocialCliente,
        fechaHoraProximaEntrega, observaciones});

        return tablaNotaPedido;
      }
    }
}