using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
   public class UnidadMedidaMap : ClassMap<UnidadMedida>
    {
       public UnidadMedidaMap()
        {
            Table("AFIP_UnidadesMedida");
            Id(x => x.Codigo).Column("codigoUnidadMedida").GeneratedBy.Identity();
            Map(x => x.Abreviatura).Column("abreviatura");
            Map(x => x.Descripcion).Column("descripcion");
        }
    }
}
