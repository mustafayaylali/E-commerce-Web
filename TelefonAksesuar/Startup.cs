using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TelefonAksesuar.Startup))]
namespace TelefonAksesuar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
