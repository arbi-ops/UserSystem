using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserSystem.Startup))]
namespace UserSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
