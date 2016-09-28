using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class ContratoMarcoMap : ClassMap<ContratoMarco>
    {
        public ContratoMarcoMap()
        {
            Table("ContratosMarco");
            Id(x => x.Codigo).Column("codigoContratoMarco").GeneratedBy.Identity();
            Map(x => x.FechaInicio).Column("fechaInicio");
            Map(x => x.FechaFin).Column("fechaFin");
            Map(x => x.Descripcion).Column("descripcion");
            Map(x => x.Comprador).Column("comprador");

            References(x => x.Cliente).Column("codigoCliente").Cascade.None().Nullable().LazyLoad(Laziness.Proxy);
            HasMany<ItemContratoMarco>(x => x.ItemsContratoMarco).KeyColumn("codigoContratoMarco").Not.KeyNullable().Cascade.AllDeleteOrphan();
        }
    }
}
