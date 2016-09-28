using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class ArticuloCliente
    {
        public virtual int Codigo { get; set; }
        public virtual string CodigoInterno { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
