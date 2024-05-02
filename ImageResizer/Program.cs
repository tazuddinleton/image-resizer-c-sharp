using System.Drawing;
using System.Drawing.Imaging;

namespace ImageResizer;

public static class Program
{
    private static string InputPath = "C:\\work\\lab\\image-resizer-c-sharp\\ImageResizer\\Input\\wood_Black.png";
    private static string OutputPath = "C:\\work\\lab\\image-resizer-c-sharp\\ImageResizer\\Output";
    public static void Main(string[] args)
    {


        AsposeImageResizer.Resize("C:\\work\\lab\\image-resizer-c-sharp\\ImageResizer\\Input\\");
        
        Console.WriteLine("Hello world");
    }

    public static void UseNative()
    {
        var image = Image.FromFile(InputPath);

        using (var ms = new MemoryStream())
        {
            image.Save(ms, ImageFormat.Jpeg);

            var b = Utility.ZoomImage(ms.ToArray(), 0.2f);

            using (var js = new MemoryStream(b))
            {
                var resized = Image.FromStream(js);

                resized.Save(Path.Combine(OutputPath, "wood_Black.png"));
            }
        }
    }
}