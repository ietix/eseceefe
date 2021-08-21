using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;

namespace SCF.credito
{
    public partial class credito : System.Web.UI.Page
    {
      protected void Page_Load(object sender, EventArgs e)
      {
        if (!IsPostBack)
        {
            if (Session["tablaNotaCredito"] == null)
            {
              CargarNumeroNotaCredito();
            }
        }

        CargarComboFacturas();
        txtFechaEmision.Value = DateTime.Now;
      }

      private void CargarComboFacturas()
      {
        var codigoPuntoDeVenta = Convert.ToInt32(((DataTable)Session["puntoDeVenta"]).Rows[0]["codigoPuntoDeVentaSuperior"]);
        
        cbFactura.DataSource = ControladorGeneral.RecuperarFacturaPorPuntoDeVenta(codigoPuntoDeVenta);
        cbFactura.DataBind();
      }

      private void CargarNumeroNotaCredito()
      {
        //Obtengo el Ultimo numero de nota de Credito y le sumo 1.
        var codigoPuntoDeVenta = Convert.ToInt32(((DataTable)Session["puntoDeVenta"]).Rows[0]["codigoPuntoDeVenta"]);
        var tablaUltimaNotaCredito = ControladorGeneral.RecuperarNotaDeCreditoPorPuntoDeVenta(codigoPuntoDeVenta);
        try
        {
          txtNotaCredito.Value = tablaUltimaNotaCredito.Rows.Count > 0 ? (Convert.ToInt32(tablaUltimaNotaCredito.Rows[0]["numeroNotaDeCredito"]) + 1).ToString() : "1";
        }
        catch 
        {
          txtNotaCredito.Value = 1;    
        }
      }

      //Retorna el ultimo comprobante autorizado para el tipo de comprobante / cuit / punto de venta ingresado/ Tipo de Emisión
      //Enviar CUIT,PtoVta,CbteTipo
      protected void btnUltimoNroComprobante_Click(object sender, EventArgs e)
      {
        try
        {
          var numeroPuntoDeVenta = Convert.ToInt32(((DataTable)Session["puntoDeVenta"]).Rows[0]["numeroPuntoDeVenta"]);
          var codigoPuntoDeVenta = Convert.ToInt32(((DataTable)Session["puntoDeVenta"]).Rows[0]["codigoPuntoDeVenta"]);
          var codigoTipoComprobante = Convert.ToInt32(ControladorGeneral.RecuperarPuntosDeVentaPorCodigo(codigoPuntoDeVenta).Rows[0]["codigoTipoComprobante"]);
          
          lblUltimoNroComprobante.Text = Convert.ToString(ControladorGeneral.ConsultarUltimoNroComprobante(numeroPuntoDeVenta, codigoTipoComprobante));
          pcUltimoComprobanteAfip.ShowOnPageLoad = true;
        }
        catch
        {
          lblError.Text = "Ha ocurrido un error. No hay conexion con los servidor de AFIP, vuelva a intentar.";
          pcError.ShowOnPageLoad = true;
        }
      }

      protected void cbFactura_SelectedIndexChanged(object sender, EventArgs e)
      {
        CargarItemsFacturas();            
      }

      private void CargarItemsFacturas()
      {
        var dtFacturaActual = ControladorGeneral.RecuperarFacturaPorCodigo(Convert.ToInt32(cbFactura.Value));
        Session["dtFacturaActual"] = dtFacturaActual;

        txtTipoMoneda.Text = dtFacturaActual.Rows[0]["descripcionTipoMoneda"].ToString();
        txtConcepto.Text = dtFacturaActual.Rows[0]["concepto"].ToString();
        txtCondicionVenta.Text = dtFacturaActual.Rows[0]["condicionventa"].ToString();
        txtCotizacion.Text = dtFacturaActual.Rows[0]["cotizacion"].ToString();

        var dtDatosFactura = ControladorGeneral.RecuperarItemsEntregaPorFactura(Convert.ToInt32(cbFactura.Value));
        Session["dtDatosFactura"] = dtDatosFactura;

        txtRazonSocial.Text = dtDatosFactura.Rows[0]["razonSocialCliente"].ToString();
        txtNroDocumento.Text = dtDatosFactura.Rows[0]["nroDocumentoCliente"].ToString();
        txtCodigoConSCF.Text = dtDatosFactura.Rows[0]["codigoSCF"].ToString();
        txtCodigoRemito.Text = dtDatosFactura.Rows[0]["nroRemito"].ToString();
        txtDireccion.Text = dtDatosFactura.Rows[0]["direccionCliente"].ToString();
        txtTransporte.Text = dtDatosFactura.Rows[0]["razonSocialTransporte"].ToString();

        gvItemsFactura.DataSource = dtDatosFactura;
        gvItemsFactura.DataBind();
      }

      protected void btnSeleccionarArticulos_Click(object sender, EventArgs e)
      {
        Session["tablaNotaCredito"] = null;
        Session["tablaItemsNotaDeCredito"] = null;

        CargarGrillaItemsEntrega(true);
      }

      private void CargarGrillaItemsEntrega(bool isSeleccionar)
      {
        CargarItemsFacturas();

        var tablaNotaCredito = new DataTable();

        if (isSeleccionar)
        {
          tablaNotaCredito.Columns.Add("codigoItemEntrega");
          tablaNotaCredito.Columns.Add("codigoArticulo");
          tablaNotaCredito.Columns.Add("descripcionCorta");
          tablaNotaCredito.Columns.Add("cantidad");
          tablaNotaCredito.Columns.Add("codigoItemNotaDePedido");
          tablaNotaCredito.Columns.Add("precioUnitario");
          tablaNotaCredito.Columns.Add("precioTotal");
          tablaNotaCredito.Columns.Add("isEliminada");

          for (int i = 0; i < gvItemsFactura.VisibleRowCount; i++)
          {
            if (gvItemsFactura.Selection.IsRowSelected(i))
            {
              var mRow = (DataRowView)gvItemsFactura.GetRow(i);
              tablaNotaCredito.Rows.Add(mRow.Row.ItemArray[2], mRow.Row.ItemArray[3], mRow.Row.ItemArray[4], mRow.Row.ItemArray[5], mRow.Row.ItemArray[8], mRow.Row.ItemArray[14], mRow.Row.ItemArray[15], false);
            }
          }

          Session["tablaNotaCredito"] = tablaNotaCredito;

          //Tabla para el metodo insert
          var tablaItemsNotaDeCredito = new DataTable();

          tablaItemsNotaDeCredito.Columns.Add("codigoItemNotaDeCredito");
          tablaItemsNotaDeCredito.Columns.Add("cantidad");
          tablaItemsNotaDeCredito.Columns.Add("codigoItemEntrega");

          for (int i = 0; i < gvItemsFactura.VisibleRowCount; i++)
          {
            if (gvItemsFactura.Selection.IsRowSelected(i))
            {
              var mRow = (DataRowView)gvItemsFactura.GetRow(i);
              tablaItemsNotaDeCredito.Rows.Add(0, mRow.Row.ItemArray[5], mRow.Row.ItemArray[2]);
            }
          }

          Session["tablaItemsNotaDeCredito"] = tablaItemsNotaDeCredito;
        }

        gvItemsNotaDeCredito.DataSource = tablaNotaCredito;
        gvItemsNotaDeCredito.DataBind();
        UpdateImporte();
      }

      protected void btnEliminar_Click(object sender, EventArgs e)
      {

      }

      protected void btnUpdateImporte_Click(object sender, EventArgs e)
      {
        UpdateImporte();
      }

      private void UpdateImporte()
      {
        var dtNotaCredito = (DataTable)Session["tablaNotaCredito"];
        Double subtotal = 0;

        for (int i = 0; i < dtNotaCredito.Rows.Count; i++)
        {
          subtotal = subtotal + Convert.ToDouble(dtNotaCredito.Rows[i]["precioTotal"].ToString());
        }

        var codigoPuntoDeVenta = Convert.ToInt32(((DataTable)Session["puntoDeVenta"]).Rows[0]["codigoPuntoDeVenta"]);
        var codigoTipoComprobante = Convert.ToInt32(ControladorGeneral.RecuperarPuntosDeVentaPorCodigo(codigoPuntoDeVenta).Rows[0]["codigoTipoComprobante"]);

        txtSubtotal.Text = Convert.ToString((double)decimal.Round((decimal)subtotal, 2));
        cbCondicionIVA.Visible = codigoTipoComprobante == 3;
        txtImporteIVA.Visible = cbCondicionIVA.Visible;
        txtImporteIVA.Text = Convert.ToString((double)decimal.Round((decimal)(subtotal * 0.21), 2));
        txtTotal.Text = codigoTipoComprobante == 3 ? Convert.ToString((double)decimal.Round((decimal)(subtotal * 1.21), 2)) : Convert.ToString((double)decimal.Round((decimal)(subtotal), 2));
      }

      protected void gvItemsNotaDeCredito_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
      {
        var tablaDatosFactura = (DataTable)Session["dtDatosFactura"];
        var tablaDatosNotaDeCredito = (DataTable)Session["tablaNotaCredito"];
        var codigoItemNotaPedido = Convert.ToInt32(e.Keys["codigoItemEntrega"]);
        var fila = (from t in tablaDatosFactura.AsEnumerable() where Convert.ToInt32(t["codigoItemEntrega"]) == codigoItemNotaPedido select t).SingleOrDefault();
        var filaNC = (from t in tablaDatosNotaDeCredito.AsEnumerable() where Convert.ToInt32(t["codigoItemEntrega"]) == codigoItemNotaPedido select t).SingleOrDefault();
        var cantidad = Convert.ToInt32(fila.ItemArray[5]);

        if (cantidad != Convert.ToInt32(e.NewValues["cantidad"]))
        {
          fila["cantidad"] = Convert.ToInt32(e.NewValues["cantidad"]);
          filaNC["cantidad"] = Convert.ToInt32(e.NewValues["cantidad"]);
          cantidad = Convert.ToInt32(e.NewValues["cantidad"]);
        }

        if (Convert.ToDouble(fila["precioTotal"]) != Convert.ToDouble(e.NewValues["precioTotal"]))
        {
          fila["precioTotal"] = Convert.ToDouble(e.NewValues["precioTotal"]);
          filaNC["precioTotal"] = Convert.ToDouble(e.NewValues["precioTotal"]);
          fila["precioUnitario"] = Math.Round(Convert.ToDouble(e.NewValues["precioTotal"]) / cantidad, 2);
          filaNC["precioUnitario"] = Math.Round(Convert.ToDouble(e.NewValues["precioTotal"]) / cantidad, 2);
        }
        else
        {
          fila["precioUnitario"] = Convert.ToDouble(e.NewValues["precioUnitario"]);
          filaNC["precioUnitario"] = Convert.ToDouble(e.NewValues["precioUnitario"]);
          fila["precioTotal"] = cantidad * Convert.ToDouble(e.NewValues["precioUnitario"]);
          filaNC["precioTotal"] = cantidad * Convert.ToDouble(e.NewValues["precioUnitario"]);
        }

        Session["dtDatosFactura"] = tablaDatosFactura;
        Session["tablaNotaCredito"] = tablaDatosNotaDeCredito;
        e.Cancel = true;
        gvItemsNotaDeCredito.CancelEdit();
        gvItemsNotaDeCredito.DataSource = tablaDatosFactura;
        gvItemsNotaDeCredito.DataBind();

        this.UpdateImporte();
      }

      protected void btnEmitir_Click(object sender, EventArgs e)
      {
        if (cbFactura.Text == string.Empty || cbCondicionIVA.SelectedIndex < 0 || txtTotal.Text.Trim() == string.Empty)
        {
          lblError.Text = "Debe completar todos los campos y elegir una factura.";
          pcError.ShowOnPageLoad = true;
        }
        else
        {
          var tablaNotaCredito = (DataTable)Session["tablaNotaCredito"];
          if (tablaNotaCredito != null)
          {
            var datosFacturaActual = (DataTable)Session["dtFacturaActual"];
            var dtDatosFactura = (DataTable)Session["dtDatosFactura"];
            gvDetalleNotaDeCredito.DataSource = tablaNotaCredito;
            gvDetalleNotaDeCredito.DataBind();

            lblNroFacturaAEmitir.Text = string.Format("{0} - {1}", (Convert.ToInt32(datosFacturaActual.Rows[0]["numeroPuntoDeVenta"])).ToString("D4"), (Convert.ToInt32(txtNotaCredito.Value)).ToString("D8"));
            lblCondicionVenta.Text = txtCondicionVenta.Text;
            lblLocalidad.Text = Convert.ToString(dtDatosFactura.Rows[0]["localidadCliente"]);
            lblDomicilio.Text = Convert.ToString(dtDatosFactura.Rows[0]["direccionCliente"]);
            lblNombreApellidoCliente.Text = txtRazonSocial.Text;
            lblNroRemitos.Text = txtCodigoRemito.Text;
            lblNumeroDocumento.Text = txtNroDocumento.Text;
            lblFechaVencimientoCAE.Text = "NO FACTURADO";
            lblNroCAE.Text = "NO FACTURADO";
            lblSubtotal.Text = txtSubtotal.Text;
            lblImporteIVA.Text = txtImporteIVA.Text;
          lblImporteIVA.Visible = txtImporteIVA.Visible;
            lblImporteTotal.Text = txtTotal.Text;
            lblCotizacion.Text = txtCotizacion.Text;
            lblTipoMoneda.Text = txtTipoMoneda.Text;

            pcValidarComprobante.ShowOnPageLoad = true;
          }
        }
      }

      protected void btnEmitirComprobante_Click(object sender, EventArgs e)
      {
        /*bool isFacturaCompleta = false;
        if (gvItemsFactura.VisibleRowCount == gvItemsNotaDeCredito.VisibleRowCount)
            isFacturaCompleta = true;
        */
        var itemsNotaDeCredito = (DataTable)Session["tablaItemsNotaDeCredito"];
        var dtFacturaActual = (DataTable)Session["dtFacturaActual"];
        var codigoPuntoDeVenta = Convert.ToInt32(((DataTable)Session["puntoDeVenta"]).Rows[0]["codigoPuntoDeVenta"]);
        pcValidarComprobante.ShowOnPageLoad = false;

        if (gvItemsFactura.VisibleRowCount == gvItemsNotaDeCredito.VisibleRowCount)
        {
          ControladorGeneral.InsertarActualizarNotaDeCreditoCompleta(0, codigoPuntoDeVenta, Convert.ToInt32(txtNotaCredito.Text), Convert.ToInt32(dtFacturaActual.Rows[0]["codigoFactura"].ToString()), Convert.ToDouble(txtTotal.Text), Convert.ToDouble(txtSubtotal.Text),
          Convert.ToDateTime(txtFechaEmision.Text), 3, Convert.ToInt32(dtFacturaActual.Rows[0]["codigoEntrega"].ToString()));
        }
        else
        {
          ControladorGeneral.InsertarActualizarNotaDeCreditoIncompleta(0, codigoPuntoDeVenta, Convert.ToInt32(txtNotaCredito.Text), Convert.ToInt32(dtFacturaActual.Rows[0]["codigoFactura"].ToString()), Convert.ToDouble(txtTotal.Text), Convert.ToDouble(txtSubtotal.Text),
          Convert.ToDateTime(txtFechaEmision.Text), 3,itemsNotaDeCredito);
        }

        //Obtengo ultimo codigo de factura y emito la factura
        var tablaUltimaNotaDeCredito = ControladorGeneral.RecuperarUltimaNotaDeCredito();
        var codigoNotaDeCredito = tablaUltimaNotaDeCredito.Rows.Count > 0 ? (Convert.ToInt32(tablaUltimaNotaDeCredito.Rows[0]["codigoNotaDeCredito"])).ToString() : string.Empty;

        try
        {
          var status = ControladorGeneral.EmitirNotaDeCredito(Convert.ToInt32(codigoNotaDeCredito));
          pcError.HeaderText = "Nota de Credito Emitida";
          lblError.Text = status;
          pcError.ShowOnPageLoad = true;
          Response.Redirect(string.Format("listado.aspx?codigoPuntoDeVenta={0}", codigoPuntoDeVenta.ToString()));
        }
        catch
        {
          pcError.HeaderText = "Error";
          lblError.Text = "Ha ocurrido un error. No hay conexion con los servidor de AFIP, vuelva a intentar.";
          pcError.ShowOnPageLoad = true;
        }
      }
    }
}