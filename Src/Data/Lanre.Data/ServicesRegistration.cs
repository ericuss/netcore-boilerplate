// Copyright (c) Lanre. All rights reserved.

namespace Lanre.Data
{
    using Lanre.Data.Contexts.Lanre;
    using Lanre.Infrastructure.Entities;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, AppSettings settings)
        {
            services
                .RegisterRepositories()
                .RegisterReadOnlyRepositories()
                .RegisterDB(settings)
                ;

            return services;
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection RegisterReadOnlyRepositories(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection RegisterDB(this IServiceCollection services, AppSettings settings)
        {
            LanreContextInitializer.Instance.ConfigureDB(
                services,
                settings.ConnectionStrings.Lanre,
                "lanre",
                settings).Wait();
            return services;
        }
    }
}
