using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class FacturaMap : ClassMap<Factura>
    {
        public FacturaMap()
        {
            Table("Facturas");
            Id(x => x.Codigo).Column("codigoFactura").GeneratedBy.Identity();
            Map(x => x.NumeroFactura).Column("numeroFactura");
            Map(x => x.FechaFacturacion).Column("fechaFacturacion");
            Map(x => x.Subtotal).Column("subtotal");
            Map(x => x.Total).Column("total");
            Map(x => x.Cae).Column("cae");
            Map(x => x.FechaVencimiento).Column("fechaVencimiento");
            Map(x => x.CondicionVenta).Column("condicionVenta");
            Map(x => x.Cotizacion).Column("cotizacion");
            
            References(x => x.Concepto).Column("codigoConcepto").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.TipoComprobante).Column("codigoTipoComprobante").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.Moneda).Column("codigoTipoMoneda").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.Iva).Column("codigoIva").Cascade.None().LazyLoad(Laziness.Proxy);

            HasManyToMany<Entrega>(x => x.Entregas).Table("EntregasPorFactura").ParentKeyColumn("codigoFactura").ChildKeyColumn("codigoEntrega").Cascade.None();
        }
    }
}
