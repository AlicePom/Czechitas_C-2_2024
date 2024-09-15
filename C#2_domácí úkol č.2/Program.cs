namespace C_2_domácí_úkol_č._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tento ukol se opravuje sam. Kazdy priklad obsahuje kontrolni vypisy, ktere overi, ze jsi dosla k spravnemu vysledku.
            // Vsechny priklady take obsahuji nejakou predpripravenou promennou, kam ulozis vysledek svoji prace.

            int padding = 45;
            string text = @"""Hurry up, boy!"" shouted Uncle Vernon from the kitchen. ""What are you
doing, checking for letter bombs?"" He chuckled at his own joke.

Harry went back to the kitchen, still staring at his letter. He handed
Uncle Vernon the bill and the postcard, sat down, and slowly began to
open the yellow envelope.

Uncle Vernon ripped open the bill, snorted in disgust, and flipped over
the postcard.

""Marge's ill,"" he informed Aunt Petunia. ""Ate a funny whelk. --.""

""Dad!"" said Dudley suddenly. ""Dad, Harry's got something!""

Harry was on the point of unfolding his letter, which was written on the
same heavy parchment as the envelope, when it was jerked sharply out of
his hand by Uncle Vernon.

""That's mine!"" said Harry, trying to snatch it back.

""Who'd be writing to you?"" sneered Uncle Vernon, shaking the letter open
with one hand and glancing at it. His face went from red to green faster
than a set of traffic lights. And it didn't stop there. Within seconds
it was the grayish white of old porridge.";

            // Nez zacnes volat nejake stringove funkce na nejake stringove promenne, nezapomen overit, ze obsahuje smysluplnou hodnotu. Vysledek uloz do promenne 'textMaSmysl'.
            bool textMaSmysl = false;
            //if (text != string.Empty && text != null)
            //{
            //    textMaSmysl = true;
            //}
            if (!string.IsNullOrEmpty(text))
            {
                textMaSmysl = true;
            }
            Console.WriteLine("Text dava smysl - ".PadRight(padding) + (textMaSmysl == true));

            // Do promenne 'delkaTextu' uloz celkovou delku uryvku z knizky.
            //CHYBA
            int delkaTextu = 0;
            string upravenyText = text.Replace("\n", "");
            delkaTextu = upravenyText.Length;

            Console.WriteLine("Delka text je spravna - ".PadRight(padding) + (delkaTextu == 1001));

            // Do promenne 'oddelovac' vloz text, ktery se sklada pouze z pomlcek a jeho delka je presne 20. Pouzij k tomu konstruktor typu string.

            string oddelovac = null;
            oddelovac = new string('-', 20);
            Console.WriteLine("Oddelovac ma 20 pomlcek - ".PadRight(padding) + (oddelovac == "--------------------"));

            // Pozmen nasledujici porovnani textu tak, aby se do konzole vypisovalo True, aniz bys menila hodnoty promennych

            string jmeno1 = "Katka";
            string jmeno2 = "katka";
            bool jeStejne = false;
            jeStejne = string.Equals(jmeno1, jmeno2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine("Obe promenne obsahuji stejne jmeno - ".PadRight(padding) + jeStejne);

            // Zjisti, jestli je v textu zminka o obtloustle "tete" Harryho. Jmenuje se Marge. Vysledek uloz do promenne 'piseSeOMarge';

            bool piseSeOMarge = false;
            piseSeOMarge = text.Contains("Marge");
            Console.WriteLine("V textu se zminuje Harryho 'teticka' - ".PadRight(padding) + (piseSeOMarge == true));

            // Zjisti, jestli je text spravne ukonceny interpunkci. Vysledek uloz do promenne 'jeSpravneUkoncen'.

            bool jeSpravneUkoncen = false;
            jeSpravneUkoncen = text.EndsWith('.') || text.EndsWith('?') || text.EndsWith('!');
            Console.WriteLine("Text je spravne ukoncen interpunkci - ".PadRight(padding) + (jeSpravneUkoncen == true));

            // Pomoci abecedniho porovnavani zjisti, ktery z nasledujicich textu je podle abecedy prvni a jeho hodnotu prirad do promenne 'prvni'.

            string blabol1 = "abbc";
            string blabol2 = "acbc";
            string blabol3 = "abbb";
            string prvni = null;

            string[] blaboly = new string[] { blabol1, blabol2, blabol3 };
            prvni = blaboly[0];
            for (int i = 1; i < blaboly.Length; i++)
            {
                if (string.Compare(prvni, blaboly[i]) > 0)
                {
                    prvni = blaboly[i];
                }
            }

            Console.WriteLine("Prvni v abecede je blabol3 - ".PadRight(padding) + (prvni == blabol3));

            // Najdi prvni rozkazovaci vetu v textu a uloz ji do promenne 'veta' bez vykricniku a uvozovek.
            // není optimální řešení!!! První věta s vykřičníkem nemusí být v pořadí ta první v rámci textu.
            string veta = null;
            int indexVykricnik = text.IndexOf("!");
            int indexZacatekVety = text.IndexOf('"'); // rozkazovací věta začíná uvozovkami
            //veta = text.Substring(0, indexVykricnik).Trim('"'); // dá se i takto, pokud bych nepoužila proměnnou indexUvozovky jako začátek věty
            veta = text.Substring(indexZacatekVety, indexVykricnik).Trim('"');
            Console.WriteLine(veta);
            Console.WriteLine("Prvni rozkazovaci veta je 'Hurry up, boy' - ".PadRight(padding) + (veta == "Hurry up, boy"));

            // Zjisti, kolikrat se v textu vyskytuje slovo "and" bez ohledu na velikosti prvniho pismenka a vysledek uloz do promenne 'pocetAnd'.
            // Abych vam to zjednodusil, muzete se spolehnout, ze tato anglicka spojka bude v textu vzdy obklopena mezerou na kazde strane.
            // Tim se snadno vylouci jakekoliv vyskyty "and" v ramci jinych slov.

            int pocetAnd = 0;
            string textAnd = " and ";
            int indexAnd;
            string novyText = text; // uložím celý test do nové proměnné, protože budu modifikovat jeho délku (nemusela bych, protože jde o poslední úlohu, ale pro pořádek to udělám)

            while (novyText.Contains(textAnd, StringComparison.OrdinalIgnoreCase))
            {
                pocetAnd += 1;
                indexAnd = novyText.IndexOf(textAnd, StringComparison.OrdinalIgnoreCase);
                novyText = novyText.Substring(startIndex: indexAnd + textAnd.Length); // odstraním text obsahující první výskyt "and" a vše před ním
            }

            Console.WriteLine("Text obsahuje slovo 'and' celkem 5x' - ".PadRight(padding) + (pocetAnd == 5));
        }
    }
}