using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoldSaver.Startup))]
namespace GoldSaver
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
