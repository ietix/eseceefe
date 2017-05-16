using BibliotecaSCF.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace BibliotecaSCF.Catalogos
{
  public class CatalogoNotaDePedido : CatalogoGenerico<NotaDePedido>
  {
    public static List<NotaDePedido> RecuperarPorArticulo(int codigoArticulo, NHibernate.ISession nhSesion)
    {
      try
      {
        List<NotaDePedido> listaNP = nhSesion.Query<NotaDePedido>().Where(x => x.ItemsNotaDePedido.Any(i => i.Articulo.Codigo == codigoArticulo)).ToList();
        return listaNP;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    /// Retireves a list of NotaDePedido by date
    /// </summary>
    /// <param name="fechaDesde">From date</param>
    /// <param name="fechaHasta">To date</param>
    /// <returns>A list of class NotaDePedido</returns>
    public static List<NotaDePedido> RecuperarPorFecha(DateTime fechaDesde, DateTime fechaHasta, NHibernate.ISession nhSesion)
    {
      try
      {
        var result = nhSesion.Query<NotaDePedido>().Where(x => x.FechaEmision >= fechaDesde && x.FechaEmision <= fechaHasta).ToList();
        return result;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static NotaDePedido RecuperarUltima(NHibernate.ISession nhSesion)
    {
      try
      {
        NotaDePedido notaDePedido = nhSesion.QueryOver<NotaDePedido>().OrderBy(x => x.Codigo).Desc.Take(1).SingleOrDefault();
        return notaDePedido;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
