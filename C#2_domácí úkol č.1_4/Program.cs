namespace C_2_domácí_úkol_č._1_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4.
            //Napište program, který umožní hádat číslo. Zeptá se, jaké číslo si myslím. Podle toho, jaké číslo se zadá, napíše, jestli je číslo větší nebo menší a umožní hádat tak dlouho, dokud se uživatel netrefí:
            //       Např.
            //       Hádej číslo: 10
            //       Číslo je menší, hádej znovu: 5
            //       Číslo je větší, hádej znovu: 7
            //       To je správně!

            Console.WriteLine("Myslím si číslo od 1 do 100. Hádej, o jaké číslo jde.");
            Console.Write("Jdeme na to! Zadej celé číslo: ");

            // vygenerování náhodného čísla
            Random generatorNahodnychCisel = new Random();
            int nahodneCislo = generatorNahodnychCisel.Next(1, 101);

            string cisloInput = Console.ReadLine();
            bool prevodCisla = int.TryParse(cisloInput, out int zadaneCislo);

            if (!prevodCisla || zadaneCislo < 1 || zadaneCislo > 100)
            {
                Console.Write("Špatně zadaný vstup! Zkus zadat hádané číslo znovu: ");
                cisloInput = Console.ReadLine();
                prevodCisla = int.TryParse(cisloInput, out zadaneCislo);
            }

            // pokud (a dokud) hráč číslo neuhádl
            while (zadaneCislo != nahodneCislo)
            {
                if (zadaneCislo > nahodneCislo)
                {
                    Console.Write($"Tebou zadané číslo je větší, hádej znovu: ");
                }
                else
                {
                    Console.Write($"Tebou zadané číslo je menší, hádej znovu: ");
                }

                cisloInput = Console.ReadLine();
                prevodCisla = int.TryParse(cisloInput, out zadaneCislo);

                if (!prevodCisla || zadaneCislo < 1 || zadaneCislo > 100)
                {
                    Console.Write("Špatně zadaný vstup! Zkus zadat hádané číslo znovu: ");
                    cisloInput = Console.ReadLine();
                    prevodCisla = int.TryParse(cisloInput, out zadaneCislo);
                }
            }
            // pokud hráč číslo uhádl
            Console.WriteLine($"Gratuluji! Uhádl(a) jsi číslo {nahodneCislo}.");
        }
    }
}