using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LotteryTicket.Startup))]
namespace LotteryTicket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
