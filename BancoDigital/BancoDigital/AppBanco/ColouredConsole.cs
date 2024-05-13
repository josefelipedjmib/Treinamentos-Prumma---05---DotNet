using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanco
{
    static public class ColouredConsole
    {
        public static int Count { get; set; } = 0;
        public static int Colors = 4;

        public static void WriteLine(string text)
        {
            int cor = Count % Colors;
            switch (cor)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine(text);

            Count++;
        }
    }
}
