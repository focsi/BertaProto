using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BertaProto.Startup))]
namespace BertaProto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
