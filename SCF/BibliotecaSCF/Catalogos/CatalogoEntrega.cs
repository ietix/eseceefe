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
  

  public class CatalogoEntrega : CatalogoGenerico<Entrega>
    {
      public static Entrega RecuperarUltima(int codigoPuntoDeVenta, ISession nhSesion)
      {
        try
        {
          var entrega = codigoPuntoDeVenta < 0 ? nhSesion.QueryOver<Entrega>() : nhSesion.QueryOver<Entrega>().Where(x => x.PuntoDeVenta.Codigo == codigoPuntoDeVenta);
          
          return entrega.OrderBy(x => x.Codigo).Desc.Take(1).SingleOrDefault();
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }

      public static Entrega RecuperarUltima(ISession nhSesion)
      {
        return RecuperarUltima(-1, nhSesion);
      }

        /// <summary>
        /// Devuelve TRUE si un item entrega esta asociado a un remito sino devuelve FALSE
        /// </summary>
        /// <param name="codigoItemEntrega"></param>
        /// <returns></returns>
        public static bool TieneRemito(int codigoItemNotaDePedido, ISession nhSesion)
        {
            try
            {
                List<Entrega> listaEntregas = nhSesion.Query<Entrega>().Where(e => e.ItemsEntrega.Any(ie => ie.ItemNotaDePedido.Codigo == codigoItemNotaDePedido)).ToList();
                return listaEntregas.Count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Entrega> RecuperarLasQueNoEstanEnLaLista(List<Entrega> listaEntregas, ISession nhSesion)
        {
            try
            {
                List<int> listaCodigos = (from e in listaEntregas select e.Codigo).ToList();
                List<Entrega> lista = nhSesion.QueryOver<Entrega>().WhereRestrictionOn(x => x.Codigo).Not.IsIn(listaCodigos).List().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      public static List<Entrega> RecuperarPorPuntoDeVenta(int codigoPuntoDeVenta, NHibernate.ISession nhSession)
      {
        try
        {
          var listaEntregas = nhSession.Query<Entrega>().Where(x => x.PuntoDeVenta.Codigo == codigoPuntoDeVenta).ToList();
          return listaEntregas;
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }
}
