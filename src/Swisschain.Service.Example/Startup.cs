using Microsoft.Extensions.Configuration;
using Swisschain.Service.Example.Common;

namespace Swisschain.Service.Example
{
    public class Startup : SwisschainStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
