using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageResizer;

public class Utility
{
      
    public static byte[] ZoomImage(byte[] originalImageBytes, float zoomFactor)
    {
        // Convert byte[] to Image
        Image originalImage;
        using (MemoryStream ms = new MemoryStream(originalImageBytes))
        {
            originalImage = Image.FromStream(ms);
        }

        // Calculate the new dimensions
        int newWidth = (int)(originalImage.Width * zoomFactor);
        int newHeight = (int)(originalImage.Height * zoomFactor);

        // Create a new bitmap with the new dimensions
        Bitmap zoomedBitmap = new Bitmap(newWidth, newHeight);

        using (Graphics g = Graphics.FromImage(zoomedBitmap))
        {
            // Set the interpolation mode to HighQualityBicubic to improve quality
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Draw the original image onto the new bitmap with the new dimensions
            g.DrawImage(originalImage, new Rectangle(0, 0, newWidth, newHeight));
        }

        // Convert Bitmap to byte[]
        byte[] zoomedImageBytes;
        using (MemoryStream ms = new MemoryStream())
        {
            zoomedBitmap.Save(ms, ImageFormat.Png); // You can use other image formats if needed
            zoomedImageBytes = ms.ToArray();
        }

        return zoomedImageBytes;
    }



}