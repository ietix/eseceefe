using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class Cliente
    {
        public Cliente()
        {
            Direcciones = new List<Direccion>();
        }

        public virtual int Codigo { get; set; }
        public virtual int NumeroInterno { get; set; }
        public virtual string RazonSocial { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Mail { get; set; }
        public virtual string NumeroDocumento { get; set; }
        public virtual string PersonaContacto { get; set; }
        public virtual string NumeroCuenta { get; set; }
        public virtual string Banco { get; set; }
        public virtual string Cbu { get; set; }
        public virtual string Observaciones { get; set; }
        public virtual bool IsInactivo { get; set; }
        public virtual string CodigoSCF { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual IList<Direccion> Direcciones { get; set; }
    }
}
