using System.IO;
using System.Web.Mvc;

namespace Pharmacy_Online.Infrastructure
{
    public static class UrlHelpers
    {
        public static string ProductsPicturePath(this UrlHelper helper, string IconFileName)
        {
            var pictureFolder = AppConfig.ProductsPictureFolder;
            var path = Path.Combine(pictureFolder, IconFileName);
            var absolutePath = helper.Content(path);

            return absolutePath;
        }
    }
}