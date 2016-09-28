using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class ItemContratoMarco
    {
        public virtual int Codigo { get; set; }
        public virtual double Precio { get; set; }
        public virtual int Posicion { get; set; }

        public virtual Articulo Articulo { get; set; }
        public virtual TipoMoneda TipoMoneda { get; set; }
    }
}
