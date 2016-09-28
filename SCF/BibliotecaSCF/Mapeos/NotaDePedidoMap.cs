using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class NotaDePedidoMap : ClassMap<NotaDePedido>
    {
        public NotaDePedidoMap()
        {
            Table("NotasDePedido");
            Id(x => x.Codigo).Column("codigoNotaDePedido").GeneratedBy.Identity();
            Map(x => x.NumeroInternoCliente).Column("numeroInternoCliente");
            Map(x => x.FechaEmision).Column("fechaEmision");
            Map(x => x.CodigoEstado).Column("codigoEstado");
            Map(x => x.Observaciones).Column("observaciones");

            References(x => x.ContratoMarco).Column("codigoContratoMarco").Cascade.None().Nullable().LazyLoad(Laziness.Proxy);
            References(x => x.Cliente).Column("codigoCliente").Cascade.None().LazyLoad(Laziness.Proxy);
            HasMany<ItemNotaDePedido>(x => x.ItemsNotaDePedido).KeyColumn("codigoNotaDePedido").Not.KeyNullable().Cascade.AllDeleteOrphan();
        }
    }
}
