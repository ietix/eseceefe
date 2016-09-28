using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class Articulo
    {
        public Articulo()
        {
            ArticulosProveedor = new List<ArticuloProveedor>();
            ArticulosClientes = new List<ArticuloCliente>();
            HistorialesPrecio = new List<HistorialPrecio>();
        }

        public virtual int Codigo { get; set; }
        public virtual string DescripcionCorta { get; set; }
        public virtual string DescripcionLarga { get; set; }
        public virtual string Marca { get; set; }
        public virtual string NombreImagen { get; set; }

        public virtual UnidadMedida UnidadMedida { get; set; }
        public virtual IList<ArticuloProveedor> ArticulosProveedor { get; set; }
        public virtual IList<ArticuloCliente> ArticulosClientes { get; set; }
        public virtual IList<HistorialPrecio> HistorialesPrecio { get; set; }

        public virtual HistorialPrecio RecuperarHistorialPrecioActual()
        {
            return this.HistorialesPrecio.Where(x => x.FechaHasta == null).SingleOrDefault();
        }
    }
}
