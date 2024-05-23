namespace C_2_domácí_úkol_č._1_3
{
    public class Lucistnik
    {
        public int PocetSipu;

        public Lucistnik(int pocetSipu)
        {
            PocetSipu = pocetSipu;
        }

        public void Vystrel()
        {
            // pokud má lučištník ještě nějaké šípy
            if (PocetSipu > 0)
            {
                PocetSipu -= 1;
                Console.WriteLine($"Vždy se strefím přímo doprostřed! Zbývá mi {PocetSipu} šípů");
            }

            // pokud právě lučištníkovi šípy došly
            if (PocetSipu == 0)
            {
                Console.WriteLine("Nemám šípy.");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int pocetSipu = 10;
            Lucistnik lucistnik = new Lucistnik(pocetSipu);

            while (lucistnik.PocetSipu >= 0)
            {
                lucistnik.Vystrel();

                if (lucistnik.PocetSipu == 0)
                {
                    break;
                }
            }  
        } 
    }
}