using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "1.jpg");
            var bitmap = path.GetBitmap();
            var screen = bitmap.GetScreen();
            var data = bitmap.GetColors();

            int index = 0;

            for(int width = 0; width < screen.Height; width++)
            {
                for(int height = 0; height < screen.Width; height++)
                {
                    Console.BackgroundColor = data[index];
                    Console.ForegroundColor = data[index];

                    if (data[index] == ConsoleColor.DarkYellow)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(".");
                    index++;
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
