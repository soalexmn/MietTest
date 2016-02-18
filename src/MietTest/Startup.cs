using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KovchegSite.Startup))]
namespace KovchegSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
