using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class EntregaMap : ClassMap<Entrega>
    {
        public EntregaMap()
        {
            Table("Entregas");
            Id(x => x.Codigo).Column("codigoEntrega").GeneratedBy.Identity();
            Map(x => x.FechaEmision).Column("fechaEmision");
            Map(x => x.NumeroRemito).Column("numeroRemito");
            Map(x => x.CodigoEstado).Column("codigoEstado");
            Map(x => x.Observaciones).Column("observaciones");
            Map(x => x.Cai).Column("cai");
            Map(x => x.FechaVencimientoCai).Column("fechaVencimientoCai");

            References(x => x.NotaDePedido).Column("codigoNotaDePedido").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.Transporte).Column("codigoTransporte").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.Direccion).Column("codigoDireccion").Cascade.None().LazyLoad(Laziness.Proxy);
            HasMany<ItemEntrega>(x => x.ItemsEntrega).KeyColumn("codigoEntrega").Not.KeyNullable().Cascade.AllDeleteOrphan();
        }
    }
}
