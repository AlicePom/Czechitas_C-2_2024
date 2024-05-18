using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsluha_výjimek
{
    public class BezpecneDeleni
    {
        
        public double PodilCisla(double a, double b)
        {
            // když mi uživatel zadá b = 0, tak si s tím neumím poradit
            // chci, aby to skončilo chybou
            if (b == 0)
            {
                //throw new ArgumentException();
                throw new ArgumentException("Nulou nelze dělit!");
            }

            return a / b;
        }
        public BezpecneDeleni()
        {

        }
    }
}
