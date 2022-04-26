using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;
using System.Drawing;
using System.IO;
namespace BarCode.Helper
{
    public class BarCodeHelper
    {
        public static async Task GenerateBarCode(string data)
        {
            var barCodeData = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.CODE_128,
                Options = new QrCodeEncodingOptions
                {
                    Height = 90,
                    Width = 240,
                    Margin = 6,
                    CharacterSet = data
                }
            };

            var pixelData = barCodeData.Write(data);

            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                        System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);

                    bitmap.UnlockBits(bitmapData);
                    bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "barcode.png");

                    await File.WriteAllBytesAsync(path, memoryStream.ToArray());
                }
            }
        }
    }
}
