using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
  public class Reporte
  {
    public virtual int Codigo { get; set; }
    public virtual string NombreReporte { get; set; }
    public virtual string PathReporte1 { get; set; }
    public virtual string PathReporte2 { get; set; }
    public virtual string PathReporte3 { get; set; }

    public virtual IList<PuntosDeVenta> PuntosDeVentas { get; set; }
  }
}
