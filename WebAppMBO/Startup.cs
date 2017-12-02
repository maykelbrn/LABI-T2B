using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppMBO.Startup))]
namespace WebAppMBO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
