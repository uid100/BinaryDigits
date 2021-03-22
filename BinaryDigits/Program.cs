using System;

namespace BinaryDigits
{
    class Program
    {
        static string margin = "       ";

        static void PrintBitValues()
        {
            int nrBits = 8;

            // PRINT '1's
            string output = margin;
            for (int i = 0; i < nrBits; i++) output += "1";
            Console.WriteLine( $"\n{output}\n{margin}[Enter]\n" );
            Console.ReadLine();

            // PRINT '1's and exponents and place values
            output = margin;
            for (int i = 0; i < nrBits; i++) output += Convert.ToString(nrBits - i- 1);
            output += $"\n{margin}";
            for (int i = 0; i < nrBits; i++) output += "1";
            output += "\n\n";
            for (int digit = 0; digit < nrBits; digit++)
            {
                for (int j = 0; j < nrBits - digit; j++) output += " ";
                output += $"2^{digit} = {Math.Pow(2,digit)}\n";
            }
            Console.WriteLine($"\n{output}\n{margin}[Enter]\n");
            Console.ReadLine();
        }

        static void PrintBitValues(int number)
        {
            string outputString = margin + GetBinaryString(number) + "\n";

            int numDigits = Convert.ToInt32(Math.Log2(number));
            for (int digit = numDigits; digit >= 0 ; digit--)
            {
                int thisDigit = Convert.ToInt32(Math.Pow(2, digit));
                if ( number >= thisDigit)
                {
                    string leader = "";
                    for (int i = 0; i < numDigits - digit; i++) leader += " ";
                    outputString += $"{margin}{leader}^ + {thisDigit}\n";
                    number -= thisDigit;
                }
            }
            Console.WriteLine(outputString);
        }

        static string GetBinaryString(int x)
        {
            string binaryString = "";
            int numDigits = Convert.ToInt32(Math.Log2(x));
            for (int i = numDigits; i >= 0; i--)
            {
                if( x < Math.Pow(2,i)) binaryString += "0";
                else
                {
                    binaryString += '1';
                    x -= Convert.ToInt32(Math.Pow(2, i));
                }
            }
            return binaryString;
        }

        static int GetNextValue()
        {
            Console.Write($"{margin}Enter integer value to Convert (or 0): ");
            return Int32.Parse(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            PrintBitValues();

            int n;
            while ( true )
            {
                if( (n = GetNextValue()) == 0) break;
                PrintBitValues(n);
            }
        }
    }
}
