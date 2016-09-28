using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class TipoMonedaMap : ClassMap<TipoMoneda>
    {
        public TipoMonedaMap()
        {
            Table("AFIP_TiposMonedas");
            Id(x => x.Codigo).Column("codigoTipoMoneda").GeneratedBy.Identity();
            Map(x => x.CodigoAFIP).Column("codigoTipoMonedaAFIP");
            Map(x => x.Descripcion).Column("descripcion");
            Map(x => x.Abreviatura).Column("abreviatura");
        }
    }
}
