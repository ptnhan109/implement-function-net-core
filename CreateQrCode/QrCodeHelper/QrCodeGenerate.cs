using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CreateQrCode.QrCodeHelper
{
    public class QrCodeGenerate
    {
        public static string GenerateQrCode(string content,string imageName)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData qrData = qr.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode result = new QRCode(qrData);
            Bitmap bitmap = result.GetGraphic(20);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "QrImages", $"{imageName}.png");
            bitmap.Save(path, ImageFormat.Png);
            return $"/qr/{imageName}.png";
        }
    }
}
