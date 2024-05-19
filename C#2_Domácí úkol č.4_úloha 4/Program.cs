namespace C_2_Domácí_úkol_č._4_úloha_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4. Seřaďte jména vzestupně
            List<string> jmena = new List<string>()
            {
                "Hana", "Jaroslav", "Xenie", "Michaela", "Borivoj", "Nela",
                "Katerina", "Sofie", "Adam", "David", "Zuzana", "Barbara",
                "Tereza", "Lenka", "Svetlana", "Cecilie", "Renata",
                "Evzen", "Pavel", "Eliska", "Viktor", "Antonin",
                "Frantisek", "Radek"
            };

            // 4. Řešení
            List<string> vzestupne = jmena.OrderBy(j => j).ToList();

            foreach (string text in vzestupne)
            {
                Console.WriteLine(text);
            }
        }
    }
}