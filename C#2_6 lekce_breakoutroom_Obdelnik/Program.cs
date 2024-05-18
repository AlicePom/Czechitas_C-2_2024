namespace C_2_6_lekce_breakoutroom_Obdelnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Obdelnik obdelnik = new Obdelnik(4, 7);
            obdelnik.VypisInformace();

            Obdelnik ctverec = new Obdelnik(8);
            ctverec.VypisInformace();
        }
    }
}