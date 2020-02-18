using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swisschain.Sdk.Server.Common;

namespace Service.Example.WebApi.IsAlive
{
    [ApiController]
    [Route("api/[controller]")]
    public class IsAliveController : ControllerBase
    {
        [HttpGet]
        public IsAliveResponse Get()
        {
            var response = new IsAliveResponse
            {
                Name = ApplicationInformation.AppName,
                Version = ApplicationInformation.AppVersion,
                StartedAt = ApplicationInformation.StartedAt,
                Env = ApplicationEnvironment.Environment,
                HostName = ApplicationEnvironment.HostName,
                StateIndicators = new List<IsAliveResponse.StateIndicator>()
            };

            return response;
        }
    }
}