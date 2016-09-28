using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class ArticuloProveedorMap : ClassMap<ArticuloProveedor>
    {
        public ArticuloProveedorMap()
        {
            Table("ArticulosProveedor");
            Id(x => x.Codigo).Column("codigoArticuloProveedor").GeneratedBy.Identity();

            References(x => x.Proveedor).Column("codigoProveedor").Cascade.None().Nullable().LazyLoad(Laziness.Proxy);
            HasMany<HistorialCosto>(x => x.HistorialesCosto).KeyColumn("codigoArticuloProveedor").Not.KeyNullable().Cascade.AllDeleteOrphan();
        }
    }
}
