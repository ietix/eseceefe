using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class HistorialCostoMap : ClassMap<HistorialCosto>
    {
        public HistorialCostoMap()
        {
            Table("HistorialCostosArticuloProveedor");
            Id(x => x.Codigo).Column("codigoHistorialCostoArticuloProveedor").GeneratedBy.Identity();
            Map(x => x.FechaDesde).Column("fechaDesde");
            Map(x => x.FechaHasta).Column("fechaHasta");
            Map(x => x.Costo).Column("costo");

            References(x => x.Moneda).Column("codigoTipoMoneda").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
