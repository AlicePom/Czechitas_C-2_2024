namespace C_2_domácí_úkol_č._1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.
            // Napište program, který se zeptá na dvě čísla a zobrazí jejich součet.

            Console.WriteLine("Tento program vypíše součet dvou zadaných čísel.");

            // zadání prvního čísla
            Console.Write("Zadej první číslo: ");
            string input1 = Console.ReadLine();
            bool prevedeniInput1 = double.TryParse(input1, out double cislo1);

            while (!prevedeniInput1)
            {
                Console.Write("Špatně zadaný vstup! Zkus zadat první číslo znovu: ");
                input1 = Console.ReadLine();
                prevedeniInput1 = double.TryParse(input1, out cislo1);
            }

            // zadání druhého čísla
            Console.Write("Zadej druhé číslo: ");
            string input2 = Console.ReadLine();
            bool prevedeniInput2 = double.TryParse(input2, out double cislo2);

            while (!prevedeniInput2)
            {
                Console.Write("Špatně zadaný vstup! Zkus zadat druhé číslo znovu: ");
                input2 = Console.ReadLine();
                prevedeniInput2 = double.TryParse(input2, out cislo2);
            }

            // výpis součtu obou čísel
            Console.WriteLine($"Součet čísel {cislo1} a {cislo2} je {cislo1 + cislo2}");
        }
    }
}