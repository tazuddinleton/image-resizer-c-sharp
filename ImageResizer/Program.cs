using System.Drawing;
using System.Drawing.Imaging;

namespace ImageResizer;

public static class Program
{
    private static string InputPath = "C:\\Users\\Taz\\Downloads\\ImageResizer\\ImageResizer\\ImageResizer\\Input\\panda.jpg";
    private static string OutputPath = "C:\\Users\\Taz\\Downloads\\ImageResizer\\ImageResizer\\ImageResizer\\Output";
    public static void Main(string[] args)
    {


        var image = Image.FromFile(InputPath);

        using (var ms = new MemoryStream())
        {
            image.Save(ms, ImageFormat.Jpeg);

            var b = Utility.ZoomImage(ms.ToArray(), 0.02f);

            using (var js = new MemoryStream(b))
            {
                var resized = Image.FromStream(js);
                
                resized.Save(Path.Combine(OutputPath, "resized.jpeg"));
            }
        }
        
        Console.WriteLine("Hello world");
    }
}