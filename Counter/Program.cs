using System;
using System.Threading;

namespace Counter
{
    class Program
    {
        static int n = 1;
        static int waitTime = 500;  // msec
        static string margin = "      ";

        static bool showDec = true;
        static bool showHex = true;
        static bool showBin = true;

        static int GetNextValue()
        {
            Console.Write($"\n{margin}Count to (or 0): ");
            return Int32.Parse(Console.ReadLine());
        }
        static void Counter(int n)
        {
            Console.WriteLine( margin
                    + (showHex ? "  (hex)  " : string.Empty)
                    + (showDec ? "  (dec)  " : string.Empty)
                    + (showBin ? "  (bin)  " : string.Empty) );

            string countDisplay;

            for (int i = 0; i <= n; i++)
            {
                countDisplay = string.Empty;
                countDisplay += $"{margin}{ (showHex ? Convert.ToString(i,16) : string.Empty),4 }";
                countDisplay += $"{margin}{ (showDec ? Convert.ToString(i,10) : string.Empty),4 }";
                countDisplay += $"{margin}{ (showBin ? Convert.ToString(i,2) : string.Empty),4 }";

                string backSpaces = "";
                for (int j = 0; j < countDisplay.Length; j++) backSpaces += "\b";

                Console.Write($"{backSpaces}{countDisplay}");
                if (waitTime > 0) Thread.Sleep(waitTime);
                else Console.ReadKey();
            }
        }
        static void ConfigureApp()
        {
            int wait;
            Console.Write($"\n\nDelay: ([{waitTime}]) msec: ");
            if (Int32.TryParse(Console.ReadLine(), out wait)) waitTime = wait;
            Console.WriteLine($"{margin}Delay: {(waitTime > 0 ? waitTime : "step")}\n");

            Console.Write("show hexadecimal counter ([Y],n) ");
            if (Console.ReadLine().ToLower().StartsWith('n')) showHex = false;
            Console.Write("show decimal counter ([Y],n) ");
            if (Console.ReadLine().ToLower().StartsWith('n')) showDec = false;
            Console.Write("show binary counter ([Y],n) ");
            if (Console.ReadLine().ToLower().StartsWith('n')) showBin = false;

            n = GetNextValue();
        }

        static void Main(string[] args)
        {
            while (n > 0)
            {
                ConfigureApp();
                Counter(n);
            }
        }
    }
}
