using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(CXS.Core.Framework.RendererApi.Startup))]

namespace CXS.Core.Framework.RendererApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
            app.UseCors(CorsOptions.AllowAll);
        }
    }
}
