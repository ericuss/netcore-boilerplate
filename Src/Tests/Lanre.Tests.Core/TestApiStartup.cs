// Copyright (c) Lanre. All rights reserved.

namespace Lanre.Tests.Core
{
    using System.IO;
    using Lanre.Clients.Api;
    using Lanre.Infrastructure.Entities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class TestApiStartup
    {
        private readonly IHostingEnvironment _currentEnvironment;
        private readonly AppSettings _appSettings;

        public TestApiStartup(IHostingEnvironment env)
        {
            this._currentEnvironment = env;

            var authenticationTestsPath = Directory.GetCurrentDirectory();
            var appJsonPath = Path.GetFullPath(Path.Combine(authenticationTestsPath, "../../../../Lanre.Tests.Core/appsettings.tests.json"));
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(appJsonPath, optional: false, reloadOnChange: true)
                ;

            var builder = configBuilder.Build();
            this._appSettings = builder.Get<AppSettings>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AppSettings>(this._appSettings);

            services
                .ConfigureServicesApi() // this._appSettings.Settings.AddAuthorization)
                .AddApplicationPart(typeof(Clients.Api.Controllers.V1.HomeController).Assembly) // Fix for integration tests
                ;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app
                .ConfigureApi();
        }
    }
}