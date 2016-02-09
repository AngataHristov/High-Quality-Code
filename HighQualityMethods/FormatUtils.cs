namespace Methods
{
    using System;

    public static class FormatUtils
    {
        public static string ConvertDigitToString(int digit)
        {
            string convertedDigit = string.Empty;
            switch (digit)
            {
                case 0:
                    convertedDigit = "zero";
                    break;
                case 1:
                    convertedDigit = "one";
                    break;
                case 2:
                    convertedDigit = "two";
                    break;
                case 3:
                    convertedDigit = "three";
                    break;
                case 4:
                    convertedDigit = "four";
                    break;
                case 5:
                    convertedDigit = "five";
                    break;
                case 6:
                    convertedDigit = "six";
                    break;
                case 7:
                    convertedDigit = "seven";
                    break;
                case 8:
                    convertedDigit = "eight";
                    break;
                case 9:
                    convertedDigit = "nine";
                    break;
                default:
                    throw new ArgumentException("Invalid digit!");
            }

            return convertedDigit;
        }

        public static void PrintNumberInFormat(double number, string format)
        {
            switch (format.ToLower())
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Invalid format type. ");
            }
        }
    }
}