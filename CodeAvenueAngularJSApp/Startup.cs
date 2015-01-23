using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeAvenueAngularJSApp.Startup))]
namespace CodeAvenueAngularJSApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
