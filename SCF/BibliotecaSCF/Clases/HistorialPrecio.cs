using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class HistorialPrecio
    {
        public virtual int Codigo { get; set; }
        public virtual DateTime FechaDesde { get; set; }
        public virtual DateTime? FechaHasta { get; set; }
        public virtual double Precio { get; set; }

        public virtual TipoMoneda Moneda { get; set; }
    }
}
