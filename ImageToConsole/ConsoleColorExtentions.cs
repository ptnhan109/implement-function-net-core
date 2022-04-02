using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToConsole
{
    public static class ConsoleColorExtentions
    {
        public static ImageColor ToColor(this Color color)
         => new ImageColor(color.R, color.G, color.B);
        

        public static ImageColor ToColor(this ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    return new ImageColor(0, 0, 0);
                case ConsoleColor.DarkBlue:
                    return new ImageColor(0, 0, 128);
                case ConsoleColor.DarkGreen:
                    return new ImageColor(0, 128, 0);
                case ConsoleColor.DarkCyan:
                    return new ImageColor(0, 128, 128);
                case ConsoleColor.DarkRed:
                    return new ImageColor(128, 0, 0);
                case ConsoleColor.DarkMagenta:
                    return new ImageColor(1, 36, 86);
                case ConsoleColor.DarkYellow:
                    return new ImageColor(238, 237, 240);
                case ConsoleColor.Gray:
                    return new ImageColor(192, 192, 192);
                case ConsoleColor.DarkGray:
                    return new ImageColor(128, 128, 128);
                case ConsoleColor.Blue:
                    return new ImageColor(0, 0, 255);
                case ConsoleColor.Green:
                    return new ImageColor(0, 255, 0);
                case ConsoleColor.Cyan:
                    return new ImageColor(0, 255, 255);
                case ConsoleColor.Red:
                    return new ImageColor(255, 0, 0);
                case ConsoleColor.Magenta:
                    return new ImageColor(255, 0, 255);
                case ConsoleColor.Yellow:
                    return new ImageColor(255, 255, 0);
                case ConsoleColor.White:
                    return new ImageColor(0, 0, 0);
                default:
                    return new ImageColor(0, 0, 0);
            }
        }
    }
}
