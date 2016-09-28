using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class ItemNotaDeCreditoMap : ClassMap<ItemNotaDeCredito>
    {
        public ItemNotaDeCreditoMap()
        {
            Table("ItemsNotaDeCredito");
            Id(x => x.Codigo).Column("codigoItemNotaDeCredito").GeneratedBy.Identity();
            Map(x => x.Cantidad).Column("cantidad");

            References(x => x.ItemEntrega).Column("codigoItemEntrega").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
