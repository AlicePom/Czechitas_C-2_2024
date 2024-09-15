using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_6_lekce_breakoutroom_Obdelnik
{
    /* Vyuzij tridu Obdelnik z prvniho BR.
   Prepis fieldy Sirka a Vyska na properties.
   Nastavte properties tak, aby je nebylo mozne zmenit po vytvoreni instance.  
   Vytvorte property Obsah, ktera umozni ziskat obsah obdelniku.
   Vytvorte property Obvod, ktera umozni ziskat obvod obdelniku.
   Vytvorte funkci Zvetsi, ktera zvetsi obdelnik o sirku a vysku.
   Zajistete, aby nebylo mozne vytvorit obdelnik o obsahu 0 (vypiste hlasku a nastavte hodnotu na 1).
   Napiste program, ktery vytvori obdelnik, vypise jeho velikosti, obsah a obvod.
*/
    public class Obdelnik
    {
        private int pomocnaSirka;
        public int Sirka
        {
            get
            {
                return pomocnaSirka;
            }
            private set
            {
                if (value <= 0)
                {
                    pomocnaSirka = 1;
                    Console.WriteLine("Rozměry objektu nesmějí být menší nebo rovny nule!");
                }
                else
                {
                    pomocnaSirka = value;
                }
            }
        }

        private int pomocnaDelka;
        public int Delka
        {
            get
            {
                return pomocnaDelka;
            }
            private set
            {
                if (value <= 0)
                {
                    pomocnaDelka = 1;
                    Console.WriteLine("Rozměry objektu nesmějí být menší nebo rovny nule!");
                }
                else
                {
                    pomocnaDelka = value;
                }
            }
        }

        public int Obsah
        {
            get
            {
                return Sirka * Delka;
            }
        }
        public int Obvod
        {
            get
            {
                return 2 * (Sirka + Delka);
            }
        }

        public Obdelnik(int sirka, int delka)
        {
            Sirka = sirka;
            Delka = delka;
        }

        public Obdelnik(int sirka) : this(sirka, sirka)
        {

        }

        public void Zvetsi(int a, int b)
        {
            Sirka += a;
            Delka += b;
        }

        public void VypisInformace()
        {
            string objekt;
            if (Sirka == Delka)
            {
                objekt = "čtverec";
            }
            else
            {
                objekt = "obdélník";
            }
            Console.WriteLine($"Objekt je {objekt} o rozměrech {Sirka}x{Delka} cm, jeho obvod je {Obvod} cm a obsah {Obsah} cm2.");
        }
    }
}