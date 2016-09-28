using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class NotaDePedido
    {
        public NotaDePedido()
        {
            ItemsNotaDePedido = new List<ItemNotaDePedido>();
        }

        public virtual int Codigo { get; set; }
        public virtual string NumeroInternoCliente { get; set; }
        public virtual DateTime FechaEmision { get; set; }
        public virtual int CodigoEstado { get; set; }
        public virtual string Observaciones { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ContratoMarco ContratoMarco { get; set; }
        public virtual IList<ItemNotaDePedido> ItemsNotaDePedido { get; set; }
    }
}
