using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSCF.ClasesComplementarias
{
    public class Constantes
    {
        public class Estados
        {
            public const int ANULADA = 1;
            public const int ENTREGADA = 2;
            public const int VIGENTE = 3;
            public const int PROXIMA_VENCER = 4; //estado calculado
            public const int VENCIDA = 5; //estado calculado
        }

        public class Moneda
        {
            public const int PESO = 1;
            public const int DOLAR = 2;
            public const int EURO = 3;
        }
    }
}
