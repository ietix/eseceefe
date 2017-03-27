using System;
using BibliotecaSCF.Controladores;
using System.Data;
using System.Drawing;
using BibliotecaSCF.ClasesComplementarias;

namespace SCF.config
{
  using BibliotecaSCF.Clases;

  public partial class listado : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      loadGridPuntosDeVenta();
    }

    private void loadGridPuntosDeVenta()
    {
      gvPuntosDeVenta.DataSource = ControladorGeneral.RecuperarTodosPuntosDeVenta();
      gvPuntosDeVenta.DataBind();
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
      NuevoPuntoDeVenta();
    }

    private void NuevoPuntoDeVenta()
    {
      Session["puntoDeVentaActual"] = null;
      Response.Redirect("punto_venta.aspx");
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
      EditarPuntoDeVenta();
    }

    private void EditarPuntoDeVenta()
    {
      var puntoDeVenta = new PuntosDeVenta();

      puntoDeVenta.Codigo = Convert.ToInt32(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "codigoPuntoDeVenta"));
      puntoDeVenta.Cai = Convert.ToString(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "cai"));
      puntoDeVenta.Descripcion = Convert.ToString(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "descripcion"));
      puntoDeVenta.Numero = Convert.ToInt32(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "numeroPuntoDeVenta"));
      puntoDeVenta.NumeroActual = Convert.ToInt32(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "numeroActual"));
      puntoDeVenta.NumeroFinal = Convert.ToInt32(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "numeroFinal"));
      puntoDeVenta.NumeroInicial = Convert.ToInt32(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "numeroInicial"));
      puntoDeVenta.VencimientoCai = Convert.ToDateTime(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "vencimientoCai"));
      puntoDeVenta.TipoComprobante = new TipoComprobante();
      puntoDeVenta.TipoComprobante.Codigo = Convert.ToInt32(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "codigoTipoComprobante"));
      puntoDeVenta.TipoComprobante.Descripcion = Convert.ToString(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "descripcionTipoComprobante"));
      puntoDeVenta.PuntoDeVentaSuperior = new PuntosDeVenta();
      puntoDeVenta.PuntoDeVentaSuperior.Codigo = Convert.ToInt32(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "codigoPuntoDeVentaParent"));
        
      Session["puntoDeVentaActual"] = puntoDeVenta;

      Response.Redirect("punto_venta.aspx");
    }

    protected void btnAceptarEliminarPuntoDeVenta_Click(object sender, EventArgs e)
    {
      if (gvPuntosDeVenta.FocusedRowIndex != -1)
      {
        pcConfirmarEliminarPuntoDeVenta.ShowOnPageLoad = false;
        try
        {
          ControladorGeneral.EliminarPuntoDeVenta(int.Parse(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "codigoPuntoDeVenta").ToString()));
          Response.Redirect("listado.aspx");
        }
        catch(Exception ex)
        {
          lblMensaje.Text = "No se pudo eliminar el punto de venta\n" + ex.Message;
          pcMensaje.ShowOnPageLoad = true;
        }
      }
    }

    protected void btnVerDetalle_Click(object sender, EventArgs e)
    {
      pcShowDetallePuntoDeVenta.ShowOnPageLoad = true;

      txtCodigoPuntoDeVenta.Text = string.Format("000{0}", gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "codigoPuntoDeVenta"));
      txtNumeroPuntoDeVenta.Text = string.Format("000{0}", gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "numeroPuntoDeVenta"));
      txtDescripcion.Text = Convert.ToString(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "descripcion"));
      txtTipoComprobante.Text = Convert.ToString(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "descripcionTipoComprobante"));
      txtPuntoVentaSuperior.Text = Convert.ToString(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "descripcionPuntoDeVentaParent"));
      txtCai.Text = Convert.ToString(gvPuntosDeVenta.GetRowValues(gvPuntosDeVenta.FocusedRowIndex, "cai"));
    }

    protected void gvPuntosDeVenta_CellEditorInitialize(object sender, EventArgs e)
    {

    }

    protected void gvPuntosDeVenta_HtmlRowPrepared(object sender, EventArgs e)
    {

    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
           
    }
  }
}