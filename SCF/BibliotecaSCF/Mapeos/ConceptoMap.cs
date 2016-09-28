using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class ConceptoMap : ClassMap<Concepto>
    {
        public ConceptoMap()
        {
            Table("AFIP_ConceptosIncluidos");
            Id(x => x.Codigo).Column("codigoConcepto").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
        }
    }
}
