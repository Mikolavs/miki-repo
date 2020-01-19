using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using StudentsAPIClient.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPIClient.IntegrationTests
{
    public class StudentsApiClientWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
        }

    }
}
