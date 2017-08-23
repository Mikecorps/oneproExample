using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EjercicioOneProEjem.Startup))]
namespace EjercicioOneProEjem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
