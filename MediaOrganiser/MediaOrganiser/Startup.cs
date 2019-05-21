using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaOrganiser.Startup))]
namespace MediaOrganiser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
