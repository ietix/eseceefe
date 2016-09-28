using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class ItemNotaDePedidoMap : ClassMap<ItemNotaDePedido>
    {
        public ItemNotaDePedidoMap()
        {
            Table("ItemsNotaDePedido");
            Id(x => x.Codigo).Column("codigoItemNotaDePedido").GeneratedBy.Identity();
            Map(x => x.CantidadPedida).Column("cantidad");
            Map(x => x.FechaEntrega).Column("fechaEntrega");
            Map(x => x.Precio).Column("precio");
            Map(x => x.Posicion).Column("posicion");

            References(x => x.Articulo).Column("codigoArticulo").Cascade.None().Nullable().LazyLoad(Laziness.Proxy);
        }
    }
}