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
        public static Entrega RecuperarUltima(ISession nhSesion)
        {
            try
            {
                Entrega entrega = nhSesion.QueryOver<Entrega>().OrderBy(x => x.Codigo).Desc.Take(1).SingleOrDefault();
                return entrega;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
    }
}
