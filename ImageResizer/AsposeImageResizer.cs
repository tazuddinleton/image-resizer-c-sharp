using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    public class AsposeImageResizer
    {
        public static void Resize(string dir)
        {
            var zoomFactor = 0.5F;
 
           
            for(int i = 0; i <= 16; i++)
            {

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dir + "T2_test.png"))
                {
                    int newWidth = (int)(image.Width * zoomFactor);
                    int newHeight = (int)(image.Height * zoomFactor);
                    // Scale down by 2 times using Bilinear resampling.
                    image.Resize(newWidth, newHeight, (Aspose.Imaging.ResizeType)i);
                    image.Save(dir + $"{i}.downsample.{((Aspose.Imaging.ResizeType)i).ToString()}.png");
                }
            }
            
        }
    }
}
