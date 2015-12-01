using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MordheimRoster.Startup))]
namespace MordheimRoster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
