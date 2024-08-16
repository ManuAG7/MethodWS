using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MethodWS.Startup))]
namespace MethodWS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
