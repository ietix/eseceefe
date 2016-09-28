using BibliotecaSCF.ClasesComplementarias;
using BibliotecaSCF.Controladores;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaSCF.Catalogos;

namespace BibliotecaSCF
{
    class ModuloPrueba
    {
        public static void Main()
        {
            //ISession nhSesion = ManejoDeNHibernate.IniciarSesion();

            DataTable t = new DataTable();
            t.Columns.Add("codigoItemNotaDeCredito");
            t.Columns.Add("codigoItemEntrega");
            t.Columns.Add("cantidad");

            t.Rows.Add(new object[] { 0, 49, 1 });
            t.Rows.Add(new object[] { 0, 50, 2 });
            t.Rows.Add(new object[] { 0, 52, 3 });

            ControladorGeneral.InsertarActualizarNotaDeCreditoIncompleta(1, 4, 19, 15, 5, DateTime.Now, 1, t);

            DataTable t2 = ControladorGeneral.RecuperarItemsNotaDeCredito(1);

            //ControladorGeneral.RecuperarNotaDeCredito(1);
            //DataTable t = ControladorGeneral.RecuperarTodasNotasDeCredito();


        }
    }
}
