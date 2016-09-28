using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class Direccion
    {
        public virtual int Codigo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Provincia { get; set; }
        public virtual string Localidad { get; set; }
    }
}
