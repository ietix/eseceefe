using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Clases;

namespace BibliotecaSCF.Catalogos
{
    public class CatalogoUsuario : CatalogoGenerico<Usuario>
    {
        public static Usuario RecuperarPorUsuarioYContraseña(string nombreUsuario, string contraseña, NHibernate.ISession nhSesion)
        {
            try
            {
                Usuario usuario = RecuperarPor(x => x.Contraseña == contraseña && x.NombreUsuario == nombreUsuario, nhSesion);
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
