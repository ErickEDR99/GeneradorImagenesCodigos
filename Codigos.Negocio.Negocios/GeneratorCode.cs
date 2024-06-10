using BarcodeStandard;
using QRCoder;
using SkiaSharp;
using System.Drawing;
using Type = BarcodeStandard.Type;

namespace Codigos.Negocio.Negocios
{
    /// <summary>
    /// Clase destinada a generar codigos de barra y QR
    /// </summary>
    public class GeneratorCode
    {
        /// <summary>
        /// Metodo que convierte una cadena de texto en la data de una imagen de un codigo de barras en base 64
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string GenerateBarcode(string content)
        {
            var b = new Barcode();
            b.IncludeLabel = true;
            // Se genera código de barras con codificacion - 128 
            // Se le indica el contenido, el color de las barras, el color del fondo, el ancho y largo
            var img = Image.FromStream(b.Encode(Type.Code128, content, SKColors.Black, SKColors.White, 360, 120).Encode().AsStream());
            using (MemoryStream ms = new MemoryStream())
            {
                // Guarda la imagen en el flujo de memoria en formato PNG
                // La informacion se guarda en una imagen con extension png
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                // Devuelve el array de bytes
                // El MemoryStream se convierte en una cadena de texti en base 64
                string base64String = Convert.ToBase64String(ms.ToArray());
                return base64String;
            }
        }

        /// <summary>
        /// Metodo que convierte una cadena de texto en la data de una imagen de codigo QR en base 64
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string GenerateQR(string content)
        {
            string QRCODETEXT = string.Empty;
            QRCodeGenerator qrgenerador = new QRCodeGenerator();
            // Se genera un codigo de barras con el contennido pedido por el parametro y se le indica un level
            QRCodeData qrdato = qrgenerador.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrcode = new BitmapByteQRCode(qrdato);
            // Se le indica el tamaño
            byte[] qrCodeAsByteArr = qrcode.GetGraphic(5);

            var ms = new MemoryStream(qrCodeAsByteArr);
            // El MemoryStream se convierte a una cadena de texto en base 64
            QRCODETEXT = Convert.ToBase64String(ms.ToArray());

            // Convierte la cadena base64 de nuevo en un arreglo de bytes
            byte[] qrCodeBytes = Convert.FromBase64String(QRCODETEXT);
            return QRCODETEXT;
        }
    }
}
