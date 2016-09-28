using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaSCF.Mapeos
{
    public class UsuarioMap : ClassMap<Usuario>
    {
         public UsuarioMap()
        {
            Table("Usuarios");
            Id(x => x.Codigo).Column("codigoUsuario").GeneratedBy.Identity();
            Map(x => x.NombreUsuario).Column("nombreUsuario");
            Map(x => x.Contraseña).Column("contraseña");            
        }
    }
}
