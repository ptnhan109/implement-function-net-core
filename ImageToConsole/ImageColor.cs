using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToConsole
{
    public class ImageColor
    {
        public int Red { get; set; }

        public int Green { get; set; }

        public int Blue { get; set; }

        public ImageColor(int red, int blue, int green)
        {
            Red = red;
            Blue = blue;
            Green = green;
        }

        public ConsoleColor ToConsoleColor()
        {
            int minSpace = 255 * 3;
            int minIndex = 0;
            var consoleColors = ((ConsoleColor[])Enum.GetValues(typeof(ConsoleColor))).ToList();
            for(int i = 0; i < consoleColors.Count; i++)
            {
                var consoleColor = consoleColors[i].ToColor();
                int space = Math.Abs(Red - consoleColor.Red) + Math.Abs(Green - consoleColor.Green) + Math.Abs(Blue - consoleColor.Blue);

                if(space < minSpace)
                {
                    minSpace = space;
                    minIndex = i;
                }
            }

            return consoleColors[minIndex];
        }
    }
}
