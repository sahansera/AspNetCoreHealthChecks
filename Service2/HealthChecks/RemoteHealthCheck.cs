using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Service2.HealthChecks
{
    public class RemoteHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            var isHealthy = CheckRemoteEndpointHealth();

            return Task.FromResult(isHealthy ? 
                HealthCheckResult.Healthy("Remote endpoint is healthy.") :
                HealthCheckResult.Unhealthy("Remote endpoint is unhealthy"));
        }

        private bool CheckRemoteEndpointHealth()
        {
            // Just stubbing it out for demo
            var rnd = new Random().Next(1, 5);
            return rnd % 2 != 0;
        }
    }
}