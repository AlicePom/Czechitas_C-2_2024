namespace C_2_domácí_úkol_č._1_3
{
    internal class Program
    {
        public class Lucistnik
        {
            public int PocetSipu = 10;

            public int Vystrel()
            {
                if (PocetSipu > 0)
                {
                    PocetSipu -= 1;
                    Console.WriteLine($"Vždy se strefím přímo doprostřed! Zbývá mi {PocetSipu} šípů");

                }
                else
                {
                    Console.WriteLine("Nemám šípy.");
                    Environment.Exit(0);
                }

                return PocetSipu;
            }
        }
        static void Main(string[] args)
        {
            //int pocetSipu = 3;
            Lucistnik lucistnik = new Lucistnik();

            while (lucistnik.PocetSipu >= 0)
            {
                lucistnik.Vystrel();
            }
        }
    }
}