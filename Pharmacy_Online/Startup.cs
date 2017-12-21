using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pharmacy_Online.Startup))]

namespace Pharmacy_Online
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
