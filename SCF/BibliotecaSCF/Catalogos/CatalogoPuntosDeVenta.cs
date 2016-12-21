using BibliotecaSCF.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace BibliotecaSCF.Catalogos
{
    public class CatalogoPuntosDeVenta : CatalogoGenerico<PuntosDeVenta>
    {
      /// <summary>
      /// Returns PuntoDeVenta by TipoComprobante id
      /// </summary>
      /// <param name="codigoTipoComprobante">Id of TipoComprobante, can be null</param>
      /// <param name="nhSesion">Hibernate session</param>
      /// <returns>A list of PuntosDeVenta</returns>
      public static List<PuntosDeVenta> RecuperarPorTipoComprobante(int? codigoTipoComprobante, NHibernate.ISession nhSesion)
      {
        try
        {
          var listaPuntoDeVenta = nhSesion.Query<PuntosDeVenta>().Where(x => x.TipoComprobante.Codigo == codigoTipoComprobante).ToList();
          return listaPuntoDeVenta;
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }

      /// <summary>
      /// Returns PuntoDeVenta by parent PuntoDeVenta id
      /// </summary>
      /// <param name="codigoPuntoDeVentaSuperior">Id of parent PuntoDeVenta</param>
      /// <param name="nhSession">Hibernate session</param>
      /// <returns>A list of PuntosDeVenta</returns>
      public static List<PuntosDeVenta> RecuperarPorPuntoDeVentaSuperior(int codigoPuntoDeVentaSuperior, NHibernate.ISession nhSession)
      {
        try
        {
          var listaPuntoDeVenta = nhSession.Query<PuntosDeVenta>().Where(x => x.PuntoDeVentaSuperior.Codigo == codigoPuntoDeVentaSuperior).ToList();
          return listaPuntoDeVenta;
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }
}
