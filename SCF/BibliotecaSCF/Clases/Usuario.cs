using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.Clases
{
    public class Usuario
    {
        public virtual int Codigo { get; set; }
        public virtual string NombreUsuario { get; set; }
        public virtual string Contraseña { get; set; }
    }
}
