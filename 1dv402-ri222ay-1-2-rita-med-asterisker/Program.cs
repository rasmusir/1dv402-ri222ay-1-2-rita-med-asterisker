using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv402_ri222ay_1_2_rita_med_asterisker
{
    class Program
    {
        static void Main(string[] args)
        {
            byte b = ReadOddByte("Skriv in ett tal: ", 71);
            RenderDiamond(b);
        }

        static void RenderDiamond(byte maxCount)
        {
            for (int i = 0; i < maxCount; i++ )
            {
                int count = 0;
                if (i <= maxCount / 2)
                    count =  i * 2 + 1;
                else
                    count = (maxCount - i) * 2 - 1;
                RenderRow(maxCount, count);
            }
        }

        static void RenderRow(int maxCount, int asteriskCount)
        {
            int start = maxCount / 2 - asteriskCount/2;
            Console.CursorLeft = start;
            for (int i = 0; i < asteriskCount; i++ )
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        static byte ReadOddByte(string prompt = null, byte maxValue = 255)
        {
            while(true)
            {
                if (prompt != null)
                    Console.Write(prompt);
                byte b = maxValue;
                if (byte.TryParse(Console.ReadLine(),out b))
                {
                    if (b >= 1 && b <= maxValue && b%2 == 1)
                        return b;
                }
                ShowMessage(string.Format("FEL! Det inmatade värdet är inte ett udda heltal mellan 1 och {0}", maxValue),true);
            }
        }

        static bool IsContinuing()
        {
            ShowMessage("Tryck tangent för att fortsätta - Esc avsluta.");    // TODO Replace with resource later.
            if (Console.ReadKey().Key == ConsoleKey.Escape)
                return false;
            return true;
        }

        static void ShowMessage(string message,bool error = false)
        {
            if (error)
                Console.BackgroundColor = ConsoleColor.Red;
            else
                Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
