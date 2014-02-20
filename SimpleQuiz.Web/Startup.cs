using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleQuiz.Web.Startup))]
namespace SimpleQuiz.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
