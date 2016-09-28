using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class ContratoMarco
    {
        public ContratoMarco()
        {
            ItemsContratoMarco = new List<ItemContratoMarco>();
        }

        public virtual int Codigo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual DateTime FechaInicio { get; set; }
        public virtual DateTime FechaFin { get; set; }
        public virtual string Comprador { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual IList<ItemContratoMarco> ItemsContratoMarco { get; set; }
    }
}
