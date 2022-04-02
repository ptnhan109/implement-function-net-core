using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToConsole
{
    public static class ImageProcessor
    {
        public static Bitmap GetBitmap(this string path) => new Bitmap(path);

        public static Screen GetScreen(this Bitmap bitmap) => new Screen()
        {
            Height = bitmap.Height,
            Width = bitmap.Width
        };

        public static List<ConsoleColor> GetColors(this Bitmap bitmap)
        {
            var data = new List<ConsoleColor>();
            for (int width = 0; width < bitmap.Height; width++)
            {
                for (int height = 0; height < bitmap.Width; height++)
                {
                    var bitmapColor = bitmap.GetPixel(height, width).ToColor();
                    data.Add(bitmapColor.ToConsoleColor());
                }
            }

            return data;
        }
    }
}
