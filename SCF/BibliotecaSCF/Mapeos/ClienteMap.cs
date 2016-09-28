using BibliotecaSCF.Clases;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Mapeos
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Table("Clientes");
            Id(x => x.Codigo).Column("codigoCliente").GeneratedBy.Identity();
            Map(x => x.NumeroInterno).Column("numeroInterno");
            Map(x => x.RazonSocial).Column("razonSocial");
            Map(x => x.Telefono).Column("telefono");
            Map(x => x.Fax).Column("fax");
            Map(x => x.Mail).Column("mail");
            Map(x => x.NumeroDocumento).Column("numeroDocumento");
            Map(x => x.PersonaContacto).Column("personaContacto");
            Map(x => x.NumeroCuenta).Column("numeroCuenta");
            Map(x => x.Banco).Column("banco");
            Map(x => x.Cbu).Column("cbu");
            Map(x => x.Observaciones).Column("observaciones");
            Map(x => x.IsInactivo).Column("isInactivo");
            Map(x => x.CodigoSCF).Column("codigoSCF");

            References(x => x.TipoDocumento).Column("codigoTipoDocumento").Cascade.None().LazyLoad(Laziness.Proxy);
            HasMany<Direccion>(x => x.Direcciones).KeyColumn("codigoCliente").Not.KeyNullable().Cascade.AllDeleteOrphan();
        }
    }
}
