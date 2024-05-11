namespace C_2_domácí_úkol_č._1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2.
            //Napište program, který se zeptá na počet hvězdiček a potom je v cyklu zobrazí na konzoli.

            Console.WriteLine("Tento program vytvoří trojúhelník z hvězdiček.");

            int pocetHvezdicek = ZadejPocetHvezdicek();
            // jedno možné řešení výpisu hvězdiček

            for (int i = 1; i <= pocetHvezdicek; i++)
            {
                int cisloRadku = i;
                for (int j = 1; j <= cisloRadku; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }

            //vylepšené řešení výpisu hvězdiček dle látky z lekce 3

            //for (int i = 1; i <= pocetHvezdicek; i++)
            //{
            //    string radekHvezdicka = new string('*', i);
            //    Console.WriteLine(radekHvezdicka);
            //}
        }

        static int ZadejPocetHvezdicek() 
        {
            int pocetHvezdicek;
            bool prevedeniPocetHvezdicek;

            do
            {
                Console.Write("Zadej požadovaný počet hvězdiček (celé číslo větší než 0): ");
                string inputPocetHvezdicek = Console.ReadLine();
                prevedeniPocetHvezdicek = int.TryParse(inputPocetHvezdicek, out pocetHvezdicek);

                if (!prevedeniPocetHvezdicek || pocetHvezdicek <= 0)
                {
                    Console.Write("Špatně zadaný vstup! ");
                }

            } while (!prevedeniPocetHvezdicek || pocetHvezdicek <= 0);

            return pocetHvezdicek;
        }
    }
}