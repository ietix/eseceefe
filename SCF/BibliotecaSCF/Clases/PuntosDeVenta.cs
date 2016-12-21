using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
  public class PuntosDeVenta
  {
    public virtual int Codigo { get; set; }
    public virtual int Numero { get; set; }
    public virtual string Descripcion { get; set; }
    public virtual int NumeroInicial { get; set; }
    public virtual int NumeroActual { get; set; }
    public virtual int NumeroFinal { get; set; }
    public virtual TipoComprobante TipoComprobante { get; set; }
    public virtual PuntosDeVenta PuntoDeVentaSuperior { get; set; }
  }
}
