using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class ItemEntregaMap : ClassMap<ItemEntrega>
    {
        public ItemEntregaMap()
        {
            Table("ItemsEntrega");
            Id(x => x.Codigo).Column("codigoItemEntrega").GeneratedBy.Identity();
            Map(x => x.CantidadAEntregar).Column("cantidad");
            Map(x => x.Precio).Column("precio");

            References(x => x.ArticuloProveedor).Column("codigoArticuloProveedor").Cascade.None().Nullable().LazyLoad(Laziness.Proxy);
            References(x => x.ItemNotaDePedido).Column("codigoItemNotaDePedido").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
