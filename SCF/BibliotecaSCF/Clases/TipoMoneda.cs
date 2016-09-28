using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class TipoMoneda
    {
        public virtual int Codigo { get; set; }
        public virtual string CodigoAFIP { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Abreviatura { get; set; }
    }
}
