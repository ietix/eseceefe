using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
  public class Factura
  {
    public Factura()
    {
        Entregas = new List<Entrega>();
    }

    public virtual int Codigo { get; set; }
    public virtual int NumeroFactura { get; set; }
    public virtual DateTime FechaFacturacion { get; set; }
    public virtual double Subtotal { get; set; }
    public virtual double Total { get; set; }
    public virtual string Cae { get; set; }
    public virtual DateTime? FechaVencimiento { get; set; }
    public virtual string CondicionVenta { get; set; }
    public virtual double Cotizacion { get; set; }

    public virtual TipoComprobante TipoComprobante { get; set; }
    public virtual IList<Entrega> Entregas { get; set; }
    public virtual TipoMoneda Moneda { get; set; }
    public virtual Concepto Concepto { get; set; }
    public virtual Iva Iva { get; set; }
    public virtual PuntosDeVenta PuntoDeVenta { get; set; }

    private static DataTable Tabla
    {
      get
      {
        var tablaNotaDeCredito = new DataTable();
        tablaNotaDeCredito.Columns.Add("codigoFactura");
        tablaNotaDeCredito.Columns.Add("numeroFactura");
        tablaNotaDeCredito.Columns.Add("descripcionTipoMoneda");
        tablaNotaDeCredito.Columns.Add("condicionVenta");
        tablaNotaDeCredito.Columns.Add("concepto");
        tablaNotaDeCredito.Columns.Add("cotizacion");
        tablaNotaDeCredito.Columns.Add("codigoEntrega");
        tablaNotaDeCredito.Columns.Add("codigoPuntoDeVenta");
        tablaNotaDeCredito.Columns.Add("numeroPuntoDeVenta");

        return tablaNotaDeCredito;
      }
    }

    internal static DataTable RecuperarTabla(Factura factura)
    {
        var tablaFactura = Tabla;

        tablaFactura.Rows.Add(factura.Codigo, factura.NumeroFactura, factura.Moneda.Descripcion, factura.CondicionVenta, factura.Concepto.Descripcion, factura.Cotizacion, factura.Entregas[0].Codigo, factura.PuntoDeVenta.Codigo, factura.PuntoDeVenta.Numero);

        return tablaFactura;
    }
  }
}
