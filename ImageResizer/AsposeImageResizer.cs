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

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dir + "T2_test.png"))
            {
                // Scale up by 2 times using Nearest Neighbour resampling.
                image.Resize(image.Width * 2, image.Height * 2, Aspose.Imaging.ResizeType.NearestNeighbourResample);
                image.Save(dir + "upsample.nearestneighbour.png");
            }

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dir + "T2_test.png"))
            {
                // Scale down by 2 times using Nearest Neighbour resampling.
                image.Resize(image.Width / 2, image.Height / 2, Aspose.Imaging.ResizeType.NearestNeighbourResample);
                image.Save(dir + "downsample.nearestneighbour.png");
            }

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dir + "T2_test.png"))
            {
                // Scale up by 2 times using Bilinear resampling.
                image.Resize(image.Width * 2, image.Height * 2, Aspose.Imaging.ResizeType.BilinearResample);
                image.Save(dir + "upsample.bilinear.png");
            }

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dir + "T2_test.png"))
            {
                // Scale down by 2 times using Bilinear resampling.
                image.Resize(image.Width / 2, image.Height / 2, Aspose.Imaging.ResizeType.BilinearResample);
                image.Save(dir + "downsample.bilinear.png");
            }
        }
    }
}
