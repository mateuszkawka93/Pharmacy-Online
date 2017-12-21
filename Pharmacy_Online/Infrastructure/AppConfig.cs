using System.Configuration;

namespace Pharmacy_Online.Infrastructure
{
    public class AppConfig
    {
        public static string ProductsPictureFolder { get; } = ConfigurationManager.AppSettings["ProductsIconFolder"];
    }
}