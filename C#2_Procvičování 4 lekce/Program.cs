using System.Runtime.CompilerServices;

namespace C_2_Procvičování_4_lekce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Která metoda vytvoří textový řetězec ve formátu ****9588?
            //string posledniCtyriZnaky = "9588";
            //Console.WriteLine(posledniCtyriZnaky.PadLeft(8,'*'));
            //// číslo 8 se zadává, protože má mít řetězec celkově 8 znaků

            //List<string> cinskaZnameni = new List<string>() { "koza", "opice", "kohout", "pes", "vepř"}; 

            //foreach (string s in cinskaZnameni)
            //{
            //    Console.WriteLine(s);
            //}
            
            //Console.WriteLine();    
            //Console.Write($"Zadej znamení, které chceš smazat ze seznamu: ");
            //string znameniKSmazani = Console.ReadLine();

            //string nalezeneZnameni = cinskaZnameni.Find(r => r == znameniKSmazani);

            //Console.WriteLine();

            //cinskaZnameni.Remove(znameniKSmazani);
            //cinskaZnameni.Add("Krysa");
            //// metoda AddRange by přidala více prvků najednou

            //foreach (string s in cinskaZnameni)
            //{
            //    Console.WriteLine(s);
            //}

            //int indexOpice = cinskaZnameni.IndexOf("opice");
            //Console.WriteLine($"Opice má index {indexOpice}");

            //cinskaZnameni.Sort(); // seřadí položky na listu dle abecedy

            //foreach (string s in cinskaZnameni)
            //{
            //    Console.WriteLine(s);
            //}

            ////static int PorovnejZnameni()
            ////{
            ////    return string.Compare(s.list, druhy.ToList, true);
            ////}

            //cinskaZnameni.Clear();

            //foreach (string s in cinskaZnameni)
            //{
            //    Console.WriteLine(s);
            //}

            //Slovníky

            //Dictionary<string, string> slovnikAj = new Dictionary<string, string>();
            Dictionary<string, string> slovnikAj = new Dictionary<string, string> 
            {
                { "ahoj", "hello"},
                { "auto", "car"},
                { "dum", "house"}
            };

            slovnikAj.Add("kvetina", "flower");

            Console.WriteLine($"Květina je anglicky {slovnikAj["kvetina"]}");
            // slovník vrací key-value pair (dvojici objektů)

            //foreach ( var s in slovnikAj ) { Console.WriteLine( s ); }

            foreach(KeyValuePair<string, string> zaznam in slovnikAj) // zaznam je zde dočasná proměnná
            {
                Console.WriteLine($"{zaznam.Key}: {zaznam.Value}");
            }

            // lze zapsat i takto s obecným neurčitým typem var:
            foreach (var zaznam in slovnikAj) // zaznam je zde dočasná proměnná
            {
                Console.WriteLine($"{zaznam.Key}: {zaznam.Value}");
            }

            //string nazdar = "Nazdárek"; varianta s var:
            var nazdar = "Nazdárek";
            var desetinneCislo = 0.2;

            Console.WriteLine(nazdar);
            Console.WriteLine(desetinneCislo);

            Console.WriteLine();

            //slovnikAj.Add("auto", "car"); // nebude přidáno, poněvadž tento klíč už ve slovníku je - vyhodí to výjimku
            // je třeba se dotázat na klíč, který chceme do slovníku přidat

            // metoda ContainsKey() vrací bool
            if (!slovnikAj.ContainsKey("auto"))
            {
                slovnikAj.Add("auto", "car");
            }
            else
            {
                Console.WriteLine("Tento záznam už tam je");
            }

            Console.WriteLine();

            // TryGetValue(); metoda pomůže vyčíst záznam v případě, pokud existuje
            string anglickyPreklad;
            if (slovnikAj.TryGetValue("ahoj", out anglickyPreklad))
            {
                Console.WriteLine($"Překlad 'ahoj' je {anglickyPreklad}.");
            }
            else
            {
                Console.WriteLine("Takové slovíčko tam není!");
            }

            slovnikAj.Remove("ahoj");
            slovnikAj.Add("ruka", "hand");

            foreach (var zaznam in slovnikAj) // zaznam je zde dočasná proměnná
            {
                Console.WriteLine($"{zaznam.Key}: {zaznam.Value}");
            }
            Console.WriteLine();

            // výměna hodnoty klíče:
            slovnikAj["auto"] = "vehicle";

            // přidání další hodnoty klíče dalším způsobem:
            slovnikAj["most"] = "bridge";

            foreach (var zaznam in slovnikAj) // zaznam je zde dočasná proměnná
            {
                Console.WriteLine($"{zaznam.Key}: {zaznam.Value}");
            }

            // smazání celého slovníku
            slovnikAj.Clear();
        }
        
    }
}