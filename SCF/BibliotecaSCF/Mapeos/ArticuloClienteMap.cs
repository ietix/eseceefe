using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class ArticuloClienteMap : ClassMap<ArticuloCliente>
    {
        public ArticuloClienteMap()
        {
            Table("ArticulosCliente");
            Id(x => x.Codigo).Column("codigoArticuloCliente").GeneratedBy.Identity();
            Map(x => x.CodigoInterno).Column("numeroInternoCliente");

            References(x => x.Cliente).Column("codigoCliente").Cascade.None().Nullable().LazyLoad(Laziness.Proxy);
        }
    }
}
