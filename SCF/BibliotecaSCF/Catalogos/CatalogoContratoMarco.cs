using BibliotecaSCF.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace BibliotecaSCF.Catalogos
{
    public class CatalogoContratoMarco : CatalogoGenerico<ContratoMarco>
    {
        public static List<ContratoMarco> RecuperarVigentePorClienteYArticulo(int codigoCliente, int codigoArticulo, NHibernate.ISession nhSesion)
        {
            try
            {
                List<ContratoMarco> listaContratosMarco = nhSesion.Query<ContratoMarco>().Where(cm => cm.FechaInicio < DateTime.Now && cm.FechaFin > DateTime.Now && cm.Cliente.Codigo == codigoCliente && cm.ItemsContratoMarco.Any(x => x.Articulo.Codigo == codigoArticulo)).ToList();
                return listaContratosMarco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
