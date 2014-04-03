using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularQuiz.Web.Startup))]
namespace AngularQuiz.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
