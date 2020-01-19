using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using Xunit;

namespace StudentsAPIClient.IntegrationTests
{
    public class IntegrationTestsBase : IClassFixture<StudentsApiClientWebApplicationFactory<Startup>>
    {
        protected readonly StudentsApiClientWebApplicationFactory<Startup> factory;
        protected readonly HttpClient client;

        public IntegrationTestsBase(StudentsApiClientWebApplicationFactory<Startup> factory)
        {
            client = factory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            this.factory = factory;
        }

    }
}
