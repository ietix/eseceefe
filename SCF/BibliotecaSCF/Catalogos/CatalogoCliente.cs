using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using NHibernate.Linq;

namespace BibliotecaSCF.Catalogos
{
    public class CatalogoCliente : CatalogoGenerico<Cliente>
    {
        public static Cliente RecuperarPorRazonSocial(string razonSocial, NHibernate.ISession nhSesion)
        {
            try
            {
                Cliente cliente = nhSesion.Query<Cliente>().Where(x => x.RazonSocial.ToUpper() == razonSocial.ToUpper()).SingleOrDefault();
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
