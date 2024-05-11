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
            Console.Write("Jdeme na to! ");

            // vygenerování náhodného čísla
            Random generatorNahodnychCisel = new Random();
            int nahodneCislo = generatorNahodnychCisel.Next(1, 101);

            // pokud (a dokud) hráč číslo neuhádl
            int zadaneCislo;

            do
            {
                zadaneCislo = ZadaniCisla();

                if (zadaneCislo > nahodneCislo)
                {
                    Console.Write($"Tebou zadané číslo je větší, hádej znovu! ");
                }
                else if (zadaneCislo < nahodneCislo)
                {
                    Console.Write($"Tebou zadané číslo je menší, hádej znovu! ");
                }

            } while (zadaneCislo != nahodneCislo);

            // pokud hráč číslo uhádl
            Console.WriteLine($"Gratuluji! Uhádl(a) jsi číslo {nahodneCislo}.");
        }

        static int ZadaniCisla()
        {
            bool prevodCisla;
            int zadaneCislo;

            do
            {
                Console.Write("Zadej číslo: ");
                string cisloInput = Console.ReadLine();
                prevodCisla = int.TryParse(cisloInput, out zadaneCislo);

                if (!prevodCisla)
                {
                    Console.Write("Špatně zadaný vstup - nebylo zadáno celé číslo! ");
                }
                else if (zadaneCislo < 1 || zadaneCislo > 100)
                {
                    Console.Write("Špatně zadaný vstup - nebylo zadáno číslo od 1 do 100! ");
                    prevodCisla = false;
                }

            } while (!prevodCisla);

            return zadaneCislo;
        }
    }
}