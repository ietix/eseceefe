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
    public partial class empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatosEmpresa();
        }

        private void CargarDatosEmpresa()
        {
            var datosEmpresa = ControladorGeneral.RecuperarTodosDatosEmpresa(false);
            
            Session.Add("codigoDatosEmpresa", Convert.ToString(datosEmpresa.Rows[0]["codigoDatosEmpresa"]));
            txtNroDocumento.Value = Convert.ToString(datosEmpresa.Rows[0]["cuil"]);
            txtRazonSocial.Value = Convert.ToString(datosEmpresa.Rows[0]["razonSocial"]);
            txtCiudad.Value = Convert.ToString(datosEmpresa.Rows[0]["localidad"]);
            txtDireccion.Value = Convert.ToString(datosEmpresa.Rows[0]["direccion"]);
            txtMail.Value = Convert.ToString(datosEmpresa.Rows[0]["mail"]);
            txtProvincia.Value = Convert.ToString(datosEmpresa.Rows[0]["provincia"]);
            txtTelefono.Value = Convert.ToString(datosEmpresa.Rows[0]["telefono"]);
            txtPersonaContacto.Value = Convert.ToString(datosEmpresa.Rows[0]["personaContacto"]);
            txtBanco.Value = Convert.ToString(datosEmpresa.Rows[0]["banco"]);
            txtCBU.Value = Convert.ToString(datosEmpresa.Rows[0]["cbu"]);
            txtNroCuentaBancaria.Value = Convert.ToString(datosEmpresa.Rows[0]["numeroCuenta"]);
            txtObservacion.Value = Convert.ToString(datosEmpresa.Rows[0]["observaciones"]);
            txtFax.Value = Convert.ToString(datosEmpresa.Rows[0]["fax"]);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ControladorGeneral.InsertarActualizarDatosEmpresa(Convert.ToInt32(Session["codigoDatosEmpresa"]), txtRazonSocial.Value, txtProvincia.Value, txtCiudad.Value, txtDireccion.Value, txtTelefono.Value,
                    txtFax.Value, txtMail.Value, txtNroDocumento.Value, txtPersonaContacto.Value, txtNroCuentaBancaria.Value, txtBanco.Value, txtCBU.Value, txtObservacion.Value, 80,
                    string.Empty, DateTime.Now); //agregar tipo documento
        }
    }
}