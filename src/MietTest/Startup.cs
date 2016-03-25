using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MietTest.Startup))]
namespace MietTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            new IdentityConfig().Configuration(app);
        }
    }
}
