using Microsoft.AspNetCore.Mvc.Testing;
using StudentsAPI.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace StudentsAPIClient.IntegrationTests
{
    public class StudentsStatisticsControllerTests : IntegrationTestsBase
    {
        public StudentsStatisticsControllerTests(StudentsApiClientWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

       [Fact]
       async Task TestGetStudentStatistics()
        {
            var response = await client.GetAsync("api/studentsstatistics");
            using var responseStream = await response.Content.ReadAsStreamAsync();
            List<StudentStatistics> stats = await JsonSerializer.DeserializeAsync<List<StudentStatistics>>(responseStream);
            Assert.Equal(5, stats.Count);
            //Assert.Equal(1, stats.First().CommitNr);

        }


    }
}
