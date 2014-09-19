using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UsingSignalR.Startup))]
namespace UsingSignalR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
