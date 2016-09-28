using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class TipoDocumentoMap : ClassMap<TipoDocumento>
    {
        public TipoDocumentoMap()
        {
            Table("AFIP_TiposDocumento");
            Id(x => x.Codigo).Column("codigoTipoDocumento").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
        }
    }
}
