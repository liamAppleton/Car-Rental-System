using Spectre.Console;

namespace rentalapp
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationFlow applicationFlow = new ApplicationFlow();
            applicationFlow.Run();
        }
    }
}