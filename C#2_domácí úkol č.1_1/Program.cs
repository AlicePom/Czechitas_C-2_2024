namespace C_2_domácí_úkol_č._1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.
            // Napište program, který se zeptá na dvě čísla a zobrazí jejich součet.

            Console.WriteLine("Tento program vypíše součet dvou zadaných čísel.");
            double cislo1;
            double cislo2;

            // zadání prvního čísla
            cislo1 = ZadejCislo("první");

            // zadání druhého čísla
            cislo2 = ZadejCislo("druhé");

            // výpis součtu obou čísel
            Console.WriteLine($"Součet čísel {cislo1} a {cislo2} je {cislo1 + cislo2}");          

        }
        static double ZadejCislo(string poradiCisla)
        {
            bool parsedInput;
            double cislo;

            do
            {
                Console.Write($"Zadej {poradiCisla} číslo: ");
                string input = Console.ReadLine();
                parsedInput = double.TryParse(input, out cislo);

                if (!parsedInput)
                {
                    Console.WriteLine("Špatně zadaný vstup! Zkus zadat číslo znovu.");
                }

            } while (!parsedInput);

            return cislo;
        }
    }
}