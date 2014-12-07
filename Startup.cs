using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LNB.Startup))]
namespace LNB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
