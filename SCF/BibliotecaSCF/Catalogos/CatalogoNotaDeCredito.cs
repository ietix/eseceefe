using BibliotecaSCF.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace BibliotecaSCF.Catalogos
{
  public class CatalogoNotaDeCredito : CatalogoGenerico<NotaDeCredito>
  {
    public static NotaDeCredito RecuperarUltima(NHibernate.ISession nhSesion)
    {
      try
      {
        NotaDeCredito NotaDeCredito = nhSesion.QueryOver<NotaDeCredito>().OrderBy(x => x.Codigo).Desc.Take(1).SingleOrDefault();
        return NotaDeCredito;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static List<NotaDeCredito> RecuperarNotasDeCreditoPorPuntoDeVenta(int codigoPuntoDeVenta, NHibernate.ISession nhSession)
    {
      try
      {
        var listaNotasDeCredito = nhSession.Query<NotaDeCredito>().Where(x => x.PuntoDeVenta.Codigo == codigoPuntoDeVenta).ToList();
        return listaNotasDeCredito;
      }
      catch (Exception ex)
      {
        
        throw ex;
      }
    }
  }
}
