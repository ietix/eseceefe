using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class HistorialPrecioMap : ClassMap<HistorialPrecio>
    {
        public HistorialPrecioMap()
        {
            Table("HistorialPreciosArticulo");
            Id(x => x.Codigo).Column("codigoHistorialPrecioArticulo").GeneratedBy.Identity();
            Map(x => x.FechaDesde).Column("fechaDesde");
            Map(x => x.FechaHasta).Column("fechaHasta");
            Map(x => x.Precio).Column("precio");

            References(x => x.Moneda).Column("codigoTipoMoneda").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
