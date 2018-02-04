using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana_3
{
    class Classuapa
    {
        public string Resulatado(int x,int y, int z,int m, int n)
        
        {
           int s = x + y + z+ m +n;

            return s.ToString();
            
        }

        public string Condicion(int x)
        {
            if(x >=70)
            {
                return "Aprobado";
            }

            else
            {
                return "Reprobado";
            }

            
        }
        public string Literal(int x)
        {
            if(x >= 90 && x <= 100)
            {
                return "A";
            }

            else if(x >= 80 && x <= 89)
            {
                return "B";
            }

            else if( x >= 70 && x <= 79)
            {
                return "C";
            }

            else if(x >= 60 && x <= 69)
            {
                return "D";
            }

            else
            {
                return "F";
            }
        }
    }
}
