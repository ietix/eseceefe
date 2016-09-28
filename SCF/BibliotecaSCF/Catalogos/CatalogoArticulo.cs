using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;
using NHibernate;
using NHibernate.Linq;

namespace BibliotecaSCF.Catalogos
{
    public class CatalogoArticulo : CatalogoGenerico<Articulo>
    {
        public static List<Articulo> RecuperarPorCodigoInternoCliente(string codigoInternoCliente, ISession nhSesion)
        {
            try
            {
                List<Articulo> listaArticulos = nhSesion.Query<Articulo>().Where(x => x.ArticulosClientes.Any(ac => ac.CodigoInterno.Contains(codigoInternoCliente))).ToList();
                return listaArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Articulo RecuperarPorClienteYCodigoInternoCliente(string codigoInternoCliente, int codigoCliente, ISession nhSesion)
        {
            try
            {
                Articulo articulo = nhSesion.Query<Articulo>().Where(x => x.ArticulosClientes.Any(ac => ac.CodigoInterno == codigoInternoCliente && ac.Cliente.Codigo == codigoCliente)).SingleOrDefault();
                return articulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Articulo> RecuperarPorCodigoCliente(int codigoCliente, ISession nhSesion)
        {
            try
            {
                List<Articulo> listaArticulos = nhSesion.Query<Articulo>().Where(x => x.ArticulosClientes.Any(ac => ac.Cliente.Codigo == codigoCliente)).ToList();
                return listaArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
