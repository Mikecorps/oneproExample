using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(chartTest.Startup))]
namespace chartTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
