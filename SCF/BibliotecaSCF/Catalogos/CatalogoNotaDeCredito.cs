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

        //public static List<NotaDeCredito> RecuperarPorEntrega(int codigoEntrega, NHibernate.ISession nhSesion)
        //{
        //    try
        //    {
        //        List<Factura> listaFacturas = nhSesion.Query<Factura>().Where(x => x.Entregas.Any(e => e.Codigo == codigoEntrega)).ToList();
        //        return listaFacturas;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
