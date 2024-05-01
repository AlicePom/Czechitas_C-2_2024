namespace C_2_domácí_úkol_č._1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2.
            //Napište program, který se zeptá na počet hvězdiček a potom je v cyklu zobrazí na konzoli.

            Console.Write("Tento program vytvoří trojúhelník z hvězdiček. Zadej požadovaný počet hvězdiček (celé číslo větší než 0): ");

            string inputPocetHvezdicek = Console.ReadLine();
            bool prevedeniPocetHvezdicek = int.TryParse(inputPocetHvezdicek, out int pocetHvezdicek);

            while (!prevedeniPocetHvezdicek || pocetHvezdicek <= 0)
            {
                Console.Write("Špatně zadaný vstup! Zkus zadat počet hvězdiček (celé číslo větší než 0) znovu: ");
                inputPocetHvezdicek = Console.ReadLine();
                prevedeniPocetHvezdicek = int.TryParse(inputPocetHvezdicek, out pocetHvezdicek);
            }

            // jedno možné řešení výpisu hvězdiček
            int cisloRadku;
            for (int i = 1; i <= pocetHvezdicek; i++)
            {
                cisloRadku = i;
                for (int j = 1; j <= cisloRadku; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }

            //vylepšené řešení výpisu hvězdiček dle látky z lekce 3
            //string radekHvezdicka;
            //for (int i = 1; i <= pocetHvezdicek; i++)
            //{
            //    radekHvezdicka = new string('*', i);
            //    Console.WriteLine(radekHvezdicka);
            //}
        }
    }
}