namespace C_2_domácí_úkol_č._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Vypiš aktuální datum a čas, nemusíš řešit, v kterém je to časovém pásmu.

            DateTime aktualniCas = DateTime.Now;
            Console.WriteLine($"Aktuální čas je {aktualniCas}");

            Console.WriteLine();

            // 2. Vytvoř proměnnou typu DateTime a ulož do ní svoje datum narození. Potom vypiš, kolik dnů od té doby uteklo.

            DateTime mojeDatumNarozeni = new DateTime(1987, 3, 21, 14, 53, 00);
            TimeSpan pocetDnuZivota = aktualniCas - mojeDatumNarozeni;
            Console.WriteLine($"Žiju už {pocetDnuZivota.Days} dnů.");

            Console.WriteLine();

            // 3. Vytvoř list stringů a vlož do něj 5 různých hodnot.

            List<string> seznamKnih = new List<string>() { "Čtyři dohody", "Zkorumpovaná farmacie", "Počátek", "Harry Potter a prokleté dítě", "Umění slovní sebeobrany" };

            foreach (string s in seznamKnih)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            // 4. Smaž z tohoto listu libovolnou hodnotu.

            seznamKnih.Remove("Počátek");

            foreach (string s in seznamKnih)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            // 5. Zjisti, jestli tento list obsahuje nějakou hodnotu pomocí list metody Contains

            Console.Write("Zadej knihu, pro kterou chceš zjistit, zda je na seznamu: ");
            string knihaInput = Console.ReadLine();

            
            Console.WriteLine($"Seznam knih obsahuje knihu {knihaInput}: {seznamKnih.Contains(knihaInput)}");
            // Console.WriteLine($"Seznam knih obsahuje knihu {knihaInput}: {seznamKnih.Contains(knihaInput, StringComparison.OrdinalIgnoreCase)}"); // nefunguje
            Console.WriteLine();

            // 6. Vypiš do konzole, kolik je v tom listu prvků a připoj k tomu všechny ty hodnoty (např: "2: modra, zelena").

            Console.WriteLine($"{seznamKnih.Count}: {string.Join(", ", seznamKnih)}");

            Console.WriteLine();

            // 7. Vytvoř slovník, kde klíčem bude položka nákupu (string) a hodnotou cena té položky, a vlož nějaké hodnoty (např: <"chleba", 20>).

            Dictionary<string, int> nakupniSeznam = new Dictionary<string, int>
            {
                { "chleba", 20},
                { "máslo", 48},
                { "šunka", 42},
                { "papriky mix", 69},
                { "minerálka", 30}
            };

            // výpis obsahu slovníku nakupniSeznam
            foreach (var item in nakupniSeznam)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Console.WriteLine();

            // 8. Zjisti, jestli slovník obsahuje nějakou konkrétní potravinu a pokud ano, vypiš její cenu, pokud ne, vypiš, že není.

            // výběr položky, kterou chceme ověřit
            Console.Write("Zadej položku, pro kterou chceš zjistit, zda je na seznamu: ");
            string polozka1 = Console.ReadLine();

            // ověření položky, zda je na seznamu
            if (nakupniSeznam.ContainsKey(polozka1))
            {
                Console.WriteLine($"Položka {polozka1} stojí {nakupniSeznam[polozka1]} Kč.");
            }
            else
            {
                Console.WriteLine($"Tato položka není na seznamu!");
            }

            Console.WriteLine();

            // 9. Řekněme, že už jsi do slovníku přidala např. chleba a zjistila, že máš v nákupní tašce ještě jeden -> uprav hodnotu k tomu klíči tak, aby obsahovala hromadnou cenu za všechny stejné položky.

            // výběr položky
            Console.Write("Zadej položku, kterou chceš koupit víckrát: ");
            string polozka2 = Console.ReadLine();

            // ověření, zda je položka na seznamu
            if (nakupniSeznam.ContainsKey(polozka2))
            {
                Console.WriteLine($"{polozka2} stojí {nakupniSeznam[polozka2]} Kč.");

                // zadání požadovaného počtu vybrané položky
                Console.Write("Zadej počet ks této položky: ");
                string pocetInput = Console.ReadLine();

                // ověření vstupu (celočíselná hodnota)
                bool parsed = int.TryParse(pocetInput, out int pocet);

                while (!parsed)
                {
                    Console.Write("Špatně zadaný vstup! Zadej počet ks této položky (celé číslo) znovu: ");
                    pocetInput = Console.ReadLine();
                    parsed = int.TryParse(pocetInput, out pocet);
                }

                // přidání požadovaného počtu ks položky na seznam (úprava ceny) 
                nakupniSeznam[polozka2] *= pocet;

                // výpis celkové ceny za daný počet ks zadané položky
                Console.WriteLine($"Celková cena za {pocet} ks položky {polozka2} je {nakupniSeznam[polozka2]} Kč.");
            }
            else
            {
                Console.WriteLine($"Položka {polozka2} není na seznamu!");
            }

            Console.WriteLine();

            // výpis obsahu slovníku nakupniSeznam
            foreach (var item in nakupniSeznam)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}