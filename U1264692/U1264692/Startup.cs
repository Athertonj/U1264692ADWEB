using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(U1264692.Startup))]
namespace U1264692
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
