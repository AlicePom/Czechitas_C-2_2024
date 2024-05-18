using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_6_lekce_breakoutroom_Obdelnik
{
    internal class Obdelnik
    {
        public int Sirka;
        public int Vyska;

        public Obdelnik(int sirka, int vyska)
        {
            Sirka = sirka;
            Vyska = vyska;
        }

        public Obdelnik(int sirka) : this(sirka, sirka)
        {
        }

        public void VypisInformace()
        {
            if (Sirka == Vyska)
            {
                Console.WriteLine($"Čtverec - délka strany: {Sirka} cm.");
            }
            else
            {
                Console.WriteLine($"Obdélník - výška: {Vyska} cm, šířka: {Sirka} cm.");
            }
        }
    }
}
