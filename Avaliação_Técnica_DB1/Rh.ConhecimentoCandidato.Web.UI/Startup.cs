using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rh.ConhecimentoCandidato.Web.UI.Startup))]
namespace Rh.ConhecimentoCandidato.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
