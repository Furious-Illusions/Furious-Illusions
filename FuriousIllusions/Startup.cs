using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FuriousIllusions.Startup))]
namespace FuriousIllusions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
