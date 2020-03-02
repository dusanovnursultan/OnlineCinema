using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineCinema.Startup))]
namespace OnlineCinema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
