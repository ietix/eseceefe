using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class PuntosDeVentaMap : ClassMap<PuntosDeVenta>
    {
      public PuntosDeVentaMap()
        {
          Table("PuntosDeVenta");
          Id(x => x.Codigo).Column("codigoPuntoDeVenta").GeneratedBy.Identity();
          Map(x => x.Descripcion).Column("descripcion");
          Map(x => x.Numero).Column("numeroPuntoDeVenta");
          Map(x => x.NumeroActual).Column("numeroActual");
          Map(x => x.NumeroFinal).Column("numeroFinal");
          Map(x => x.NumeroInicial).Column("numeroInicial");

          References(x => x.TipoComprobante).Column("codigoTipoComprobante").Cascade.None().LazyLoad(Laziness.Proxy);
          References(x => x.PuntoDeVentaSuperior).Column("codigoPuntoDeVentaParent").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
