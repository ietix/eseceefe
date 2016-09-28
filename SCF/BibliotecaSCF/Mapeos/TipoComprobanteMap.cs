using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class TipoComprobanteMap : ClassMap<TipoComprobante>
    {
        public TipoComprobanteMap()
        {
            Table("AFIP_TiposComprobante");
            Id(x => x.Codigo).Column("codigoTipoComprobante").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
        }
    }
}
