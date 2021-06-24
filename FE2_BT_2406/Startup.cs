using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FE2_BT_2406.Startup))]
namespace FE2_BT_2406
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
