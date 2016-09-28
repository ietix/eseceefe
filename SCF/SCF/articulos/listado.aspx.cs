using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;
using System.Web.Services;

namespace SCF.articulos
{
    public partial class listado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["articuloActual"] = null;
            }

            if (string.IsNullOrEmpty(txtCodigoCliente.Text))
            {
                loadGridArticulos();
            }
            else
            {
                gvArticulos.DataSource = ControladorGeneral.RecuperarArticuloPorCodigoInternoCliente(txtCodigoCliente.Text);
                gvArticulos.DataBind();
                gvArticulos.Columns["razonSocialCliente"].Visible = true;
                gvArticulos.Columns["codigoArticuloCliente"].Visible = true;
            }

            if (Session["articuloActual"] != null)
            {
                cargarGrillaRelacionArticuloCliente();
                int codigoArticulo = ((Articulo)Session["articuloActual"]).Codigo;
                gvArticuloProveedor.DataSource = ControladorGeneral.RecuperarArticulosProveedoresPorArticulo(codigoArticulo);
                gvArticuloProveedor.DataBind();
            }

            Session["codigoOperacion"] = null;
        }

        private void loadGridArticulos()
        {
            gvArticulos.DataSource = ControladorGeneral.RecuperarTodosArticulos();
            gvArticulos.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Session["articuloActual"] = null;
            NuevoArticulo();
        }

        private void NuevoArticulo()
        {
            Response.Redirect("articulo.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            EditarArticulo();
        }

        private void EditarArticulo()
        {
            cargarArticuloEnVariableSession();

            Response.Redirect("articulo.aspx");
        }

        private void cargarArticuloEnVariableSession()
        {
            Articulo articuloActual = new Articulo();

            articuloActual.Codigo = int.Parse(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoArticulo").ToString());
            articuloActual.DescripcionCorta = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "descripcionCorta").ToString();
            articuloActual.DescripcionLarga = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "descripcionLarga").ToString();
            articuloActual.Marca = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "marca").ToString();
            articuloActual.UnidadMedida = new UnidadMedida();
            articuloActual.UnidadMedida.Codigo = Convert.ToInt32(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoUnidadMedida"));
            //Como recupero la unidad de medida

            Session.Add("articuloActual", articuloActual);
        }

        protected void btnAceptarEliminarArticulo_Click(object sender, EventArgs e)
        {
            if (gvArticulos.FocusedRowIndex != -1)
            {
                try
                {
                    string rta = ControladorGeneral.EliminarArticulo(int.Parse(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoArticulo").ToString()));
                    pcError.ShowOnPageLoad = true;

                    if (rta == "ok")
                    {
                        lblMensaje.Text = "El articulo se eliminó correctamente.";
                    }
                    else
                    {
                        lblMensaje.Text = "No se pudo eliminar el articulo ya que esta asociado a una nota de pedido.";
                    }

                    loadGridArticulos();
                }
                catch
                {

                }
            }
        }

        protected void btnBuscarPorCodigoCliente_Click(object sender, EventArgs e)
        {
            gvArticulos.DataSource = ControladorGeneral.RecuperarArticuloPorCodigoInternoCliente(txtCodigoCliente.Text);
            gvArticulos.DataBind();

            gvArticulos.Columns["razonSocialCliente"].Visible = true;
            gvArticulos.Columns["codigoArticuloCliente"].Visible = true;

        }

        protected void btnRelacionArticuloCliente_Click(object sender, EventArgs e)
        {
            cargarArticuloEnVariableSession();
            cargarGrillaRelacionArticuloCliente();
        }

        private void cargarGrillaRelacionArticuloCliente()
        {
            cbClientes.DataSource = ControladorGeneral.RecuperarTodosClientes(false);
            cbClientes.DataBind();

            if (gvArticulos.FocusedRowIndex != -1)
            {
                gvArticuloCliente.DataSource = ControladorGeneral.RecuperarArticulosClientesPorArticulo(int.Parse(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoArticulo").ToString()));
                gvArticuloCliente.DataBind();
            }

            pcRelacionArticuloCliente.ShowOnPageLoad = true;
        }

        protected void btnEliminarRelacionArticuloCliente_Click(object sender, EventArgs e)
        {
            pcConfirmarEliminarRelacionArticuloCliente.ShowOnPageLoad = true;
        }

        protected void pcRelacionArticuloCliente_Unload(object sender, EventArgs e)
        {
            if (gvArticulos.FocusedRowIndex != -1)
            {
                Articulo mArticulo = (Articulo)Session["articuloActual"];

                gvArticuloCliente.DataSource = ControladorGeneral.RecuperarArticulosClientesPorArticulo(mArticulo.Codigo);
                gvArticuloCliente.DataBind();
            }

        }

        protected void pcNuevaRelacionArticuloCliente_Unload(object sender, EventArgs e)
        {
            cbClientes.DataSource = ControladorGeneral.RecuperarTodosClientes(false);

            cbClientes.DataBind();
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            pcShowDetalleArticulo.ShowOnPageLoad = true;

            int codigoArticulo = int.Parse(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoArticulo").ToString());
            txtDescripcionCorta.InnerText = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "descripcionCorta").ToString();
            txtDescripcionLarga.InnerText = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "descripcionLarga").ToString();
            txtMarca.Value = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "marca").ToString();
            //txtUnidadDeMedida.Value = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "unidadDeMedida").ToString();
            txtPrecioActual.Value = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "precio").ToString();
            //txtUnidadDeMedida.Value = gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "unidadMedida").ToString();

            gvCliente.DataSource = ControladorGeneral.RecuperarArticulosClientesPorArticulo(codigoArticulo);
            gvCliente.DataBind();
            gvArticuloProveedores.DataSource = ControladorGeneral.RecuperarArticulosProveedoresPorArticulo(codigoArticulo);
            gvArticuloProveedores.DataBind();

            gvHistoricoPrecio.DataSource = ControladorGeneral.RecuperarHistorialPreciosPorArticulo(codigoArticulo);
            gvHistoricoPrecio.DataBind();
        }

        protected void btnConfirmarEliminarRelacionArticuloCliente_Click(object sender, EventArgs e)
        {
            int codigoArticuloCliente = Convert.ToInt32(gvArticuloCliente.GetRowValues(gvArticuloCliente.FocusedRowIndex, "codigoArticuloCliente").ToString());
            int codigoArticulo = ((Articulo)Session["articuloActual"]).Codigo;

            ControladorGeneral.EliminarArticuloCliente(codigoArticuloCliente, codigoArticulo);

            gvArticuloCliente.DataSource = ControladorGeneral.RecuperarArticulosClientesPorArticulo(codigoArticulo);
            gvArticuloCliente.DataBind();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            txtCodigoCliente.Text = string.Empty;
            loadGridArticulos();
            gvArticulos.Columns["razonSocialCliente"].Visible = false;
            gvArticulos.Columns["codigoArticuloCliente"].Visible = false;
        }

        #region Relacion Articulo Proveedor

        protected void btnRelacionArticuloProvevedor_Click(object sender, EventArgs e)
        {
            int codigoArticulo = int.Parse(gvArticulos.GetRowValues(gvArticulos.FocusedRowIndex, "codigoArticulo").ToString());
            cbMonedaCosto.DataSource = ControladorGeneral.RecuperarTodasMonedas();
            cbMonedaCosto.DataBind();
            cbProveedores.DataSource = ControladorGeneral.RecuperarTodosProveedores(false);
            cbProveedores.DataBind();
            gvArticuloProveedor.DataSource = ControladorGeneral.RecuperarArticulosProveedoresPorArticulo(codigoArticulo);
            gvArticuloProveedor.DataBind();

            pcRelacionArticuloProveedor.ShowOnPageLoad = true;
        }

        protected void btnConfirmarEliminarRelacionArticuloProveedor_Click(object sender, EventArgs e)
        {
            int codigoArticuloProveedor = Convert.ToInt32(gvArticuloProveedor.GetRowValues(gvArticuloProveedor.FocusedRowIndex, "codigoArticuloProveedor").ToString());
            int codigoArticulo = ((Articulo)Session["articuloActual"]).Codigo;

            ControladorGeneral.EliminarArticuloProveedor(codigoArticuloProveedor, codigoArticulo);

            gvArticuloProveedor.DataSource = ControladorGeneral.RecuperarArticulosProveedoresPorArticulo(codigoArticulo);
            gvArticuloProveedor.DataBind();
        }

        #endregion

        [WebMethod]
        public static string InsertarActualizarArticuloCliente(string codigoArticulo, string codigoArticuloCliente, int codigoCliente)
        {
            try
            {
                ControladorGeneral.InsertarActualizarArticuloCliente(0, Convert.ToInt32(codigoArticulo), codigoArticuloCliente, codigoCliente);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string InsertarActualizarArticuloProveedor(string codigoArticulo, int codigoProveedor, string costo, int codigoMoneda)
        {
            try
            {
                ControladorGeneral.InsertarActualizarArticuloProveedor(0, Convert.ToInt32(codigoArticulo), codigoProveedor, Convert.ToDouble(costo), codigoMoneda);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string MostrarHistoricoCosto(string codigoProveedor)
        {
            //gvHistoricoCosto.DataSource = ControladorGeneral.RecuperarHistorialCostosPorArticuloProveedor(int.Parse(gvArticuloProveedores.GetRowValues(gvArticuloProveedores.FocusedRowIndex, "codigoArticuloProveedor").ToString()));
            //gvHistoricoCosto.DataBind();
            //pcHistoricoCosto.ShowOnPageLoad = true;
            return "ok";
        }

        protected void btnShowHistoricoCosto_Click(object sender, EventArgs e)
        {
            gvHistoricoCosto.DataSource = ControladorGeneral.RecuperarHistorialCostosPorArticuloProveedor(int.Parse(gvArticuloProveedores.GetRowValues(gvArticuloProveedores.FocusedRowIndex, "codigoArticuloProveedor").ToString()));
            gvHistoricoCosto.DataBind();
            pcHistoricoCosto.ShowOnPageLoad = true;
        }
    }
}