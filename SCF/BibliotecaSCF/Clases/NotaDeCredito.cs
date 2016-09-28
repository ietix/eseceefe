using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class NotaDeCredito
    {
        public NotaDeCredito()
        {
            ItemsNotaDeCredito = new List<ItemNotaDeCredito>();
        }

        public virtual int Codigo { get; set; }
        public virtual int NumeroNotaDeCredito { get; set; }
        public virtual double Total { get; set; }
        public virtual bool IsFacturaCompleta { get; set; }
        public virtual DateTime FechaHoraNotaDeCredito { get; set; }
        public virtual string CAE { get; set; }
        public virtual DateTime? FechaHoraVencimientoCAE { get; set; }
        public virtual double Subtotal { get; set; }

        public virtual TipoComprobante TipoComprobante { get; set; }
        public virtual Factura Factura { get; set; }
        public virtual IList<ItemNotaDeCredito> ItemsNotaDeCredito { get; set; }

        private static DataTable Tabla
        {
            get
            {
                DataTable tablaNotaDeCredito = new DataTable();
                tablaNotaDeCredito.Columns.Add("codigoNotaDeCredito");
                tablaNotaDeCredito.Columns.Add("numeroNotaDeCredito");
                tablaNotaDeCredito.Columns.Add("fechaEmisionNotaDeCredito");
                tablaNotaDeCredito.Columns.Add("descripcionTipoMoneda");
                tablaNotaDeCredito.Columns.Add("cotizacion");
                tablaNotaDeCredito.Columns.Add("subtotal");
                tablaNotaDeCredito.Columns.Add("total");
                tablaNotaDeCredito.Columns.Add("isFacturaCompleta");
                tablaNotaDeCredito.Columns.Add("codigoFactura");
                tablaNotaDeCredito.Columns.Add("numeroFactura");
                tablaNotaDeCredito.Columns.Add("totalFactura");
                tablaNotaDeCredito.Columns.Add("cae");
                tablaNotaDeCredito.Columns.Add("fechaHoraVencimientoCAE");
                tablaNotaDeCredito.Columns.Add("codigoTipoComprobante");
                tablaNotaDeCredito.Columns.Add("descripcionTipoComprobante");
                tablaNotaDeCredito.Columns.Add("razonSocialCliente");
                tablaNotaDeCredito.Columns.Add("domicilio");
                tablaNotaDeCredito.Columns.Add("localidad");
                tablaNotaDeCredito.Columns.Add("nroDocumentoCliente");
                tablaNotaDeCredito.Columns.Add("remitos");
                tablaNotaDeCredito.Columns.Add("condicionVenta");
                tablaNotaDeCredito.Columns.Add("numeroNotaDePedido");
                tablaNotaDeCredito.Columns.Add("codigoSCF");
                
                return tablaNotaDeCredito;
            }
        }

        /// <summary>
        /// Recupera una tabla con la lista completa de las notas de credito
        /// </summary>
        /// <param name="listaNotasDeCredito"></param>
        /// <returns></returns>
        public static DataTable RecuperarTabla(List<NotaDeCredito> listaNotasDeCredito)
        {
            DataTable tablaNotasDeCredito = Tabla;
            listaNotasDeCredito.OrderByDescending(x => x.NumeroNotaDeCredito).Aggregate(tablaNotasDeCredito, (dt, r) =>
            {
                dt.Rows.Add(r.Codigo, r.NumeroNotaDeCredito, r.FechaHoraNotaDeCredito.ToString("dd/MM/yyyy"), r.Factura.Moneda.Descripcion, r.Factura.Cotizacion, r.Subtotal, r.Total, r.IsFacturaCompleta, r.Factura.Codigo, r.Factura.NumeroFactura, r.Factura.Total, r.CAE, r.FechaHoraVencimientoCAE, r.TipoComprobante.Codigo, r.TipoComprobante.Descripcion,
                    r.Factura.Entregas[0].NotaDePedido.Cliente.RazonSocial, r.Factura.Entregas[0].Direccion.Descripcion, r.Factura.Entregas[0].Direccion.Localidad, r.Factura.Entregas[0].NotaDePedido.Cliente.NumeroDocumento,
                    string.Join(", ", r.Factura.Entregas.Select(x => x.NumeroRemito)), r.Factura.CondicionVenta, r.Factura.Entregas[0].NotaDePedido.NumeroInternoCliente, r.Factura.Entregas[0].NotaDePedido.Cliente.CodigoSCF); 
                return dt;
            });

            return tablaNotasDeCredito;
        }

        /// <summary>
        /// Recupera una tabla para una nota de credito sola
        /// </summary>
        /// <param name="notaDeCredito"></param>
        /// <returns></returns>
        public static DataTable RecuperarTabla(NotaDeCredito notaDeCredito)
        {
            DataTable tablaNotaDeCredito = Tabla;
            tablaNotaDeCredito.Rows.Add(notaDeCredito.Codigo, notaDeCredito.NumeroNotaDeCredito, notaDeCredito.Subtotal, notaDeCredito.Total, notaDeCredito.IsFacturaCompleta, notaDeCredito.Factura.Codigo, notaDeCredito.Factura.NumeroFactura, notaDeCredito.Factura.Total, notaDeCredito.CAE, notaDeCredito.FechaHoraVencimientoCAE, notaDeCredito.TipoComprobante.Codigo, notaDeCredito.TipoComprobante.Descripcion); 

            return tablaNotaDeCredito;
        }
    }
}
