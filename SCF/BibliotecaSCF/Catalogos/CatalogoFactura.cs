using BibliotecaSCF.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace BibliotecaSCF.Catalogos
{
  public class CatalogoFactura : CatalogoGenerico<Factura>
  {
    /// <summary>
    /// Returns last Factura from DB by PuntoDeVenta id
    /// </summary>
    /// <param name="codigoPuntoDeVenta">Id of PuntoDeVenta</param>
    /// <param name="nhSesion">Hibernate session</param>
    /// <returns>A Factura object</returns>
    public static Factura RecuperarUltima(int codigoPuntoDeVenta, NHibernate.ISession nhSesion)
    {
        try
        {
          var factura = codigoPuntoDeVenta < 0 ? nhSesion.QueryOver<Factura>() : nhSesion.QueryOver<Factura>().Where(x => x.PuntoDeVenta.Codigo == codigoPuntoDeVenta);

          return factura.OrderBy(x => x.Codigo).Desc.Take(1).SingleOrDefault();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Returns last Factura from DB
    /// </summary>
    /// <param name="nhSesion">Hibernate session</param>
    /// <returns>A Factura object</returns>
    public static Factura RecuperarUltima(NHibernate.ISession nhSesion)
    {
      return RecuperarUltima(-1, nhSesion);
    }

    public static List<Factura> RecuperarPorEntrega(int codigoEntrega, NHibernate.ISession nhSesion)
    {
        try
        {
            List<Factura> listaFacturas = nhSesion.Query<Factura>().Where(x => x.Entregas.Any(e => e.Codigo == codigoEntrega)).ToList();
            return listaFacturas;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static List<Factura> RecuperarPorPuntoDeVenta(int codigoPuntoDeVenta, NHibernate.ISession nhSession)
    {
      try
      {
        var date = new DateTime(2020, 01, 01);

        var listaFacturas = nhSession.Query<Factura>().Where(x => x.PuntoDeVenta.Codigo == codigoPuntoDeVenta && x.FechaFacturacion >= date).ToList();
        return listaFacturas;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
