using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Clases;
using BibliotecaSCF.Controladores;

namespace SCF.articulos
{
    public partial class articulo : System.Web.UI.Page
    {
        Articulo oArticuloActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarComboUnidadDeMedida();
            CargarComboTipoMoneda();

            if (!IsPostBack)
            {
                txtPrecio.Value = "0";

                //Cargo el form para editar
                if ((Articulo)Session["articuloActual"] != null)
                {
                    CargarDatosParaEditar((Articulo)Session["articuloActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion", 0);
                    cbMonedaPrecio.SelectedIndex = 0;
                    cbUnidadMedida.SelectedIndex = 0;

                }
            }

        }

        private void CargarComboTipoMoneda()
        {
            DataTable dtTipoMoneda = ControladorGeneral.RecuperarTodasMonedas();

            cbMonedaPrecio.DataSource = dtTipoMoneda;
            cbMonedaPrecio.DataBind();
            //cbMonedaCosto.DataSource = dtTipoMoneda;
            //cbMonedaCosto.DataBind();
        }

        private void CargarComboUnidadDeMedida()
        {
            cbUnidadMedida.DataSource = ControladorGeneral.RecuperarTodasUnidadesMedida();
            cbUnidadMedida.DataBind();
        }

        private void CargarDatosParaEditar(Articulo oArticuloActual)
        {
            txtDescripcionCorta.Value = oArticuloActual.DescripcionCorta;
            txtDescripcionLarga.Value = oArticuloActual.DescripcionLarga;
            txtMarca.Value = oArticuloActual.Marca;
            DataTable dtPrecioHistrialArticulo = ControladorGeneral.RecuperarHistorialPreciosPorArticulo(oArticuloActual.Codigo);
            txtPrecio.Value = dtPrecioHistrialArticulo.Rows[dtPrecioHistrialArticulo.Rows.Count - 1]["precio"].ToString();
            cbMonedaPrecio.Text = dtPrecioHistrialArticulo.Rows[dtPrecioHistrialArticulo.Rows.Count - 1]["descripcionMoneda"].ToString();
            //cbUnidadMedida.Text = oArticuloActual.UnidadMedida.Descripcion;
            cbUnidadMedida.SelectedItem = cbUnidadMedida.Items.FindByValue(oArticuloActual.UnidadMedida.Codigo);

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //si el codigoOperacion es Null es una edicion.
            if (Session["codigoOperacion"] == null)
            {
                oArticuloActual = (Articulo)Session["articuloActual"];
                ControladorGeneral.InsertarActualizarArticulo(oArticuloActual.Codigo, txtDescripcionCorta.Value, txtDescripcionLarga.Value, txtMarca.Value, txtPrecio.Value, Convert.ToDouble(txtPrecio.Value), Convert.ToInt32(cbMonedaPrecio.SelectedItem.Value), Convert.ToInt32(cbUnidadMedida.SelectedItem.Value));
            }
            //si el codigoOperacion es != null hago un insert.
            else
            {

                ControladorGeneral.InsertarActualizarArticulo(0, txtDescripcionCorta.Value, txtDescripcionLarga.Value, txtMarca.Value, txtPrecio.Value, Convert.ToDouble(txtPrecio.Value), Convert.ToInt32(cbMonedaPrecio.SelectedItem.Value), Convert.ToInt32(cbUnidadMedida.SelectedItem.Value));

            }

            Response.Redirect("listado.aspx");
        }

        protected void btnEditarArticuloProveedor_Click(object sender, EventArgs e)
        {
            //pcArticuloProveedor.ShowOnPageLoad = true;
        }

        protected void btnEliminarArticuloProveedor_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarArticuloProveedor_Click(object sender, EventArgs e)
        {
            oArticuloActual = (Articulo)Session["articuloActual"];

            //ControladorGeneral.InsertarActualizarArticuloProveedor(0, oArticuloActual.Codigo, (int)cbProveedores.SelectedItem.Value, double.Parse(txtCosto.Value.ToString()), Convert.ToInt32(cbMonedaCosto.SelectedItem.Value.ToString()));
        }

        protected void btnEditarPrecio_Click(object sender, EventArgs e)
        {
            //pcAddPrecio.ShowOnPageLoad = true;
        }

        protected void btnEliminarPrecio_Click(object sender, EventArgs e)
        {

        }

        protected void btnGurdarAticuloProveedor_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarAddPrecio_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardarAddCosto_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptarEliminarArticuloProveedor_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevoArticuloProveedor_Click(object sender, EventArgs e)
        {
            // CargarComboProveedores();
            // pcArticuloProveedor.ShowOnPageLoad = true;
        }

        private void CargarComboProveedores()
        {
            //cbProveedores.DataSource = ControladorGeneral.RecuperarTodosProveedores(false);
            //cbProveedores.DataBind();
        }
    }
}