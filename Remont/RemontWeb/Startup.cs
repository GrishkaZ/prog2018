using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RemontWeb.Startup))]
namespace RemontWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
