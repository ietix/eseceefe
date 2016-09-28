using BibliotecaSCF.Controladores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using System.Drawing;
using System.Globalization;

namespace SCF.nota_pedido
{
    public partial class nota_pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            CargarComboClientes();
            CargarGrillaArticulos();
            //Hacer metodo y llamarlo aca para que traiga todos los contratos vigentes 
             CargarComboContratoMarco();
            //Hacer un metodo que devuelva todos los arituclos y los que tiene una 
            //realacion con ese codigo pero no solo los que tiene como relacion
            CargarGrillaArticulosPorCliente();

            if (txtFechaEmision.Value == null || string.IsNullOrEmpty(txtFechaEmision.Value.ToString()))
            {
                txtFechaEmision.Value = DateTime.Now;
            }

            if (!IsPostBack)
            {

                txtFechaEmision.Value = DateTime.Now;

                CargarGrillaItemsNotaDePedido(false);


                if (Session["tablaNotaDePedido"] != null)
                {
                    DataTable tablaNotaDePedido = (DataTable)Session["tablaNotaDePedido"];
                    int codigoNotaDePedido = Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoNotaDePedido"]);
                    string numeroInternoCliente = tablaNotaDePedido.Rows[0]["numeroInternoCliente"].ToString();
                    DateTime fechaEmision = Convert.ToDateTime(tablaNotaDePedido.Rows[0]["fechaEmision"]);
                    int codigoEstado = Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoEstado"]);
                    int codigoContratoMarco = Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoContratoMarco"]);
                    int codigoCliente = Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoCliente"]);
                    DateTime fechaHoraProximaEntrega = Convert.ToDateTime(tablaNotaDePedido.Rows[0]["fechaHoraProximaEntrega"]);
                    string observaciones = tablaNotaDePedido.Rows[0]["observaciones"].ToString();

                    txtCodigoInterno.Text = numeroInternoCliente;
                    txtFechaEmision.Value = fechaEmision.ToString();
                    txtNroInternoCliente.Text = numeroInternoCliente;
                    txtObservacion.InnerText = observaciones;
                    cbClientes.SelectedItem = cbClientes.Items.FindByValue(Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoCliente"]));
                    CargarComboContratoMarcoPorCliente(Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoCliente"]));
                    cbContratoMarco.SelectedItem = cbContratoMarco.Items.FindByValue(Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoContratoMarco"]));

                    DataTable tablaItemsNotaDePedido = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);
                    tablaItemsNotaDePedido.Columns.Add("isEliminada");
                    gvArticulosSeleccionados.DataSource = tablaItemsNotaDePedido;
                    gvArticulosSeleccionados.DataBind();

                    Session["tablaItemsNotaDePedido"] = tablaItemsNotaDePedido;


                }
                else
                {
                    DataTable tablaNotaDePedido = ControladorGeneral.RecuperarUltimaNotaDePedido();
                    txtNroInternoCliente.Text = tablaNotaDePedido.Rows.Count > 0 ? (Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoNotaDePedido"]) + 1).ToString() : "1";
                }



            }


        }

        private void CargarGrillaItemsNotaDePedido(bool isSeleccionar)
        {
            DataTable tablaItemsNotaDePedido = new DataTable();

            if (Session["tablaItemsNotaDePedido"] == null)
            {
                tablaItemsNotaDePedido.Columns.Add("codigoArticulo");
                tablaItemsNotaDePedido.Columns.Add("descripcionCorta");
                tablaItemsNotaDePedido.Columns.Add("descripcionLarga");
                tablaItemsNotaDePedido.Columns.Add("marca");
                tablaItemsNotaDePedido.Columns.Add("posicion", typeof(int));
                tablaItemsNotaDePedido.Columns.Add("cantidad", typeof(int));
                tablaItemsNotaDePedido.Columns.Add("fechaEntrega", typeof(DateTime));
                tablaItemsNotaDePedido.Columns.Add("codigoItemNotaDePedido", typeof(int));
                tablaItemsNotaDePedido.Columns.Add("precio", typeof(float));
                tablaItemsNotaDePedido.Columns.Add("isEliminada");
                tablaItemsNotaDePedido.Columns.Add("descripcionMoneda");

                if (Session["tablaNotaDePedido"] != null)
                {
                    int codigoNotaDePedido = Convert.ToInt32(((DataTable)Session["tablaNotaDePedido"]).Rows[0]["codigoNotaDePedido"]);

                    DataTable tablaItemsNotaDePedidoActual = ControladorGeneral.RecuperarItemsNotaDePedido(codigoNotaDePedido);
                    tablaItemsNotaDePedidoActual.Columns.Add("isEliminada");

                    tablaItemsNotaDePedido = tablaItemsNotaDePedidoActual.Copy();
                }

                for (int i = 0; i < gvArticulos.VisibleRowCount; i++)
                {
                    if (gvArticulos.Selection.IsRowSelected(i))
                    {
                        DataRowView mRow = (DataRowView)gvArticulos.GetRow(i);
                        tablaItemsNotaDePedido.Rows.Add(mRow.Row.ItemArray[0], mRow.Row.ItemArray[1], mRow.Row.ItemArray[2], mRow.Row.ItemArray[3], 1, DateTime.Now, -i, mRow.Row.ItemArray[4], false, mRow.Row.ItemArray[12]);
                    }
                }

                Session["tablaItemsNotaDePedido"] = tablaItemsNotaDePedido;
            }
            else
            {
                tablaItemsNotaDePedido = (DataTable)Session["tablaItemsNotaDePedido"];

                if (isSeleccionar)
                {
                    for (int i = 0; i < gvArticulos.VisibleRowCount; i++)
                    {
                        if (gvArticulos.Selection.IsRowSelected(i))
                        {
                            DataRowView mRow = (DataRowView)gvArticulos.GetRow(i);
                            int codigoArticulo = Convert.ToInt32(mRow.Row.ItemArray[0]);

                            if (gvArticulosSeleccionados.VisibleRowCount < 1)
                                cbContratoMarco.SelectedItem = cbContratoMarco.Items.FindByValue(getContratoMarco(codigoArticulo));

                          
                            //Se comenta lo de la linea repetida a pedido del cliente
                            
                            //DataRow filaRepetida = (from t in tablaItemsNotaDePedido.AsEnumerable() where Convert.ToInt32(t["codigoArticulo"]) == codigoArticulo select t).SingleOrDefault();

                            //if (filaRepetida == null)
                            //{
                            if (Session["tablaNotaDePedido"] == null)
                                tablaItemsNotaDePedido.Rows.Add(mRow.Row.ItemArray[0], mRow.Row.ItemArray[1], mRow.Row.ItemArray[2], mRow.Row.ItemArray[3], tablaItemsNotaDePedido.Rows.Count+1, 1, DateTime.Now, -i, mRow.Row.ItemArray[4], false, mRow.Row.ItemArray[12]);
                            else
                                tablaItemsNotaDePedido.Rows.Add(0, mRow.Row.ItemArray[0], mRow.Row.ItemArray[1], mRow.Row.ItemArray[2], mRow.Row.ItemArray[3], mRow.Row.ItemArray[4], 1, DateTime.Now, 1, mRow.Row.ItemArray[11], mRow.Row.ItemArray[12], tablaItemsNotaDePedido.Rows.Count + 1, mRow.Row.ItemArray[4],false);
                            //} 
                        }
                    }
                }
            }


            gvArticulosSeleccionados.DataSource = tablaItemsNotaDePedido;
            gvArticulosSeleccionados.DataBind();


        }

        private int getContratoMarco(int codigoArticulo)
        {
            int t = 0;
            if (cbClientes.SelectedItem != null)
            {
                DataTable tablaContratoMarco = ControladorGeneral.RecuperarContratosMarcoVigentePorClienteYArticulo(int.Parse(cbClientes.SelectedItem.Value.ToString()), codigoArticulo);
                if (tablaContratoMarco.Rows.Count > 0)
                {
                    t = Convert.ToInt16(tablaContratoMarco.Rows[0]["codigoContratoMarco"]);

                }
            }
            return t;
        }

        private void CargarGrillaArticulosPorCliente()
        {
            if (cbClientes.SelectedItem != null)
            {
                int codigoCliente = Convert.ToInt32(cbClientes.SelectedItem.Value);
                DataTable tablaItemsNotaDePedido = ControladorGeneral.RecuperarArticulosPorCodigoCliente(codigoCliente);
                gvArticulos.DataSource = tablaItemsNotaDePedido;
                gvArticulos.DataBind();
            }
        }

        private void CargarGrillaArticulos()
        {
            gvArticulos.DataSource = ControladorGeneral.RecuperarTodosArticulos();
            gvArticulos.DataBind();
        }

        private void CargarComboClientes()
        {
            cbClientes.DataSource = ControladorGeneral.RecuperarTodosClientes(false);
            cbClientes.DataBind();
        }

        private void CargarComboContratoMarcoPorCliente(int codigoCliente)
        {
            cbContratoMarco.DataSource = ControladorGeneral.RecuperarContratosMarcoVigentePorCliente(codigoCliente);
            cbContratoMarco.DataBind();
        }

        private void CargarComboContratoMarco()
        {
            cbContratoMarco.DataSource = ControladorGeneral.RecuperarContratosMarcoVigente();
            cbContratoMarco.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DataTable tablaItemsNotaDePedido = (DataTable)Session["tablaItemsNotaDePedido"];
            int codigoNotaDePedido = 0;

            if (Session["tablaNotaDePedido"] != null)
            {
                DataTable tablaNotaDePedido = (DataTable)Session["tablaNotaDePedido"];
                codigoNotaDePedido = Convert.ToInt32(tablaNotaDePedido.Rows[0]["codigoNotaDePedido"]);
            }

            if (cbClientes.SelectedItem != null && !txtNroInternoCliente.Text.Equals(""))
            {
                ControladorGeneral.InsertarActualizarNotaDePedido(codigoNotaDePedido, txtNroInternoCliente.Text.ToString(), DateTime.Parse(txtFechaEmision.Value.ToString()), txtObservacion.InnerText.ToString(), cbContratoMarco.SelectedItem == null ? 0 : Convert.ToInt32(cbContratoMarco.SelectedItem.Value), (int)cbClientes.SelectedItem.Value, tablaItemsNotaDePedido);
                Response.Redirect("listado.aspx");
            }
            else
            {
                pcError.ShowOnPageLoad = true;
                lblError.Text = "Hay campos que deben completarse";
            }
        }

        protected void btnSeleccionarArticulos_Click(object sender, EventArgs e)
        {
            DataTable tablaItemsNotaDePedido = (DataTable)Session["tablaItemsNotaDePedido"];
            CargarGrillaItemsNotaDePedido(true);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            DataTable tablaItemsNotaDePedido = (DataTable)Session["tablaItemsNotaDePedido"];
            int codigoItemNotaDePedidoEliminado = Convert.ToInt32(gvArticulosSeleccionados.GetRowValues(gvArticulosSeleccionados.FocusedRowIndex, "codigoItemNotaDePedido"));

            DataRow filaEliminada = (from t in tablaItemsNotaDePedido.AsEnumerable() where Convert.ToInt32(t["codigoItemNotaDePedido"]) == codigoItemNotaDePedidoEliminado select t).SingleOrDefault();

            if (codigoItemNotaDePedidoEliminado < 1)
            {
                tablaItemsNotaDePedido.Rows.Remove(filaEliminada);
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

            Session["tablaItemNotaDePedido"] = tablaItemsNotaDePedido;
            CargarGrillaItemsNotaDePedido(false);
        }

        protected void gvItemsEntrega_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            DataTable tablaItemsNotaDePedido = (DataTable)Session["tablaItemsNotaDePedido"];
            int posicion = Convert.ToInt32(e.Keys["posicion"]);
            DataRow fila = (from t in tablaItemsNotaDePedido.AsEnumerable() where Convert.ToInt32(t["posicion"]) == posicion select t).SingleOrDefault();

            fila["posicion"] = Convert.ToInt32(e.NewValues["posicion"]);
            fila["cantidad"] = Convert.ToInt32(e.NewValues["cantidad"]);

            DateTime a = new DateTime();

            if (!DateTime.TryParse(e.NewValues["fechaEntrega"].ToString(), out a))
            {
                a = Convert.ToDateTime(e.NewValues["fechaEntrega"].ToString(), System.Globalization.CultureInfo.GetCultureInfo("en-Us").DateTimeFormat);

            }
            fila["precio"] = Convert.ToDouble(e.NewValues["precio"]);

            fila["fechaEntrega"] = a;
            Session["tablaItemsNotaDePedido"] = tablaItemsNotaDePedido;

            e.Cancel = true;
            gvArticulosSeleccionados.CancelEdit();
            CargarGrillaItemsNotaDePedido(false);
        }

        protected void gvItemsEntrega_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            bool isEliminada = Convert.IsDBNull(e.GetValue("isEliminada")) ? false : Convert.ToBoolean(e.GetValue("isEliminada"));
            if (isEliminada)
            {
                e.Row.BackColor = Color.Red;
            }
        }

        protected void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrillaArticulosPorCliente();
            CargarComboContratoMarcoPorCliente((int)cbClientes.SelectedItem.Value);
        }
    }
}