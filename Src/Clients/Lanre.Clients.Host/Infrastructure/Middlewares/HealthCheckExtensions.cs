// Copyright (c) Lanre. All rights reserved.

namespace Microsoft.Extensions.DependencyInjection
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;
    using Microsoft.Extensions.Diagnostics.HealthChecks;

    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
        {
            var hcBuilder = services.AddHealthChecks();

            hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

            // hcBuilder
            //     .AddSqlServer(
            //         configuration["ConnectionString"],
            //         name: "OrderingDB-check",
            //         tags: new string[] { "orderingdb" });
            return services;
        }

        public static IApplicationBuilder UseHealthChecks(this IApplicationBuilder app)
        {
            return app.UseHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self"),
            });
        }
    }
}