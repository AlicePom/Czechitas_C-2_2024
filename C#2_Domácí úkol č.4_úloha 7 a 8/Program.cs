namespace C_2_Domácí_úkol_č._4_úloha_7_a_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 7. Zobrazte vsechny milionare v kazde bance
            // Napr. 
            // CS: Jan Novak a Josef Novotny
            // KB: Jana Nova

            List<Zakaznik> zakaznici = new List<Zakaznik>() {
                new Zakaznik(){ Jmeno="Jan Maly", Zustatek=10345.50, Banka="CS"},
                new Zakaznik(){ Jmeno="Jiri Hladny", Zustatek=452.10, Banka="KB"},
                new Zakaznik(){ Jmeno="Lenka Sporiva", Zustatek=523665.13, Banka="CS"},
                new Zakaznik(){ Jmeno="Marie Bohata", Zustatek=7482184.38, Banka="FIO"},
                new Zakaznik(){ Jmeno="Michal Marny", Zustatek=745234.93, Banka="KB"},
                new Zakaznik(){ Jmeno="Lada Vychytraly", Zustatek=8832937.34, Banka="CS"},
                new Zakaznik(){ Jmeno="Sandra Nedostatecna", Zustatek=942488.48, Banka="KB"},
                new Zakaznik(){ Jmeno="Silvie Zavodou", Zustatek=56198334.72, Banka="FIO"},
                new Zakaznik(){ Jmeno="Tereza Presna", Zustatek=1000000.00, Banka="CITI"},
                new Zakaznik(){ Jmeno="Stefan Pilny", Zustatek=48282.73, Banka="CITI"}
            };

            //// 7. Řešení
            var Milionari = zakaznici.Where(z => z.Zustatek >= 1000000).ToList();
            List<SkupinaMilionaru> skupinyPodleBanky = Milionari.GroupBy(m => m.Banka, (Banka, Milionari) => new SkupinaMilionaru
            {
                Banka = Banka,
                Milionari = Milionari.Select(m => m.Jmeno)
            }).ToList();

            Console.WriteLine("Řešení úlohy č.7:");

            foreach (var polozka in skupinyPodleBanky)
            {
                Console.WriteLine(polozka.Banka + ": " + string.Join(" a ", polozka.Milionari));
            }

            Console.WriteLine();

            // ==========================================		
            // 8. Vytisknete jmeno kazdeho milionare a jeho banky
            // Napr
            // Jan Novak v Ceska Sporitelna
            // Josef Novotny v Komercni Banka
            List<Banka> banky = new List<Banka>() {
                new Banka(){ Jmeno="Ceska Sporitelna", Symbol="CS"},
                new Banka(){ Jmeno="Komercni Banka", Symbol="KB"},
                new Banka(){ Jmeno="Fio Banka", Symbol="FIO"},
                new Banka(){ Jmeno="Citibank", Symbol="CITI"},
            };

            // 8. Řešení

            List<Zakaznik> reportMilionaru = (from milionar in skupinyPodleBanky
                                              join banka in banky on milionar.Banka equals banka.Symbol
                                              from jmenoMilionare in milionar.Milionari
                                              select new Zakaznik
                                              {
                                                  Jmeno = jmenoMilionare,
                                                  Banka = banka.Jmeno
                                              }).ToList();

            Console.WriteLine("Řešení úlohy č.8:");

            foreach (Zakaznik zakaznik in reportMilionaru)
            {
                Console.WriteLine(zakaznik.Jmeno + " v " + zakaznik.Banka);
            }
        }
    }

    // Definice Banky
    public class Banka
    {
        public string Symbol { get; set; }
        public string Jmeno { get; set; }
    }

    // Definice Zákazníka
    public class Zakaznik
    {
        public string Jmeno { get; set; }
        public double Zustatek { get; set; }
        public string Banka { get; set; }
    }

    // Definice Skupiny milionářů
    public class SkupinaMilionaru
    {
        public string Banka { get; set; }
        public IEnumerable<string> Milionari { get; set; }
    }
}