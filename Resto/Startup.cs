using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Resto.Startup))]
namespace Resto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
