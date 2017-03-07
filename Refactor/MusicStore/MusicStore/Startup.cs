using Microsoft.Owin;
using Owin;

//加入下面一行特性 log4net对整个程序生效
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
[assembly: OwinStartupAttribute(typeof(MusicStore.Startup))]
namespace MusicStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
