using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class DireccionMap : ClassMap<Direccion>
    {
        public DireccionMap()
        {
            Table("Direcciones");
            Id(x => x.Codigo).Column("codigoDireccion").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
            Map(x => x.Provincia).Column("provincia");
            Map(x => x.Localidad).Column("localidad");
        }
    }
}
