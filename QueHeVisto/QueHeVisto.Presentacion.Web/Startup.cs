using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QueHeVisto.Presentacion.Web.Startup))]
namespace QueHeVisto.Presentacion.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
