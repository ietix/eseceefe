using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class NotaDeCreditoMap : ClassMap<NotaDeCredito>
    {
        public NotaDeCreditoMap()
        {
            Table("NotasDeCredito");
            Id(x => x.Codigo).Column("codigoNotaDeCredito").GeneratedBy.Identity();
            Map(x => x.NumeroNotaDeCredito).Column("numeroNotaDeCredito");
            Map(x => x.IsFacturaCompleta).Column("isFacturaCompleta");
            Map(x => x.Total).Column("total");
            Map(x => x.Subtotal).Column("subtotal");
            Map(x => x.FechaHoraNotaDeCredito).Column("fechaHoraNotaDeCredito");
            Map(x => x.CAE).Column("cae");
            Map(x => x.FechaHoraVencimientoCAE).Column("fechaHoraVencimientoCAE");

            References(x => x.Factura).Column("codigoFactura").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.TipoComprobante).Column("codigoTipoComprobante").Cascade.None().LazyLoad(Laziness.Proxy);
            HasMany<ItemNotaDeCredito>(x => x.ItemsNotaDeCredito).KeyColumn("codigoNotaDeCredito").Not.KeyNullable().Cascade.AllDeleteOrphan();
        }
    }
}
