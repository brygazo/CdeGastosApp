using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CdeGastosApp.Startup))]
namespace CdeGastosApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
