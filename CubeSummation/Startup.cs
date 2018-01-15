using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CubeSummation.Startup))]
namespace CubeSummation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
