using BibliotecaSCF.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace BibliotecaSCF.Catalogos
{
    public class CatalogoReporte : CatalogoGenerico<Reporte>
    {
      /// <summary>
      /// Returns Reports by PuntoDeVenta id
      /// </summary>
      /// <param name="codigoPuntoDeVenta">Id of PuntoDeVenta</param>
      /// <param name="nhSession">Hibernate session</param>
      /// <returns>A list of Reporte</returns>
      public static List<Reporte> RecuperarPorPuntoDeVenta(int? codigoPuntoDeVenta, NHibernate.ISession nhSession)
      {
        try
        {
          var listaReporte = nhSession.Query<Reporte>().Where(x => x.PuntosDeVentas.Any(a => a.Codigo == codigoPuntoDeVenta)).ToList();
          return listaReporte;
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }
}
