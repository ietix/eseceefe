using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;
using System.Web.Services;
using System.Drawing;

namespace SCF.remitos
{
    public partial class remito : System.Web.UI.Page
    {
      protected void Page_Load(object sender, EventArgs e)
      {
        cbTransporte.DataSource = ControladorGeneral.RecuperarTodosTransportes(false);
        cbTransporte.DataBind();

        if (!IsPostBack)
        {
          CargarGrillaItemsEntrega(false);
          txtFechaEmision.Value = DateTime.Now.Date;
          
          if (Session["tablaEntrega"] != null)
          {
            //cbNotaDePedido.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido(false);
            cbNotaDePedido.DataSource = ControladorGeneral.RecuperarNotasDePedidoActivas();
            cbNotaDePedido.DataBind();

            var tablaEntrega = (DataTable)Session["tablaEntrega"];
            txtPuntoDeVenta.Text = tablaEntrega.Rows[0]["numeroPuntoDeVenta"].ToString();
            txtCodigoRemito.Text = tablaEntrega.Rows[0]["numeroRemito"].ToString(); ;
            txtFechaEmision.Value = Convert.ToDateTime(tablaEntrega.Rows[0]["fechaEmision"]);
            txtObservacion.InnerText = tablaEntrega.Rows[0]["observaciones"].ToString();

            var codigoNotaDePedido = Convert.ToInt32(tablaEntrega.Rows[0]["codigoNotaDePedido"]);
            gvItemsNotaDePedido.DataSource = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);
            gvItemsNotaDePedido.DataBind();

            cbNotaDePedido.SelectedItem = cbNotaDePedido.Items.FindByValue(Convert.ToInt32(tablaEntrega.Rows[0]["codigoNotaDePedido"]));
            cbNotaDePedido.Value = Convert.ToInt32(tablaEntrega.Rows[0]["codigoNotaDePedido"]);
            cbTransporte.SelectedItem = cbTransporte.Items.FindByValue(Convert.ToInt32(tablaEntrega.Rows[0]["codigoTransporte"]));
            cbTransporte.Value = Convert.ToInt32(tablaEntrega.Rows[0]["codigoTransporte"]);

            var codigoEntrega = Convert.ToInt32(tablaEntrega.Rows[0]["codigoEntrega"]);
            var tablaItemsEntrega = ControladorGeneral.RecuperarItemsEntrega(codigoEntrega);
            tablaItemsEntrega.Columns.Add("isEliminada");
            gvItemsEntrega.DataSource = tablaItemsEntrega;
            gvItemsEntrega.DataBind();

            cbDireccion.DataSource = ControladorGeneral.RecuperarDireccionesPorNotaDePedido(codigoNotaDePedido);
            cbDireccion.DataBind();
            cbDireccion.SelectedItem = cbDireccion.Items.FindByValue(Convert.ToInt32(tablaEntrega.Rows[0]["codigoDireccion"]));

            Session["tablaItemsEntrega"] = tablaItemsEntrega;
          }
          else
          {
            var codigoPuntoDeVenta = Convert.ToInt32(((DataTable)Session["puntoDeVenta"]).Rows[0]["codigoPuntoDeVenta"]);
            txtPuntoDeVenta.Text = ((DataTable)Session["puntoDeVenta"]).Rows[0]["numeroPuntoDeVenta"].ToString();
            //cbNotaDePedido.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido(false);
            cbNotaDePedido.DataSource = ControladorGeneral.RecuperarNotasDePedidoActivas();
            cbNotaDePedido.DataBind();

            var tablaUltimaEntrega = ControladorGeneral.RecuperarUltimaEntrega(codigoPuntoDeVenta);
            txtCodigoRemito.Text = tablaUltimaEntrega.Rows.Count > 0 ? (Convert.ToInt32(tablaUltimaEntrega.Rows[0]["numeroRemito"]) + 1).ToString() : "1";
          }
        }
        else
        {
          if (Session["tablaEntrega"] != null)
          {
            //cbNotaDePedido.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido(false);
            cbNotaDePedido.DataSource = ControladorGeneral.RecuperarNotasDePedidoActivas();
            cbNotaDePedido.DataBind();

            var tablaEntrega = (DataTable)Session["tablaEntrega"];
            cbNotaDePedido.SelectedItem = cbNotaDePedido.Items.FindByValue(Convert.ToInt32(tablaEntrega.Rows[0]["codigoNotaDePedido"]));
            cbNotaDePedido.Value = Convert.ToInt32(tablaEntrega.Rows[0]["codigoNotaDePedido"]);
            //cbTransporte.SelectedItem = cbTransporte.Items.FindByValue(Convert.ToInt32(tablaEntrega.Rows[0]["codigoTransporte"]));
            //cbTransporte.Value = Convert.ToInt32(tablaEntrega.Rows[0]["codigoTransporte"]);

            cbDireccion.DataSource = ControladorGeneral.RecuperarDireccionesPorNotaDePedido(Convert.ToInt32(tablaEntrega.Rows[0]["codigoNotaDePedido"]));
            cbDireccion.DataBind();
            //cbDireccion.SelectedItem = cbDireccion.Items.FindByValue(Convert.ToInt32(tablaEntrega.Rows[0]["codigoDireccion"]));
          }
          else
          {
            //cbNotaDePedido.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido(false);
            cbNotaDePedido.DataSource = ControladorGeneral.RecuperarNotasDePedidoActivas();
            cbNotaDePedido.DataBind();

            if (cbNotaDePedido.SelectedItem != null)
            {
              var codigoNotaDePedido = Convert.ToInt32(cbNotaDePedido.SelectedItem.Value);
              cbDireccion.DataSource = ControladorGeneral.RecuperarDireccionesPorNotaDePedido(codigoNotaDePedido);
              cbDireccion.DataBind();
            }
          }
        }
      }

      protected void btnEliminar_Click(object sender, EventArgs e)
      {
        DataTable tablaItemsEntrega = (DataTable)Session["tablaItemsEntrega"];
        int codigoItemEntregaEliminado = Convert.ToInt32(gvItemsEntrega.GetRowValues(gvItemsEntrega.FocusedRowIndex, "codigoItemEntrega"));

        DataRow filaEliminada = (from t in tablaItemsEntrega.AsEnumerable() where Convert.ToInt32(t["codigoItemEntrega"]) == codigoItemEntregaEliminado select t).SingleOrDefault();

        if (codigoItemEntregaEliminado < 1)
        {
          tablaItemsEntrega.Rows.Remove(filaEliminada);
        }
        else
        {
          bool isEliminada = Convert.IsDBNull(filaEliminada["isEliminada"]) ? false : Convert.ToBoolean(filaEliminada["isEliminada"]);
          if (isEliminada)
          {
            filaEliminada["isEliminada"] = false;
          }
          else
          {
            filaEliminada["isEliminada"] = true;
          }
        }

        Session["tablaItemsEntrega"] = tablaItemsEntrega;
        CargarGrillaItemsEntrega(false);
      }

      protected void btnSeleccionarArticulos_Click(object sender, EventArgs e)
      {
        var tablaItemsEntrega = (DataTable)Session["tablaItemsEntrega"];
        CargarGrillaItemsEntrega(true);
      }

      private void CargarGrillaItemsEntrega(bool isSeleccionar)
      {
        CargarGrillaItemsNotaDePedido();
        var tablaItemsEntrega = new DataTable();

        if (Session["tablaItemsEntrega"] == null)
        {
          tablaItemsEntrega.Columns.Add("codigoItemEntrega");
          tablaItemsEntrega.Columns.Add("codigoArticulo");
          tablaItemsEntrega.Columns.Add("descripcionCorta");
          tablaItemsEntrega.Columns.Add("cantidad");
          tablaItemsEntrega.Columns.Add("codigoProveedor");
          tablaItemsEntrega.Columns.Add("razonSocialProveedor");
          tablaItemsEntrega.Columns.Add("codigoItemNotaDePedido");
          tablaItemsEntrega.Columns.Add("isEliminada");

          if (Session["tablaEntrega"] != null)
          {
            var codigoEntrega = Convert.ToInt32(((DataTable)Session["tablaEntrega"]).Rows[0]["codigoEntrega"]);
            var tablaItemsEntregaActual = ControladorGeneral.RecuperarItemsEntrega(codigoEntrega);
            tablaItemsEntregaActual.Columns.Add("isEliminada");

            tablaItemsEntrega = tablaItemsEntregaActual.Copy();
          }

          for (var i = 0; i < gvItemsNotaDePedido.VisibleRowCount; i++)
          {
            if (gvItemsNotaDePedido.Selection.IsRowSelected(i))
            {
              var dataRow = (DataRowView)gvItemsNotaDePedido.GetRow(i);
              tablaItemsEntrega.Rows.Add(-i, dataRow.Row.ItemArray[1], dataRow.Row.ItemArray[2], 1, 0, string.Empty, dataRow.Row.ItemArray[0], false);
            }
          }

          Session["tablaItemsEntrega"] = tablaItemsEntrega;
        }
        else
        {
          tablaItemsEntrega = (DataTable)Session["tablaItemsEntrega"];

          if (isSeleccionar)
          {
            for (var i = 0; i < gvItemsNotaDePedido.VisibleRowCount; i++)
            {
              if (gvItemsNotaDePedido.Selection.IsRowSelected(i))
              {
                var dataRow = (DataRowView)gvItemsNotaDePedido.GetRow(i);
                var codigoItemNotaDePedido = Convert.ToInt32(dataRow.Row.ItemArray[0]);
                var filaRepetida = (from t in tablaItemsEntrega.AsEnumerable() where Convert.ToInt32(t["codigoItemNotaDePedido"]) == codigoItemNotaDePedido select t).SingleOrDefault();

                if (filaRepetida == null)
                {
                  var newDataRow = tablaItemsEntrega.NewRow();
                  newDataRow["codigoItemEntrega"] = -i;
                  newDataRow["codigoArticulo"] = dataRow.Row.ItemArray[1];
                  newDataRow["descripcionCorta"] = dataRow.Row.ItemArray[2];
                  newDataRow["cantidad"] = 1;
                  newDataRow["codigoProveedor"] = 0;
                  newDataRow["razonSocialProveedor"] = string.Empty;
                  newDataRow["codigoItemNotaDePedido"] = dataRow.Row.ItemArray[0];
                  newDataRow["isEliminada"] = false;
                  tablaItemsEntrega.Rows.Add(newDataRow);
                }
              }
            }
          }
        }

        gvItemsEntrega.DataSource = tablaItemsEntrega;
        gvItemsEntrega.DataBind();
      }

      protected void btnGuardar_Click(object sender, EventArgs e)
      {
        var tablaItemsEntrega = (DataTable)Session["tablaItemsEntrega"];
        var codigoEntrega = 0;
        var codigoPuntoDeVenta = 0;

        if (Session["tablaEntrega"] != null)
        {
          var tablaEntrega = (DataTable)Session["tablaEntrega"];
          codigoPuntoDeVenta = Convert.ToInt32(tablaEntrega.Rows[0]["codigoPuntoDeVenta"]);
          codigoEntrega = Convert.ToInt32(tablaEntrega.Rows[0]["codigoEntrega"]);
        }
        else
        {
          codigoPuntoDeVenta = Convert.ToInt32(((DataTable)Session["puntoDeVenta"]).Rows[0]["codigoPuntoDeVenta"]);
        }

        if (txtFechaEmision.Value.ToString() == "" || cbNotaDePedido.SelectedIndex < 0 || txtCodigoRemito.Text == "" || tablaItemsEntrega.Rows.Count == 0 || cbTransporte.SelectedIndex < 0 || cbDireccion.SelectedIndex < 0)
        {
          pcError.ShowOnPageLoad = true;
          lblError.Text = "Debe completar todos los campos y elegir al menos un artículo";
        }
        else
        {
          //var dtDatosEmpresa = ControladorGeneral.RecuperarTodosDatosEmpresa(false);
          var puntoDeVenta = ControladorGeneral.RecuperarPuntosDeVentaPorCodigo(codigoPuntoDeVenta);
          var caiAfip = Convert.ToString(puntoDeVenta.Rows[0]["cai"]);
          var fechaVencimientoCaiAfip = Convert.ToDateTime(puntoDeVenta.Rows[0]["vencimientoCai"]);
                
          ControladorGeneral.InsertarActualizarEntrega(codigoPuntoDeVenta, codigoEntrega, Convert.ToDateTime(txtFechaEmision.Value), Convert.ToInt32(cbNotaDePedido.Value), Convert.ToInt32(txtCodigoRemito.Text), txtObservacion.InnerText, tablaItemsEntrega, Convert.ToInt32(cbTransporte.Value), Convert.ToInt32(cbDireccion.SelectedItem.Value),caiAfip,fechaVencimientoCaiAfip);

          Response.Redirect(string.Format("listado.aspx?codigoPuntoDeVenta={0}", codigoPuntoDeVenta.ToString()));
        }
      }

      protected void cbNotaDePedido_SelectedIndexChanged(object sender, EventArgs e)
      {
          CargarGrillaItemsNotaDePedido();
          if (cbNotaDePedido.SelectedItem != null)
          {
              int codigoNotaDePedido = Convert.ToInt32(cbNotaDePedido.SelectedItem.Value);
              cbDireccion.DataSource = ControladorGeneral.RecuperarDireccionesPorNotaDePedido(codigoNotaDePedido);
              cbDireccion.DataBind();
          }
      }

      private void CargarGrillaItemsNotaDePedido()
      {
          if (cbNotaDePedido.SelectedItem != null)
          {
              int codigoNotaDePedido = Convert.ToInt32(cbNotaDePedido.SelectedItem.Value);
              DataTable tablaItemsNotaDePedido = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);

              gvItemsNotaDePedido.DataSource = tablaItemsNotaDePedido;
              gvItemsNotaDePedido.DataBind();
          }
      }

      protected void gvItemsEntrega_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
      {
          DataTable tablaItemsEntrega = (DataTable)Session["tablaItemsEntrega"];
          int codigoItemEntregaEditado = Convert.ToInt32(e.Keys["codigoItemEntrega"]);
          DataRow fila = (from t in tablaItemsEntrega.AsEnumerable() where Convert.ToInt32(t["codigoItemEntrega"]) == codigoItemEntregaEditado select t).SingleOrDefault();
          double cantidad = Convert.ToDouble(e.NewValues["cantidad"]);
          fila["cantidad"] = cantidad;
          Session["tablaItemsEntrega"] = tablaItemsEntrega;
          e.Cancel = true;
          gvItemsEntrega.CancelEdit();
          CargarGrillaItemsEntrega(false);
      }

      protected void gvItemsEntrega_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
      {
          bool isEliminada = Convert.IsDBNull(e.GetValue("isEliminada")) ? false : Convert.ToBoolean(e.GetValue("isEliminada"));
          if (isEliminada)
          {
              e.Row.BackColor = Color.Red;
          }
      }
    }
}