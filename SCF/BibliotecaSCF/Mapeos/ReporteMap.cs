using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class ReporteMap : ClassMap<Reporte>
    {
      public ReporteMap()
        {
          Table("Reportes");
          Id(x => x.Codigo).Column("codigoReporte").GeneratedBy.Identity();
          Map(x => x.NombreReporte).Column("nombreReporte");
          Map(x => x.PathReporte1).Column("pathReporte1");
          Map(x => x.PathReporte2).Column("pathReporte2");
          Map(x => x.PathReporte3).Column("pathReporte3");

          HasManyToMany<PuntosDeVenta>(x => x.PuntosDeVentas).Table("ReportesPorPuntoDeVenta").ParentKeyColumn("codigoReporte").ChildKeyColumn("codigoPuntoDeVenta").Cascade.None();
        }
    }
}
