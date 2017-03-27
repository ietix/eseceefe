using System;
using BibliotecaSCF.Controladores;
using System.Data;
using System.Drawing;
using BibliotecaSCF.ClasesComplementarias;
using BibliotecaSCF.Clases;

namespace SCF.comprobantes
{
  public partial class listado : System.Web.UI.Page
    {
      protected void Page_Load(object sender, EventArgs e)
      {
        loadGridComprobantes();
      }

      private void loadGridComprobantes()
      {
        gvComprobantes.DataSource = ControladorGeneral.RecuperarTodosReportes();
        gvComprobantes.DataBind();
      }

      protected void btnNuevo_Click(object sender, EventArgs e)
      {
        NuevoComprobante();
      }

      private void NuevoComprobante()
      {
        Session["ComprobanteActual"] = null;
        Response.Redirect("comprobante.aspx");
      }

      protected void btnEditar_Click(object sender, EventArgs e)
      {
        EditarPuntoDeVenta();
      }

      private void EditarPuntoDeVenta()
      {
        var puntoDeVenta = new PuntosDeVenta();

        puntoDeVenta.Codigo = Convert.ToInt32(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "codigoPuntoDeVenta"));
        puntoDeVenta.Cai = Convert.ToString(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "cai"));
        puntoDeVenta.Descripcion = Convert.ToString(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "descripcion"));
        puntoDeVenta.Numero = Convert.ToInt32(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "numeroPuntoDeVenta"));
        puntoDeVenta.NumeroActual = Convert.ToInt32(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "numeroActual"));
        puntoDeVenta.NumeroFinal = Convert.ToInt32(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "numeroFinal"));
        puntoDeVenta.NumeroInicial = Convert.ToInt32(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "numeroInicial"));
        puntoDeVenta.VencimientoCai = Convert.ToDateTime(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "vencimientoCai"));
        puntoDeVenta.TipoComprobante = new TipoComprobante();
        puntoDeVenta.TipoComprobante.Codigo = Convert.ToInt32(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "codigoTipoComprobante"));
        puntoDeVenta.TipoComprobante.Descripcion = Convert.ToString(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "descripcionTipoComprobante"));
        puntoDeVenta.PuntoDeVentaSuperior = new PuntosDeVenta();
        puntoDeVenta.PuntoDeVentaSuperior.Codigo = Convert.ToInt32(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "codigoPuntoDeVentaParent"));
        
        Session["puntoDeVentaActual"] = puntoDeVenta;

        Response.Redirect("punto_venta.aspx");
      }

      protected void btnAceptarEliminarComprobante_Click(object sender, EventArgs e)
      {
        if (gvComprobantes.FocusedRowIndex != -1)
        {
          pcConfirmarEliminarComprobante.ShowOnPageLoad = false;
          try
          {
            ControladorGeneral.EliminarNotaDePedido(int.Parse(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "codigoNotaDePedido").ToString()));
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

      protected void gvComprobantes_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
      {
        
      }

      protected void gvComprobantes_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
      {

      }

      protected void btnShowPopUpObservacion_Click(object sender, EventArgs e)
      {

      }

      protected void btnGuardarObservacion_Click(object sender, EventArgs e)
      {
        
      }

      protected void pcShowObservacion_Load(object sender, EventArgs e)
      {
        
      }

      protected void btnVerDetalle_Click(object sender, EventArgs e)
      {
        //pcShowDetalleNotaPedido.ShowOnPageLoad = true;

        //int codigoNotaDePedido = Convert.ToInt32(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "codigoNotaDePedido"));
        //string observacion = Convert.ToString(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "observaciones").ToString());

        //txtNotaDePedido.Text = gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "numeroInternoCliente").ToString();
        //txtFechaEmision.Value = Convert.ToDateTime(gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "fechaEmision"));
        //txtNombreCliente.Text = gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "razonSocialCliente").ToString();
        //txtContratoMarco.Text = gvComprobantes.GetRowValues(gvComprobantes.FocusedRowIndex, "descripcionContratoMarco").ToString();
        //txtObservacion.InnerText = observacion;
      }

      protected void btnEliminar_Click(object sender, EventArgs e)
      {
           
      }
    }
}