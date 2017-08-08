using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.ClasesComplementarias;
using BibliotecaSCF.Controladores;
using DevExpress.Web.ASPxGridView;

namespace SCF.facturas
{
  public partial class factura : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      txtFechaFacturacion.Value = DateTime.Now;
      CargarComboRemito();
      CargarComboTipoComprobante();
      CargarComboConcepto();
      CargarComboTipoMoneda();

      if (!IsPostBack)
      {
        CargarPuntoDeVenta();
      }
    }

    private int RetornarPuntoDeVenta()
    {
      var codigoTipoComprobante = Convert.ToInt32(cbTipoComprobante.SelectedItem.Value);
      var dataRow = ((DataTable)Session["PuntoDeVenta"]).AsEnumerable().FirstOrDefault(x => Convert.ToInt32(x["codigoTipoComprobante"]) == codigoTipoComprobante);

      if (dataRow == null)
      {
        lblError.Text = "Debe seleccionar el tipo de comprobante";
        pcError.ShowOnPageLoad = true;
        return -1;
      }

      var codigoPuntoDeVenta = Convert.ToInt32(dataRow["codigoPuntoDeVenta"]);
      var numeroPuntoDeVenta = Convert.ToInt32(dataRow["numeroPuntoDeVenta"]);

      txtPuntoDeVenta.Text = string.Format("{0} ({1})", numeroPuntoDeVenta, dataRow["descripcion"]);
      txtSubtotal.Visible = codigoTipoComprobante == 1;
      cbCondicionIVA.Visible = codigoTipoComprobante == 1;
      txtImporteIVA.Visible = codigoTipoComprobante == 1;
      lblImporteIVA.Visible = codigoTipoComprobante == 1;
      lblSubtotal.Visible = codigoTipoComprobante == 1;

      lblPuntoDeVenta.Text = Convert.ToString(numeroPuntoDeVenta);
      lblTextoTipoComprabante.Text = string.Format("Tipo de Comprobante: Factura Tipo {0}", codigoTipoComprobante == 1 ? "A" : "B");

      return codigoPuntoDeVenta;
    }

    private void CarCargarNumeroDeFactura(int codigoPuntoDeVenta)
    {
      //Obtengo el Ultimo numero de factura y le sumo 1.
      var tablaUltimaFactura = ControladorGeneral.RecuperarUltimaFactura(codigoPuntoDeVenta);
      txtNroFactura.Value = tablaUltimaFactura.Rows.Count > 0 ? (Convert.ToInt32(tablaUltimaFactura.Rows[0]["numeroFactura"]) + 1).ToString() : "1";
    }

    private void CargarPuntoDeVenta()
    {
      var puntoDeVentaRemito = Convert.ToInt32(((DataTable)Session["PuntoDeVenta"]).Rows[0]["codigoPuntoDeVentaParent"]);
      var tablaPuntoDeVenta = ControladorGeneral.RecuperarPuntosDeVentaPorCodigoSuperior(puntoDeVentaRemito);

      if (tablaPuntoDeVenta.Rows.Count > 0)
      {
        Session["PuntoDeVenta"] = tablaPuntoDeVenta;
      }
    }

    private void CargarComboTipoMoneda()
    {
      cbTipoMoneda.DataSource = ControladorGeneral.RecuperarTodasMonedas();
      cbTipoMoneda.DataBind();
    }

    private void CargarComboConcepto()
    {
      cbConcepto.DataSource = ControladorGeneral.RecuperarTodosConceptos();
      cbConcepto.DataBind();
    }

    private void CargarComboTipoComprobante()
    {
      cbTipoComprobante.DataSource = ControladorGeneral.RecuperarTiposDeFactura();
      cbTipoComprobante.DataBind();
    }

    private void CargarComboRemito()
    {
      var codigoPuntoDeVenta = Convert.ToInt32(((DataTable)Session["puntoDeVenta"]).Rows[0]["codigoPuntoDeVentaParent"]);
      gluRemito.DataSource = ControladorGeneral.RecuperarEntregaPorPuntoDeVenta(codigoPuntoDeVenta);
      gluRemito.DataBind();
    }

    //Retorna el ultimo comprobante autorizado para el tipo de comprobante / cuit / punto de venta ingresado/ Tipo de Emisión
    //Enviar CUIT,PtoVta,CbteTipo
    protected void btnUltimoNroComprobante_Click(object sender, EventArgs e)
    {
      try
      {
        if (Session["PuntoDeVenta"] != null && cbTipoComprobante.SelectedIndex >= 0)
        {
          this.RetornarPuntoDeVenta();
          lblUltimoNroComprobante.Text = Convert.ToString(ControladorGeneral.ConsultarUltimoNroComprobante(Convert.ToInt32(lblPuntoDeVenta.Text), Convert.ToInt32(cbTipoComprobante.SelectedItem.Value)));
          pcUltimoComprobanteAfip.ShowOnPageLoad = true;
        }
        else
        {
          lblError.Text = "Debe seleccionar el tipo de comprobante";
          pcError.ShowOnPageLoad = true;
        }
      }
      catch(Exception ex)
      {
        lblError.Text = "Ha ocurrido un error. No hay conexion con los servidor de AFIP, vuelva a intentar.";
        pcError.ShowOnPageLoad = true;
      }
    }

    protected void btnEmitir_Click(object sender, EventArgs e)
    {
      if (txtFechaFacturacion.Value.ToString() == "" || cbConcepto.SelectedIndex < 0 || cbCondicionIVA.SelectedIndex < 0 || cbCondicionVenta.SelectedIndex < 0 ||
          cbTipoComprobante.SelectedIndex < 0 || cbTipoMoneda.SelectedIndex < 0 || gluRemito.Text == "")
      {
        lblError.Text = "Debe completar todos los campos y elegir al menos un remito";
        pcError.ShowOnPageLoad = true;
      }
      else
      {
        var dtItemsFacturaActual = (DataTable)Session["dtItemsFacturaActual"];

        if (dtItemsFacturaActual != null)
        {
          this.RetornarPuntoDeVenta();  
          var puntoDeVenta = Convert.ToInt32(lblPuntoDeVenta.Text);
          var numeroDeFactura = Convert.ToInt32(txtNroFactura.Value);
          gvDetalleFactura.DataSource = dtItemsFacturaActual;
          gvDetalleFactura.DataBind();

          lblNroFacturaAEmitir.Text = string.Format("{0} - {1}", puntoDeVenta.ToString("D4"), numeroDeFactura.ToString("D8"));
          lblCondicionVenta.Text = cbCondicionVenta.Text;
          lblLocalidad.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["localidadCliente"]);
          lblDomicilio.Text = Convert.ToString(dtItemsFacturaActual.Rows[0]["direccionCliente"]);
          lblNombreApellidoCliente.Text = txtRazonSocial.Text;
          lblNroRemitos.Text = gluRemito.Text;
          lblNumeroDocumento.Text = txtNroDocumento.Text;
          lblFechaVencimientoCAE.Text = "NO FACTURADO";
          lblNroCAE.Text = "NO FACTURADO";
          lblSubtotal.Text = txtSubtotal.Text;
          lblImporteIVA.Text = txtImporteIVA.Text;
          lblImporteTotal.Text = txtTotal.Text;
          lblCotizacion.Text = txtCotizacion.Text;
          lblTipoMoneda.Text = cbTipoMoneda.Text;

          pcValidarComprobante.ShowOnPageLoad = true;
        }
      }
    }

    protected void btnEmitirComprobante_Click(object sender, EventArgs e)
    {
      pcValidarComprobante.ShowOnPageLoad = false;

      var arrayListRemitos = (List<object>)Session["listRemitos"];
      var codigoRemitos = new List<int>();
      var codigoTipoComprobante = Convert.ToInt32(cbTipoComprobante.SelectedItem.Value);
      var dataRow = ((DataTable)Session["PuntoDeVenta"]).AsEnumerable().FirstOrDefault(x => Convert.ToInt32(x["codigoTipoComprobante"]) == codigoTipoComprobante);
      var codigoPuntoDeVenta = Convert.ToInt32(dataRow["codigoPuntoDeVenta"]);
      
      foreach (object[] items in arrayListRemitos)
      {
        codigoRemitos.Add(Convert.ToInt32(items[0].ToString()));
      }

      var tablaItemsEntrega = new DataTable();
      tablaItemsEntrega.Columns.Add("codigoEntrega");
      tablaItemsEntrega.Columns.Add("codigoItemEntrega");
      tablaItemsEntrega.Columns.Add("precio");

      for (var i = 0; i < gvItemsFactura.VisibleRowCount; i++)
      {
        var row = tablaItemsEntrega.NewRow();
        row["codigoEntrega"] = gvItemsFactura.GetRowValues(i, "codigoEntrega");
        row["codigoItemEntrega"] = gvItemsFactura.GetRowValues(i, "codigoItemEntrega");
        row["precio"] = gvItemsFactura.GetRowValues(i, "precioUnitario");
        tablaItemsEntrega.Rows.Add(row); 
      }

      ControladorGeneral.InsertarActualizarFactura(0, codigoTipoComprobante, codigoPuntoDeVenta, Convert.ToInt32(txtNroFactura.Text), Convert.ToDateTime(txtFechaFacturacion.Text), codigoRemitos, Convert.ToInt32(cbTipoMoneda.Value), 
      Convert.ToInt32(cbConcepto.Value), Convert.ToInt32(cbCondicionIVA.Value), Convert.ToDouble(txtSubtotal.Text), Convert.ToDouble(txtTotal.Text), 
      Convert.ToString(cbCondicionVenta.Text), Convert.ToDouble(txtCotizacion.Text), tablaItemsEntrega);

      //Obtengo ultimo codigo de factura y emito la factura
      var tablaUltimaFactura = ControladorGeneral.RecuperarUltimaFactura(codigoPuntoDeVenta);
      var codigoFactura = tablaUltimaFactura.Rows.Count > 0 ? (Convert.ToInt32(tablaUltimaFactura.Rows[0]["codigoFactura"])).ToString() : string.Empty;
        
      try
      {
        var status = ControladorGeneral.EmitirFactura(Convert.ToInt32(codigoFactura));
        pcError.HeaderText = "Factura Emitida";
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

    protected void btnObtenerDatosRemito_Click(object sender, EventArgs e)
    {
      ObtenerDatosRemito();
    }

    protected void cbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Session["PuntoDeVenta"] != null && cbTipoComprobante.SelectedIndex >= 0)
      {
        var codigoPuntoDeVenta = this.RetornarPuntoDeVenta();
        this.CarCargarNumeroDeFactura(codigoPuntoDeVenta);
        this.ObtenerDatosRemito();
      }
    }

    private void ObtenerDatosRemito()
    {
      string[] myFields = { "codigoEntrega", "numeroRemito", "razonSocialCliente", "cuitCliente", "codigoSCF" };
      List<Object> nroRemitosActual = gluRemito.GridView.GetSelectedFieldValues(myFields);
      Session["listRemitos"] = nroRemitosActual;

      if (nroRemitosActual.Count > 0)
      {
        foreach (object[] item in nroRemitosActual)
        {
          txtRazonSocial.Text = item[2].ToString();
          txtNroDocumento.Text = item[3].ToString();
          txtCodigoConSCF.Text = item[4].ToString();
        }
      }

      CargarItemsDeLaFactura(nroRemitosActual);
    }

    private void CargarItemsDeLaFactura(List<object> nroRemitosActual)
    {
      var dtItemsFactura = new DataTable();
      
      foreach (object[] item in nroRemitosActual)
      {
        var dtToMerge = new DataTable();
        dtToMerge = ControladorGeneral.RecuperarItemsEntrega(Convert.ToInt32(item[0].ToString()));
        dtItemsFactura.Merge(dtToMerge);
      }

      gvItemsFactura.DataSource = dtItemsFactura;
      gvItemsFactura.DataBind();

      Session["dtItemsEntregaActual"] = dtItemsFactura;
      this.CalcularPrecioItems(dtItemsFactura);
      //Session["dtItemsFacturaActual"] = dtItemsFactura;

      //CalcularImporteTotal();
    }

    private void CalcularImporteTotal()
    {
      var dtItemsFacturaActual = (DataTable)Session["dtItemsFacturaActual"];
      var subtotal = 0.0;
      var total = 0.0;

      for (var i = 0; i < dtItemsFacturaActual.Rows.Count; i++)
      {
        subtotal = subtotal + Convert.ToDouble(dtItemsFacturaActual.Rows[i]["precioTotal"].ToString());
      }

      txtSubtotal.Text = Convert.ToString((double)decimal.Round((decimal)subtotal, 2));
      txtImporteIVA.Text = Convert.ToString((double)decimal.Round((decimal)(subtotal * 0.21), 2));
      total = (cbTipoComprobante.SelectedItem != null && cbTipoComprobante.SelectedIndex == 1) ? subtotal : (double)decimal.Round((decimal)(subtotal * 1.21), 2);
      txtTotal.Text = Convert.ToString(total);
    }

    private void CalcularPrecioItems(DataTable itemsFactura)
    {
      if (cbTipoComprobante.SelectedItem != null && cbTipoComprobante.SelectedIndex == 1)
      {
        foreach (DataRow row in itemsFactura.Rows)
        {
          row["precioUnitario"] = decimal.Round(Convert.ToDecimal(Convert.ToDouble(row["precioUnitario"]) * 1.21), 2);
          row["precioTotal"] = decimal.Round(Convert.ToDecimal(Convert.ToDouble(row["precioTotal"]) * 1.21), 2);
        }

        gvItemsFactura.DataSource = itemsFactura;
        gvItemsFactura.DataBind();
      }

      Session["dtItemsFacturaActual"] = itemsFactura;
      CalcularImporteTotal();
    }

    protected void gvItemsFactura_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {

      var tablaItemFactura = (DataTable)Session["dtItemsFacturaActual"];
      var codigoItemNotaPedido = Convert.ToInt32(e.Keys["codigoItemEntrega"]);
            
      var fila = (from t in tablaItemFactura.AsEnumerable() where Convert.ToInt32(t["codigoItemEntrega"]) == codigoItemNotaPedido select t).SingleOrDefault();
      var cantidad = Convert.ToInt32(fila.ItemArray[4]);

      if (Convert.ToDouble(fila["precioUnitario"]) != Convert.ToDouble(e.NewValues["precioUnitario"]))
      {
          fila["precioUnitario"] = Convert.ToDouble(e.NewValues["precioUnitario"]);
          fila["precioTotal"] = Convert.ToInt32(fila.ItemArray[4]) * Convert.ToDouble(e.NewValues["precioUnitario"]);
      }
      else
      {
          fila["precioTotal"] = Convert.ToDouble(e.NewValues["precioTotal"]);
          fila["precioUnitario"] = Math.Round(Convert.ToDouble(e.NewValues["precioTotal"]) / Convert.ToInt32(fila.ItemArray[4]),2);
      }
                        
      Session["dtItemsFacturaActual"] = tablaItemFactura;

      e.Cancel = true;
      gvItemsFactura.CancelEdit();
      gvItemsFactura.DataSource = tablaItemFactura;
      gvItemsFactura.DataBind();

      CalcularImporteTotal();
    }

    protected void txtCotizacion_TextChanged(object sender, EventArgs e)
    {
      CalcularImporteTotal();
    }

    protected void btnUpdateImporte_Click(object sender, EventArgs e)
    {
      CalcularImporteTotal();
    }
  }
}