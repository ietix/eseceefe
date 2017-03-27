using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;

namespace SCF.config
{
  using System.Data.SqlTypes;

  using BibliotecaSCF.Clases;

  public partial class puntoDeVenta : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      CargarComboTipoComprobante();
      CargarComboPuntoDeVentaParent();

      if (!IsPostBack)
      {
        if ((PuntosDeVenta)Session["puntoDeVentaActual"] != null)
        {
          CargarDatosParaEditar((PuntosDeVenta)Session["puntoDeVentaActual"]);
        }
      }
    }

    private void CargarComboTipoComprobante()
    {
      cbTipoComprobante.DataSource = ControladorGeneral.RecuperarTodosTipoComprobantes();
      cbTipoComprobante.DataBind();
    }

    private void CargarComboPuntoDeVentaParent()
    {
      cbPuntoDeVentaParent.DataSource = ControladorGeneral.RecuperarTodosPuntosDeVenta();
      cbPuntoDeVentaParent.DataBind();
    }

    private void CargarDatosParaEditar(PuntosDeVenta puntoDeVenta)
    {
      if (puntoDeVenta.PuntoDeVentaSuperior != null)
      {
        cbPuntoDeVentaParent.SelectedItem = cbPuntoDeVentaParent.Items.FindByValue(puntoDeVenta.PuntoDeVentaSuperior.Codigo); 
      }

      if (puntoDeVenta.TipoComprobante != null)
      {
        cbTipoComprobante.SelectedItem = cbTipoComprobante.Items.FindByValue(puntoDeVenta.TipoComprobante.Codigo);
      }

      txtCodigo.Value = Convert.ToString(puntoDeVenta.Codigo);
      txtNumero.Value = Convert.ToString(puntoDeVenta.Numero);
      txtDescripcion.Value = puntoDeVenta.Descripcion;
      txtNroInicial.Value = Convert.ToString(puntoDeVenta.NumeroInicial);
      txtNroFinal.Value = Convert.ToString(puntoDeVenta.NumeroFinal);
      txtNroActual.Value = Convert.ToString(puntoDeVenta.NumeroActual);
      txtCai.Value = puntoDeVenta.Cai;
      deFechaVencimiento.Value = puntoDeVenta.VencimientoCai;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
      var codigoPuntoDeVentaSuperior = cbPuntoDeVentaParent.SelectedItem == null ? (int?)null : Convert.ToInt32(cbPuntoDeVentaParent.SelectedItem.Value);
      var codigoTipoComprobante = cbTipoComprobante.SelectedItem == null ? (int?)null : Convert.ToInt32(cbTipoComprobante.SelectedItem.Value);
      var numeroInicial = txtNroInicial.Value == null ? (int?)null : Convert.ToInt32(txtNroInicial.Value);
      var numeroFinal = txtNroFinal.Value == null ? (int?)null : Convert.ToInt32(txtNroFinal.Value);
      var numeroActual = txtNroActual.Value == null ? (int?)null : Convert.ToInt32(txtNroActual.Value);
      var vencimientoCai = deFechaVencimiento.Value == null ? DateTime.Parse("1900-01-01 00:00:00") : Convert.ToDateTime(deFechaVencimiento.Value);

      var codigoPuntaDeVenta = 0;

      if (Session["puntoDeVentaActual"] != null)
      {
        codigoPuntaDeVenta = ((PuntosDeVenta)Session["puntoDeVentaActual"]).Codigo;
      }

      ControladorGeneral.InsertarActualizarPuntoDeVenta(codigoPuntaDeVenta, Convert.ToInt32(txtNumero.Value), txtDescripcion.Value, txtCai.Value, vencimientoCai, codigoPuntoDeVentaSuperior, codigoTipoComprobante, numeroInicial, numeroFinal, numeroActual);

      Response.Redirect("listado.aspx");
    }
  }
}