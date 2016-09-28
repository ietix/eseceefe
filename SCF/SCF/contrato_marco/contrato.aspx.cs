using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;
using DevExpress.Web.ASPxUploadControl;

namespace SCF.contrato_marco
{
    public partial class contrato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CargarClientes();

            if (Session["tablaItemsContratoMarco"] != null)
            {
                gvArticulos.DataSource = (DataTable)Session["tablaItemsContratoMarco"];
                gvArticulos.DataBind();
            }
        }

        private void CargarClientes()
        {
            //cbCliente.DataSource = ControladorGeneral.RecuperarTodosClientes(false);
            //cbCliente.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["rutaExcel"] == null)
            {
                pcError.ShowOnPageLoad = true;
                lblError.Text = "Debe cargar la grilla";
            }
            else
            {

                DataTable tabla = OpenExcelFile(Session["rutaExcel"].ToString());
                if (tabla.Rows.Count > 0)
                {
                    string rta = ControladorGeneral.InsertarActualizarContratosMarcosPorTabla(tabla);

                    if (rta != "ok")
                    {
                        pcError.ShowOnPageLoad = true;
                        lblError.Text = rta;
                    }

                    Session["rutaExcel"] = null;
                }
            }
        }

        protected DataTable OpenExcelFile(string fileName)
        {
            DataTable tablaItems = new DataTable();
            string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fileName);
            OleDbConnection conexion = new OleDbConnection(connectionString);
            conexion.Open();
            DataTable tablaSheets = conexion.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (tablaSheets != null)
            {
                if (tablaSheets.Rows.Count > 0)
                {
                    string nombreSheet = tablaSheets.Rows[0]["TABLE_NAME"].ToString();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + nombreSheet + "]", connectionString);
                    adapter.Fill(tablaItems);

                    foreach (DataColumn columna in tablaItems.Columns)
                    {
                        columna.ColumnName = columna.ColumnName.ToUpper();
                    }

                    string rta = ValidarColumnas(tablaItems);

                    if (!string.IsNullOrEmpty(rta))
                    {
                        pcError.ShowOnPageLoad = true;
                        lblError.Text = "Faltan la/s siguiente/s columna/s: " + rta + ".";
                        tablaItems.Rows.Clear();
                    }
                }
                else
                {
                    pcError.ShowOnPageLoad = true;
                    lblError.Text = "El archivo excel no tiene ninguna hoja.";
                    tablaItems.Rows.Clear();
                }
            }
            else
            {
                pcError.ShowOnPageLoad = true;
                lblError.Text = "Error al abrir el archivo excel. Por favor controle que la ruta de acceso sea correcta.";
                tablaItems.Rows.Clear();
            }

            conexion.Close();
            conexion.Dispose();
            return tablaItems;
        }

        private string ValidarColumnas(DataTable tablaItems)
        {
            string rta = string.Empty;
            if (!tablaItems.Columns.Contains("Cm"))
            {
                rta += "CM, ";
            }
            if (!tablaItems.Columns.Contains("POSICION"))
            {
                rta += "POSICION, ";
            }
            if (!tablaItems.Columns.Contains("CLIENTE"))
            {
                rta += "CLIENTE, ";
            }
            if (!tablaItems.Columns.Contains("COMPRADOR"))
            {
                rta += "COMPRADOR, ";
            }
            if (!tablaItems.Columns.Contains("INICIO"))
            {
                rta += "INICIO, ";
            }
            if (!tablaItems.Columns.Contains("FIN"))
            {
                rta += "FIN, ";
            }
            if (!tablaItems.Columns.Contains("PLANTA"))
            {
                rta += "PLANTA, ";
            }
            if (!tablaItems.Columns.Contains("DESCRIPCION"))
            {
                rta += "DESCRIPCION, ";
            }
            if (!tablaItems.Columns.Contains("PRECIO"))
            {
                rta += "PRECIO, ";
            }
            if (!tablaItems.Columns.Contains("MEDIDA"))
            {
                rta += "MEDIDA, ";
            }
            if (!tablaItems.Columns.Contains("MONEDA"))
            {
                rta += "MONEDA, ";
            }

            if (rta.Length > 0)
            {
                rta = rta.Substring(0, rta.Length - 2);
            }

            return rta;
        }

        protected void btnCargarGrilla_Click(object sender, EventArgs e)
        {
            if (fuExcel.HasFile)
            {
                string path = Server.MapPath(".") + "\\contratos\\" + fuExcel.FileName;
                fuExcel.PostedFile.SaveAs(path);
                StreamReader reader = new StreamReader(fuExcel.FileContent);
                string text = reader.ReadToEnd();
                Session.Add("rutaExcel", path);

                DataTable tabla = OpenExcelFile(path);
                if (tabla.Rows.Count > 0)
                {
                    gvArticulos.DataSource = tabla;
                    gvArticulos.DataBind();

                    Session["tablaItemsContratoMarco"] = tabla;
                }
            }
            else
            {
                pcError.ShowOnPageLoad = true;
                lblError.Text = "Debe seleccionar un archivo";
            }
        }
    }
}