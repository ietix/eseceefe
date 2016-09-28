using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class ItemNotaDeCredito
    {
        public virtual int Codigo { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual ItemEntrega ItemEntrega { get; set; }

        private static DataTable Tabla
        {
            get
            {
                DataTable tablaItemNotaDeCredito = new DataTable();
                tablaItemNotaDeCredito.Columns.Add("codigoItemNotaDeCredito");
                tablaItemNotaDeCredito.Columns.Add("cantidad");
                tablaItemNotaDeCredito.Columns.Add("codigoItemEntrega");
                tablaItemNotaDeCredito.Columns.Add("codigoArticulo");
                tablaItemNotaDeCredito.Columns.Add("descripcionCorta");
                tablaItemNotaDeCredito.Columns.Add("cantidadAEntregar"); //Cantidad del item entrega
                tablaItemNotaDeCredito.Columns.Add("posicion");
                tablaItemNotaDeCredito.Columns.Add("precioUnitario");
                tablaItemNotaDeCredito.Columns.Add("precioTotal");

                return tablaItemNotaDeCredito;
            }
        }

        /// <summary>
        /// Recupera una tabla con la lista completa de los items nota de credito
        /// </summary>
        /// <param name="listaItemsNotasDeCredito"></param>
        /// <returns></returns>
        public static DataTable RecuperarTabla(List<ItemNotaDeCredito> listaItemsNotasDeCredito)
        {
            DataTable tablaNotasDeCredito = Tabla;

            listaItemsNotasDeCredito.Aggregate(tablaNotasDeCredito, (dt, r) =>
            {
                dt.Rows.Add(r.Codigo, r.Cantidad, r.ItemEntrega.Codigo, r.ItemEntrega.ItemNotaDePedido.Articulo.Codigo, r.ItemEntrega.ItemNotaDePedido.Articulo.DescripcionCorta, r.ItemEntrega.CantidadAEntregar, r.ItemEntrega.ItemNotaDePedido.Posicion,
                    r.ItemEntrega.Precio, r.ItemEntrega.Precio * r.ItemEntrega.CantidadAEntregar);
                return dt;
            });

            return tablaNotasDeCredito;
        }

        /// <summary>
        /// Recupera una tabla para un item nota de credito
        /// </summary>
        /// <param name="itemNotaDeCredito"></param>
        /// <returns></returns>
        public static DataTable RecuperarTabla(ItemNotaDeCredito itemNotaDeCredito)
        {
            DataTable tablaNotaDeCredito = Tabla;
            tablaNotaDeCredito.Rows.Add(itemNotaDeCredito.Codigo, itemNotaDeCredito.Cantidad, itemNotaDeCredito.ItemEntrega.Codigo, itemNotaDeCredito.ItemEntrega.ItemNotaDePedido.Articulo.Codigo, itemNotaDeCredito.ItemEntrega.ItemNotaDePedido.Articulo.DescripcionCorta, itemNotaDeCredito.ItemEntrega.CantidadAEntregar);

            return tablaNotaDeCredito;
        }
    }
}
