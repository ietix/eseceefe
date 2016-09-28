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
                    cbNotaDePedido.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido(false);
                    cbNotaDePedido.DataBind();

                    DataTable tablaEntrega = (DataTable)Session["tablaEntrega"];
                    txtCodigoRemito.Text = tablaEntrega.Rows[0]["numeroRemito"].ToString(); ;
                    txtFechaEmision.Value = Convert.ToDateTime(tablaEntrega.Rows[0]["fechaEmision"]);
                    txtObservacion.InnerText = tablaEntrega.Rows[0]["observaciones"].ToString();

                    int codigoNotaDePedido = Convert.ToInt32(tablaEntrega.Rows[0]["codigoNotaDePedido"]);
                    gvItemsNotaDePedido.DataSource = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);
                    gvItemsNotaDePedido.DataBind();

                    cbNotaDePedido.SelectedItem = cbNotaDePedido.Items.FindByValue(Convert.ToInt32(tablaEntrega.Rows[0]["codigoNotaDePedido"]));
                    cbNotaDePedido.Value = Convert.ToInt32(tablaEntrega.Rows[0]["codigoNotaDePedido"]);
                    cbTransporte.SelectedItem = cbTransporte.Items.FindByValue(Convert.ToInt32(tablaEntrega.Rows[0]["codigoTransporte"]));
                    cbTransporte.Value = Convert.ToInt32(tablaEntrega.Rows[0]["codigoTransporte"]);

                    int codigoEntrega = Convert.ToInt32(tablaEntrega.Rows[0]["codigoEntrega"]);
                    DataTable tablaItemsEntrega = ControladorGeneral.RecuperarItemsEntrega(codigoEntrega);
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
                    cbNotaDePedido.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido(true);
                    cbNotaDePedido.DataBind();

                    DataTable tablaUltimaEntrega = ControladorGeneral.RecuperarUltimaEntrega();
                    txtCodigoRemito.Text = tablaUltimaEntrega.Rows.Count > 0 ? (Convert.ToInt32(tablaUltimaEntrega.Rows[0]["numeroRemito"]) + 1).ToString() : "1";
                }
            }
            else
            {
                if (Session["tablaEntrega"] != null)
                {
                    cbNotaDePedido.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido(false);
                    cbNotaDePedido.DataBind();

                    DataTable tablaEntrega = (DataTable)Session["tablaEntrega"];
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
                    cbNotaDePedido.DataSource = ControladorGeneral.RecuperarTodasNotasDePedido(true);
                    cbNotaDePedido.DataBind();

                    if (cbNotaDePedido.SelectedItem != null)
                    {
                        int codigoNotaDePedido = Convert.ToInt32(cbNotaDePedido.SelectedItem.Value);
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
            DataTable tablaItemsEntrega = (DataTable)Session["tablaItemsEntrega"];
            CargarGrillaItemsEntrega(true);
        }

        private void CargarGrillaItemsEntrega(bool isSeleccionar)
        {
            CargarGrillaItemsNotaDePedido();
            DataTable tablaItemsEntrega = new DataTable();

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
                    int codigoEntrega = Convert.ToInt32(((DataTable)Session["tablaEntrega"]).Rows[0]["codigoEntrega"]);
                    DataTable tablaItemsEntregaActual = ControladorGeneral.RecuperarItemsEntrega(codigoEntrega);
                    tablaItemsEntregaActual.Columns.Add("isEliminada");

                    tablaItemsEntrega = tablaItemsEntregaActual.Copy();
                }

                for (int i = 0; i < gvItemsNotaDePedido.VisibleRowCount; i++)
                {
                    if (gvItemsNotaDePedido.Selection.IsRowSelected(i))
                    {
                        DataRowView mRow = (DataRowView)gvItemsNotaDePedido.GetRow(i);
                        tablaItemsEntrega.Rows.Add(-i, mRow.Row.ItemArray[1], mRow.Row.ItemArray[2], 1, 0, string.Empty, mRow.Row.ItemArray[0], false);
                    }
                }

                Session["tablaItemsEntrega"] = tablaItemsEntrega;
            }
            else
            {
                tablaItemsEntrega = (DataTable)Session["tablaItemsEntrega"];

                if (isSeleccionar)
                {
                    for (int i = 0; i < gvItemsNotaDePedido.VisibleRowCount; i++)
                    {
                        if (gvItemsNotaDePedido.Selection.IsRowSelected(i))
                        {
                            DataRowView mRow = (DataRowView)gvItemsNotaDePedido.GetRow(i);
                            int codigoItemNotaDePedido = Convert.ToInt32(mRow.Row.ItemArray[0]);
                            DataRow filaRepetida = (from t in tablaItemsEntrega.AsEnumerable() where Convert.ToInt32(t["codigoItemNotaDePedido"]) == codigoItemNotaDePedido select t).SingleOrDefault();

                            if (filaRepetida == null)
                            {
                                tablaItemsEntrega.Rows.Add(-i, mRow.Row.ItemArray[1], mRow.Row.ItemArray[2], 1, 0, string.Empty, mRow.Row.ItemArray[0], false);
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
            DataTable tablaItemsEntrega = (DataTable)Session["tablaItemsEntrega"];
            int codigoEntrega = 0;

            if (Session["tablaEntrega"] != null)
            {
                DataTable tablaEntrega = (DataTable)Session["tablaEntrega"];
                codigoEntrega = Convert.ToInt32(tablaEntrega.Rows[0]["codigoEntrega"]);
            }

            if (txtFechaEmision.Value.ToString() == "" || cbNotaDePedido.SelectedIndex < 0 || txtCodigoRemito.Text == "" || tablaItemsEntrega.Rows.Count == 0 || cbTransporte.SelectedIndex < 0 || cbDireccion.SelectedIndex < 0)
            {
                pcError.ShowOnPageLoad = true;
                lblError.Text = "Debe completar todos los campos y elegir al menos un artículo";
            }
            else
            {
                DataTable dtDatosEmpresa = ControladorGeneral.RecuperarTodosDatosEmpresa(false);
                string caiAfip = Convert.ToString(dtDatosEmpresa.Rows[0]["cai"]);
                DateTime fechaVencimientoCaiAfip = Convert.ToDateTime(dtDatosEmpresa.Rows[0]["fechaVencimientoCai"]);
                
                ControladorGeneral.InsertarActualizarEntrega(codigoEntrega, Convert.ToDateTime(txtFechaEmision.Value), Convert.ToInt32(cbNotaDePedido.Value), Convert.ToInt32(txtCodigoRemito.Text), txtObservacion.InnerText, tablaItemsEntrega, Convert.ToInt32(cbTransporte.Value), Convert.ToInt32(cbDireccion.SelectedItem.Value),caiAfip,fechaVencimientoCaiAfip);

                Response.Redirect("listado.aspx");
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
            int cantidad = Convert.ToInt32(e.NewValues["cantidad"]);
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