using System.Collections.Immutable;

namespace C_2_lekce_5_LINQ
{
    internal class Program
    {
        class Rytir
        {
            public string Jmeno { get; set; }
            public int Zdravi { get; set; }
            public string KodZeme { get; set; }

        }

        class Zeme
        {
            public string Nazev { get; set; }
            public string Kod { get; set; }
        }

        private static bool JeSilny(Rytir rytir)
        {
            return rytir.Zdravi > 90;
        }


        static void Main(string[] args)
        {
            // procvičování z hodiny

            Rytir borivoj = new Rytir() { Jmeno = "Borivoj", Zdravi = 100, KodZeme = "CZ" };
            Rytir vojtech = new Rytir() { Jmeno = "Vojtech", Zdravi = 100, KodZeme = "CZ" };
            Rytir miroslav = new Rytir() { Jmeno = "Miroslav", Zdravi = 80, KodZeme = "SK" };
            Rytir bronislav = new Rytir() { Jmeno = "Bronislav", Zdravi = 50, KodZeme = "SK" };
            Rytir vaclav = new Rytir() { Jmeno = "Vaclav", Zdravi = 80, KodZeme = "CZ" };
            Rytir radovan = new Rytir() { Jmeno = "Radovan", Zdravi = 10, KodZeme = "CZ" };
            Rytir istvan = new Rytir() { Jmeno = "Istvan", Zdravi = 35, KodZeme = "HU" };

            List<Rytir> rytiri = new List<Rytir>() { borivoj, vojtech, miroslav, bronislav, vaclav, radovan, istvan };

            List<Zeme> zeme = new List<Zeme>() 
            {
                new Zeme() {Kod = "CZ", Nazev = "Česko"},
                new Zeme() {Kod = "SK", Nazev = "Slovensko"},
                new Zeme() {Kod = "HU", Nazev = "Maďarsko"}
            };

            // seskupování prvků v rámci listu dle nějakého parametru
            var rytiriPodleNarodnosti = rytiri.GroupBy(r => r.KodZeme);
            //foreach(var skupinaRytiru in rytiriPodleNarodnosti)
            //{
            //    Console.WriteLine(skupinaRytiru.Key); // Key je ta hodnota společná rpo tu skupinu
            //    foreach(Rytir rytir in skupinaRytiru) // zde již iteruji přes jendotlivé rytíře
            //    {
            //        Console.WriteLine(rytir.Jmeno);
            //    }
            //    Console.WriteLine();
            //}

            // další možnost - výpis celého názvu země podle druhé tabulky
            // použití funkce FIND - najde první prvek kolekce, který odpovídá podmínce (predikátu)

            foreach (var skupinaRytiru in rytiriPodleNarodnosti)
            {
                Zeme zemeRytire = zeme.Find(z => z.Kod == skupinaRytiru.Key);
                Console.WriteLine(zemeRytire.Nazev); // Key je ta hodnota společná pro tu skupinu
                foreach (Rytir rytir in skupinaRytiru) // zde již iteruji přes jendotlivé rytíře
                {
                    Console.WriteLine(rytir.Jmeno);
                }
                Console.WriteLine();
            }

            // spojování 2 tabulek (kolekcí) do jedné - spočívá v tom síla LINQ
            var rytiriSeZemi = from rytir in rytiri // enumerable - definice toho, co se  má udělat, ale neudělalo se
                               join zem in zeme on rytir.KodZeme equals zem.Kod // rytir a země musejí být ve stejném pořadí!!!
                               select new // vytvoření nového objektu (kolekce)
                               {
                                   Jmeno = rytir.Jmeno,
                                   Zeme = zem.Nazev
                               };
            var rytiriSeZemiOdM = rytiriSeZemi.Where(r => r.Jmeno.StartsWith("M")); // seznam se stále nenaplní (nematerializuje)
            // materializace v programování!!!
            var rytiriSeZemiList = rytiriSeZemi.ToList(); // typ list, až nyní se prvky uloží a výsledek už se nemůže změnit
            foreach (var rytirSeZemi in rytiriSeZemi)
            {
                Console.WriteLine($"Jmenuji se {rytirSeZemi.Jmeno} a mým domovem je {rytirSeZemi.Zeme}");
            }
            //Console.WriteLine();
            //foreach (var rytirSeZemi in rytiriSeZemi)
            //{
            //    Console.WriteLine($"Jmenuji se {rytirSeZemi.Jmeno} a mým domovem je {rytirSeZemi.Zeme}");
            //}







            //var dotaz = from r in rytiri
            //            where (r.Jmeno.StartsWith("V") && r.Zdravi > 30)
            //            select r.Jmeno;
            //Console.WriteLine(dotaz); // takto ne!!! toto je špatně!
            //Takto je to správně!

            //foreach (var r in dotaz) Console.WriteLine(r);

            // nebo taky toto vypíše, co bylo vybráno v select
            //foreach (var r in dotaz) 
            //{
            //    Console.WriteLine(r);
            //} 

            // zápis pomocí lambda výrazů
            //var dotaz2 = rytiri.Where(r => r.Jmeno.StartsWith("V"))
            //                    .Where(r => r.Zdravi > 50)
            //                    .Select(r => r.Jmeno);
            //foreach (var r in dotaz2) Console.WriteLine(r);

            // lze uložit rovnou do pole nebo do listu => ToArray() nebo ToList();
            //var dotaz3 = (rytiri.Where(r => r.Jmeno.StartsWith("V"))
            //        .Where(r => r.Zdravi > 50)
            //        .Select(r => r.Jmeno)).ToArray();


            // silní rytíři - varianta 1
            //var silniRytiri = rytiri.Where(r => r.Zdravi > 90); // lambda výraz

            // silní rytíři - varianta 2 - pomocí statické metody
            //var silniRytiri = rytiri.Where(JeSilny);

            //foreach (Rytir r in silniRytiri)
            //{
            //    Console.WriteLine(r.Jmeno);
            //}

            //Console.WriteLine($"Počet rytířů, jejichž jméno začíná na V: {rytiri.Count(r => r.Jmeno.StartsWith("V"))}");
            //Console.WriteLine($"Počet rytířů před umřením: {rytiri.Count(r => r.Zdravi < 25)}"); // count je LINQ (srovnej s countem níže z funkce)

            // slabí rytíři
            //var slabiRytiri = rytiri.Where(r => r.Zdravi < 60);

            //Console.WriteLine($"Počet slabých rytířů: {slabiRytiri.Count()}"); // count NENÍ LINQ
            //Console.WriteLine($"První rytíř: {rytiri.FirstOrDefault().Jmeno}"); // pokud v kolekci nic není, aby program nespadnul    
            //Console.WriteLine($"První rytíř: {rytiri.First().Jmeno}");    
            //Console.WriteLine($"Poslední rytíř: {rytiri.Last().Jmeno}");    


            //var neexistujiciRytiri = rytiri.Where(r => r.Zdravi > 200);
            //Rytir prvniNeexistujici = neexistujiciRytiri.FirstOrDefault();
            //if ( prvniNeexistujici != null)
            //{
            //    Console.WriteLine($"První neexistující rytíř: {neexistujiciRytiri.FirstOrDefault().Jmeno}");
            //}
            //else
            //{
            //    Console.WriteLine("Rytíř opravdu neexistuje!");
            //}

            //// Any a All dají bool, zatímco Average , Min a Max dají číselnou hodnotu (double)
            //Console.WriteLine($"Průměrné zdraví rytíře: {rytiri.Average(r => r.Zdravi)}");
            //Console.WriteLine($"Průměrné zdraví slabého rytíře: {slabiRytiri.Average(r => r.Zdravi)}");
            //Console.WriteLine($"Jsou nějací rytíři silnější než 90? {rytiri.Any(r => r.Zdravi > 90)}"); // true
            //Console.WriteLine($"Jsou všichni rytíři silnější než 90? {rytiri.All(r => r.Zdravi > 90)}"); // false

            // řazení jmen - funkce:
            // OrderBy - seřadí prvky vzestupně
            // OrderByDescending - seřadí prvky sestupně

            //foreach (var r in rytiri.OrderBy(r => r.Jmeno))
            //{
            //    Console.WriteLine(r.Jmeno);
            //}

            // nebo složitěji
            //var rytiriPodleJmena = rytiri.OrderBy(r => r.Jmeno);
            //foreach (var r in rytiriPodleJmena)
            //{
            //    Console.WriteLine(r.Jmeno);
            //}

            //foreach (var r in rytiri.OrderBy(r => r.Jmeno))
            //{
            //    Console.WriteLine(r.Jmeno);
            //}



            ////List<Zeme> zeme = new List<Zeme>()
            ////{
            ////    new Zeme() { Kod = "CZ", Nazev = "Cesko"};

            ////}
            //var silniRytiri = rytiri.Where(JeSilny);


            //foreach (Rytir rytir in silniRytiri)
            //{
            //    Console.WriteLine(rytir.Jmeno);
            //}

            //var slabiRytiri = rytiri.Where(r => r.Zdravi < 40);

            ////Console.WriteLine($"Pocet slabych rytiru je {rytiri.Count(r => r.Zdravi < 40)}");
            //Console.WriteLine($"Pocet slabych rytiru je {slabiRytiri.Count()}");

            //Console.WriteLine($"První rytíř je {rytiri.First().Jmeno}");
            //Console.WriteLine($"Poslední rytíř je {rytiri.Last().Jmeno}");

            //var neexistujiciRytiri = rytiri.Where(r => r.Zdravi > 200);
            //neexistujiciRytiri.FirstOrDefault();

            //Rytir prvniNeexistujiciRytir = neexistujiciRytiri.FirstOrDefault();
            //if (prvniNeexistujiciRytir is not null)
            //{
            //    Console.WriteLine($"Neexistuijici rytir je {prvniNeexistujiciRytir.Jmeno}");
            //}
            //else
            //{
            //    Console.WriteLine("Rytir opravdu neexistuje");
            //}

            //Console.WriteLine($"Průměrné zdraví rytíře je {rytiri.Average(r => r.Zdravi)}");    
            ////Console.WriteLine($"Průměrné zdraví rytíře je {slabiRytiri.Average(r => r.Zdravi)}");    
            //Console.WriteLine($"Existuje rytir zdravejsi nez 100 {rytiri.Any(r => r.Zdravi > 100)}");    
            //Console.WriteLine($"Existuje rytir zdravejsi nez 100 {rytiri.All(r => r.Zdravi > 5)}");

            //var rytiriPodleNarodnosti = rytiri.GroupBy(r => r.KodZeme);
            //foreach (var skupinaRytiru in rytiriPodleNarodnosti)
            //{
            //    //Console.WriteLine(skupinaRytiru.Key);
            //    //foreach(Rytir rytir in skupinaRytiru)
            //    //{
            //    //    Console.WriteLine(rytir.Jmeno);
            //    //}
            //    Zeme zemeRytire = zemeRytire.Find(zeme.Find(z => z.Kod == skupinaRytiru.Key))
            //    Console.WriteLine(zeme.Find(z => z.Kod == skupinaRytiru.Key));
            //}


            //var rytiriSeZemi = from rytir in rytiri
            //                   join zem in zeme on Rytir.KodZeme equals zeme.Kod
            //                   select new
            //                   {
            //                       Jmeno = rytir.Jmeno,
            //                       Zeme = zem.Nazev
            //                   };
            //var rytiriSeZemiOdM = rytiriSeZemi.Where(r => r.Jmeno.StartsWith("M"));
            //foreach(var rytirSeZemi in rytiriSeZemi)
            //{
            //    Console.WriteLine($"Jmenuji se {rytirSeZemi.Jmeno} a jsem z {rytirSeZemi.Zeme}.");
            //}

            //    // kromě 4, 7  a 8

            //    // ==========================================
            //    // 1. Nalezněte slova začínající písmenem 'M'
            //    List<string> ovoce = new List<string>() { "Merunka", "Jablko", "Pomeranc", "Meloun", "Malina", "Limetka" };
            //    //Console.WriteLine($"Slova začínající písmenem M: {ovoce.Where(o => o.StartsWith("M"))}");

            //    // 1. Řešení
            //    //List<string> mOvoce = new List<string>(ovoce.Where(o => o.StartsWith("M")));
            //    List<string> mOvoce = new List<string>(ovoce.Where(o => o.StartsWith("m", StringComparison.InvariantCultureIgnoreCase)));


            //    foreach (string o in mOvoce)
            //    {
            //        Console.WriteLine(o);
            //    }

            //    // ==========================================		
            //    // 2. Která z následujících čísel jsou násobky 4 nebo 6
            //    List<int> ruznaCisla = new List<int>()
            //{
            //    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            //};

            //    // 2. Řešení
            //    List<int> nasobky4a6 = new List<int>(ruznaCisla.Where(r => r % 4 == 0 || r % 6 == 0));

            //    foreach (int cislo in nasobky4a6)
            //    {
            //        Console.WriteLine(cislo);
            //    }
            //    //

            //    // 3. Kolik je v seznamu ruznaCisla čísel?
            //    Console.WriteLine($"V seznamu ruznaCilsa je {ruznaCisla.Count()} cisel"); // 14

            //    // ==========================================
            // 4. Seřaďte jména vzestupně
            //List<string> jmena = new List<string>()
            //{
            //    "Hana", "Jaroslav", "Xenie", "Michaela", "Borivoj", "Nela",
            //    "Katerina", "Sofie", "Adam", "David", "Zuzana", "Barbara",
            //    "Tereza", "Lenka", "Svetlana", "Cecilie", "Renata",
            //    "Evzen", "Pavel", "Eliska", "Viktor", "Antonin",
            //    "Frantisek", "Radek"
            //};

            //// 4. Řešení
            //List<string> vzestupne = jmena.OrderBy(j => j).ToList();

            //foreach (string text in vzestupne)
            //{
            //    Console.WriteLine(text);
            //}


            //    //// ==========================================
            //    // 5. Kolik je celkový součet?
            //    List<double> utrata = new List<double>()
            //{
            //    2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            //};

            //    // 5. Řešení
            //    Console.WriteLine($"Celková útrata je {Math.Round(utrata.Sum(), 2)} Kč."); // 20750,42

            //    // ==========================================		
            //    // 6. Jaké je největší cena?
            //    List<double> cena = new List<double>()
            //{
            //    879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            //};

            //    // 6. Řešení
            //    Console.WriteLine($"Nejvyšší cena je {cena.Max()} Kč."); // 9442.85

            // ==========================================		
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


            foreach (var polozka in skupinyPodleBanky)
            {
                Console.WriteLine(polozka.Banka + ": " + string.Join(" a ", polozka.Milionari));
            }

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

            foreach (Zakaznik zakaznik in reportMilionaru)
            {
                Console.WriteLine(zakaznik.Jmeno + " v " + zakaznik.Banka);
            }


        }
        //private static bool JeSilny(Rytir rytir)
        //{
        //    return rytir.Zdravi > 90;
        //}


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

    class Rytir
    {
        public string Jmeno { get; set; }
        public int Zdravi { get; set; }
    }
}