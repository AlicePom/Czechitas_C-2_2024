namespace C_2_řešení_úkolů_ze_cvičení_z_3.lekce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Ukol

            string palindrom = "Kuna nese nanuk";

            for (int i = palindrom.Length - 1; i >= 0; i--)
            {
                Console.Write(palindrom[i]);
            }

            Console.WriteLine();


            // 2. Ukol - Napiste funkci, ktera umi detekovat, ze se jedna o palindrom(zatim jen u slov) a pak z pole vypiste jen palindromy

            string[] slova = new string[] { "kajak", "program", "rotor", "Czechitas", "madam", "Jarda", "radar", "nepotopen" };
            for (int i = 0; i < slova.Length; i++)
            {
                string aktualniSlovo = slova[i];
                int delkaAktualnihoSlova = aktualniSlovo.Length;
                //int podilAktualniSlovo = aktualniSlovo.Length / 2;
                bool jePalindrom = true;

                for (int j = 0; j < delkaAktualnihoSlova; j++)
                {
                    char znakSlova = aktualniSlovo[j];
                    char znakSlovaInv = aktualniSlovo[delkaAktualnihoSlova - 1 - j];

                    if (znakSlova != znakSlovaInv)
                    {
                        jePalindrom = false;
                        break;
                    }
                }
                if (jePalindrom)
                {
                    Console.WriteLine($"Slovo {aktualniSlovo} je palindrom");
                }
                else
                {
                    Console.WriteLine($"Slovo {aktualniSlovo} není palindrom");
                }
            }

            Console.WriteLine();

            //3. Ukol - opravte v tomto textu omylem zapnuty Caps Lock

            string capsLock = "jAK mICROSOFT wORD POZNA ZAPNUTY cAPSLOCK"; // je třeba převrátit všechna písmena
            int delkaCapsLock = capsLock.Length;
            //Console.WriteLine((int)capsLock[3] + " " + capsLock[3]); // takto jsem si zjistila, jaké číslo náleží mezeře - ta má zůstat neměnná

            for (int i = 0; i < delkaCapsLock; i++)
            {
                char aktualniZnak = capsLock[i];
                int ciselnaHodnotaZnak = (int)aktualniZnak;

                if (ciselnaHodnotaZnak == 32) // pro mezeru pořadí neměníme a rovnou ji vypíšeme na konzoli
                {
                    Console.Write((char)ciselnaHodnotaZnak);
                    continue;
                }
                else if (ciselnaHodnotaZnak < 97) // identifikuje velká písmena - změníme je na malá
                {
                    ciselnaHodnotaZnak += 32;
                }
                else // identifikuje malá písmena - změníme je na velká
                {
                    ciselnaHodnotaZnak -= 32;
                }

                Console.Write((char)ciselnaHodnotaZnak); // vypíšeme na konzoli písmeno
            }

            Console.WriteLine();

            // další možnost řešení
            string capslock = "jAK mICROSOFT wORD POZNA ZAPNUTY cAPSLOCK"; // je třeba převrátit všechna písmena
            int delkacapslock = capslock.Length;

            for (int i = 0; i < delkacapslock; i++)
            {
                char aktualniznak = capslock[i];

                if (char.IsUpper(aktualniznak)) // identifikuje velká písmena - změní je na malá
                {
                    Console.Write(char.ToLower(aktualniznak));
                }
                else // identifikuje malá písmena - změní je na velká
                {
                    Console.Write(char.ToUpper(aktualniznak));
                }
            }

            Console.WriteLine();

            // 4.Ukol - rozsifrujte tuto zpravu - text byl zasifrovan tak, ze jsme kazde pismeno posunuli o jedno doprava: 'a' -> 'b'. 

            string sifra = "Wzcpsob!qsbdf!.!hsbuvmvkj!b!ktfn!ob!Ufcf!qztoz";
            int delkaSifry = sifra.Length;

            for (int i = 0; i < delkaSifry; i++)
            {
                char znak = sifra[i];
                int ciselnahodnotaznak = (int)znak;
                int novaciselnahodnotaznak = ciselnahodnotaznak - 1;
                char novyznak = (char)novaciselnahodnotaznak;
                Console.Write(novyznak);
            }

        }
    }
}