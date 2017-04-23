using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shipbob.Web.Startup))]
namespace Shipbob.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
