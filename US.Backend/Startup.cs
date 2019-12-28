using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(US.Backend.Startup))]
namespace US.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
