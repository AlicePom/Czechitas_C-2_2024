namespace C_2_6_lekce_breakoutroom_Obdelnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Obdelnik objekt1 = new Obdelnik(10, 7);
            objekt1.VypisInformace();

            Obdelnik objekt2 = new Obdelnik(5, 5);
            objekt2.VypisInformace();

            Obdelnik objekt3 = new Obdelnik(6);
            objekt3.VypisInformace();

            objekt1.Zvetsi(3, 6);
            objekt1.VypisInformace();

            objekt2.Zvetsi(1, -2);
            objekt2.VypisInformace();

            objekt3.Zvetsi(-6, -12);
            objekt3.VypisInformace();
        }
    }
}