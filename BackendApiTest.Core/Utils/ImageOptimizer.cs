using BackendApiTest.Core.Extensions.BasicExtensions;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;

namespace BackendApiTest.Core.Utils
{
    public static class ImageOptimizer
    {
        public static void ImageResizer(this Image image, string fileName, int? width, int? height)
        {
            image.ImageResizer(fileName, width, height);
        }

        public static void ImageResizer(this string inputPath, string outPutPath, string fileName, int? width, int? height)
        {
            var customWidth = width ?? 100;

            var customHeight = height ?? 100;
            string inputImagePath = Path.Combine(inputPath, fileName);
            string outputImagePath = Path.Combine(outPutPath, fileName);

            using (var image = Image.Load(inputImagePath))
            {
                image.Mutate(x => x.Resize(customWidth, customHeight));

                string fileExtension = Path.GetExtension(inputImagePath);
                switch (fileExtension.ToLower())
                {
                    case ".png":
                        {
                            image.Save(outputImagePath, new PngEncoder
                            {

                            });
                            break;
                        }
                    case ".jpg":
                    case ".jpeg":
                        {
                            image.Save(outputImagePath, new JpegEncoder
                            {
                                Quality = 100
                            });
                            break;
                        }
                    case ".webp":
                        {
                            image.Save(outputImagePath, new WebpEncoder
                            {
                                Quality = 100
                            });
                            break;
                        }
                    default:
                        break;
                }
            }
        }


        public static async Task ConvertToWebP(this Image image, string path, string imageName)
        {
            await image.SaveAsWebpAsync(path: path + imageName.ConvertImageNameToWebP(),
                new WebpEncoder()
                {
                    Method = WebpEncodingMethod.BestQuality,
                    Quality = 100
                });
        }

        public static async Task ConvertToWebP(this string path, string imageName)
        {
            Image image = await Image.LoadAsync(path + imageName);
            await ConvertToWebP(image, path, imageName);
        }
    }
}
