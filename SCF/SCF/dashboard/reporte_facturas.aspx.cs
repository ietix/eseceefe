using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaSCF.Controladores;
using Microsoft.Reporting.WebForms;

namespace SCF.dashboard
{
    public partial class reporte_facturas : System.Web.UI.Page
    {
        dtReporteFacturas dtReporte = new dtReporteFacturas();
        DataTable tablaReporte = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //EmitirReporte();
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            EmitirReporte();
        }

        private void EmitirReporte()
        {
            DataTable dtRecuperarFacturas = ControladorGeneral.RecuperarFacturasPorFechas(DateTime.Parse(deFechaDesde.Value.ToString()), DateTime.Parse(deFechaHasta.Value.ToString()));
            
            rvFacturas.ProcessingMode = ProcessingMode.Local;
            rvFacturas.LocalReport.EnableExternalImages = true;
            rvFacturas.LocalReport.ReportPath = Server.MapPath("..") + "\\reportes\\reporteFacturas.rdlc";

            ReportParameter txtFechaDesde = new ReportParameter("txtFechaDesde", deFechaDesde.Value.ToString());
            ReportParameter txtFechaHasta = new ReportParameter("txtFechaHasta", deFechaHasta.Value.ToString());

            this.rvFacturas.LocalReport.SetParameters(new ReportParameter[] { txtFechaDesde,txtFechaHasta});

            dtReporte.DataTable1.Clear();
            tablaReporte = dtRecuperarFacturas;

            foreach (DataRow fila in tablaReporte.Rows)
            {
                double iva = double.Parse(fila["total"].ToString()) - double.Parse(fila["subtotal"].ToString());
                DataRow filaReporte = dtReporte.DataTable1.NewRow();
                filaReporte["numeroFactura"] = fila["numeroFactura"];
                filaReporte["fechaEmision"] = fila["fechaFacturacion"];
                filaReporte["nombreCliente"] = fila["cliente"];
                filaReporte["tipoMoneda"] = fila["descripcionTipoMoneda"];
                filaReporte["cotizacion"] = fila["cotizacion"];
                filaReporte["subtotal"] = fila["subtotal"];
                filaReporte["iva"] = iva;
                filaReporte["total"] = fila["total"];

                dtReporte.DataTable1.Rows.Add(filaReporte);
            }

            //for (int i = 0; i < (5 - tablaReporte.Rows.Count); i++)
            //for (int i = 0; i < (tablaReporte.Rows.Count); i++)
            /*for (int i = tablaReporte.Rows.Count; i <= 10; i++)
            {
                DataRow filaReporte = dtReporteFacturas.DataTable1.NewRow();
                dtReporteFacturas.DataTable1.Rows.Add(filaReporte);
            }*/

            dtReporteFacturas dsReporte1 = dtReporte;

            ReportDataSource datasource = new ReportDataSource("DataSet1", dsReporte1.Tables[0]);
            rvFacturas.LocalReport.DataSources.Clear();
            rvFacturas.LocalReport.DataSources.Add(datasource);
            rvFacturas.LocalReport.Refresh();
        }
    }
}