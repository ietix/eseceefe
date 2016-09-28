using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class IvaMap : ClassMap<Iva>
    {
        public IvaMap()
        {
            Table("AFIP_Iva");
            Id(x => x.Codigo).Column("codigoIva").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
        }
    }
}
