using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.ClasesComplementarias
{
    public class ManejoDeNHibernate
    {
        private static ISessionFactory singleton;

        private static ISessionFactory CrearSesion()
        {
            if (singleton == null)
            {
              var connStr = ConfigurationManager.ConnectionStrings["scfConnStr"].ConnectionString;
               
              singleton = Fluently.Configure()

              // .Database(MsSqlConfiguration.MsSql2012.ConnectionString("data source=SUPLENTE4-PC\\EZEQUIELSQL;initial catalog=SCF;Integrated Security=SSPI;"))//Eze trabajo
              //.Database(MsSqlConfiguration.MsSql2012.ConnectionString("data source=TSIS0220\\SQLEXPRESS;initial catalog=SCF;Integrated Security=SSPI;"))
              //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=SCF;Integrated Security=SSPI;"))//Eze PC
              //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=SCF;user=sa;password=ana"))//Nico PC 
              //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=w1402088_SCF;user=w1402088_SCF;password=Algoritmos2015"))//Hosting
              //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=sql5018.mywindowshosting.com;initial catalog=DB_A0CD9B_scf;user=DB_A0CD9B_scf_admin;password=hankSkorp1o"))
              //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=wi151672_DB;Integrated Security=SSPI;"))//Hosting_Nuevo
              .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connStr))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ModuloPrueba>())
              .BuildSessionFactory();
            }

            return singleton;
        }

        public static ISession IniciarSesion()
        {
            return CrearSesion().OpenSession();
        }
    }
}
