using BibliotecaSCF.Clases;
using System;

namespace SCF.comprobantes
{
  using System.Data;

  using BibliotecaSCF.Controladores;

  using DevExpress.Web.ASPxEditors;

  public partial class comprobante : System.Web.UI.Page
  {
    private DataTable tablaPuntosDeVenta;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        if ((Reporte)Session["ComprobanteActual"] != null)
        {
          CargarDatosParaEditar((Reporte)Session["ComprobanteActual"]);
        }
        else
        {
          tablaPuntosDeVenta = new DataTable();
          Session["PuntoDeVentaAgregar"] = null;
        }
      }
    }

    private void CargarDatosParaEditar(Reporte puntoDeVenta)
    {
      //if (puntoDeVenta.PuntoDeVentaSuperior != null)
      //{
      //  cbPuntoDeVentaParent.SelectedItem = cbPuntoDeVentaParent.Items.FindByValue(puntoDeVenta.PuntoDeVentaSuperior.Codigo); 
      //}

      //if (puntoDeVenta.TipoComprobante != null)
      //{
      //  cbTipoComprobante.SelectedItem = cbTipoComprobante.Items.FindByValue(puntoDeVenta.TipoComprobante.Codigo);
      //}

      //txtCodigo.Value = Convert.ToString(puntoDeVenta.Codigo);
      //txtNumero.Value = Convert.ToString(puntoDeVenta.Numero);
      //txtDescripcion.Value = puntoDeVenta.Descripcion;
      //txtNroInicial.Value = Convert.ToString(puntoDeVenta.NumeroInicial);
      //txtNroFinal.Value = Convert.ToString(puntoDeVenta.NumeroFinal);
      //txtNroActual.Value = Convert.ToString(puntoDeVenta.NumeroActual);
      //txtCai.Value = puntoDeVenta.Cai;
      //deFechaVencimiento.Value = puntoDeVenta.VencimientoCai;
    }

    private void CargarComboPuntoDeVenta()
    {
      cbPuntoDeVenta.DataSource = ControladorGeneral.RecuperarTodosPuntosDeVenta();
      cbPuntoDeVenta.DataBind();
    }

    protected void pcPickPuntoDeVenta_Load(object sender, EventArgs e)
    {
      this.CargarComboPuntoDeVenta();
    }

    protected void cbPuntoDeVenta_OnValueChanged(object sender, EventArgs e)
    {
      Session["PuntoDeVentaAgregar"] = cbPuntoDeVenta.SelectedItem.Value;
    }

    protected void btnAsociarPuntoDeVenta_Click(object sender, EventArgs e)
    {
      if (cbPuntoDeVenta.Text != null)
      {
        var puntoDeVenta = ControladorGeneral.RecuperarPuntosDeVentaPorCodigo(Convert.ToInt32(Session["PuntoDeVentaAgregar"]));

        if ((Reporte)Session["ComprobanteActual"] != null)
        {

        }
        else
        {
          var dataRow = tablaPuntosDeVenta.Rows[0];

          tablaPuntosDeVenta.Rows.Add(dataRow);
          gvPuntosDeVenta.DataSource = tablaPuntosDeVenta;
          gvPuntosDeVenta.DataBind();
 
        }
      }
    }

    protected void btnAceptarDisociarPuntoDeVenta_Click(object sender, EventArgs e)
    {
    }

    protected void gvPuntosDeVenta_HtmlRowPrepared(object sender, EventArgs e)
    {
    }

    protected void gvPuntosDeVenta_CellEditorInitialize(object sender, EventArgs e)
    {
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
      //var codigoPuntoDeVentaSuperior = cbPuntoDeVentaParent.SelectedItem == null ? (int?)null : Convert.ToInt32(cbPuntoDeVentaParent.SelectedItem.Value);
      //var codigoTipoComprobante = cbTipoComprobante.SelectedItem == null ? (int?)null : Convert.ToInt32(cbTipoComprobante.SelectedItem.Value);
      //var numeroInicial = txtNroInicial.Value == null ? (int?)null : Convert.ToInt32(txtNroInicial.Value);
      //var numeroFinal = txtNroFinal.Value == null ? (int?)null : Convert.ToInt32(txtNroFinal.Value);
      //var numeroActual = txtNroActual.Value == null ? (int?)null : Convert.ToInt32(txtNroActual.Value);
      //var vencimientoCai = deFechaVencimiento.Value == null ? DateTime.Parse("1900-01-01 00:00:00") : Convert.ToDateTime(deFechaVencimiento.Value);

      //var codigoPuntaDeVenta = 0;

      //if (Session["puntoDeVentaActual"] != null)
      //{
      //  codigoPuntaDeVenta = ((PuntosDeVenta)Session["puntoDeVentaActual"]).Codigo;
      //}

      //ControladorGeneral.InsertarActualizarPuntoDeVenta(codigoPuntaDeVenta, Convert.ToInt32(txtNumero.Value), txtDescripcion.Value, txtCai.Value, vencimientoCai, codigoPuntoDeVentaSuperior, codigoTipoComprobante, numeroInicial, numeroFinal, numeroActual);

      //Response.Redirect("listado.aspx");
    }
  }
}