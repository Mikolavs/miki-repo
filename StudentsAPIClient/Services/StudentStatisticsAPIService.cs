using StudentsAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentsAPIClient.Services
{
    public class StudentStatisticsAPIService
    {
        private readonly HttpClient client;

        public StudentStatisticsAPIService(HttpClient client)
        {
            this.client = client;
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Add("api-version", "2.0");
            client.DefaultRequestHeaders.Add("x-api-key", "123456");
        }

        public async Task<IEnumerable<StudentStatistics>> Get()
        {
            Stream studentResponseStream = await GetStudentList();
            Stream commitResponseStream = await GetCodeCommitList();

            IEnumerable<Student> students = await JsonSerializer.DeserializeAsync<IEnumerable<Student>>(studentResponseStream);
            IEnumerable<CodeCommit> commits = await JsonSerializer.DeserializeAsync<IEnumerable<CodeCommit>>(commitResponseStream);

            List<Student> studentList = students.ToList();
            List<CodeCommit> commitList = commits.ToList();

            return GetStudentStatistics(studentList, commitList);
        }

        private IEnumerable<StudentStatistics> GetStudentStatistics(List<Student> studentList, List<CodeCommit> commitList)
        {
            List<StudentStatistics> studentStatisticsList = new List<StudentStatistics>();
            int commitNr = 0;
            long modCodeLineNr = 0;
            StudentStatistics studStats;

            foreach (var student in studentList)
            {
                commitNr = 0;
                modCodeLineNr = 0;

                foreach (var commit in commitList)
                {
                    if (student.Id.Equals(commit.UserId))
                    {
                        commitNr++;
                        modCodeLineNr = commit.LinesModified == null ? 0 : (long)commit.LinesModified;
                    }
                }

                studStats = new StudentStatistics();
                studStats.Student = student;
                studStats.CommitNr = commitNr;
                studStats.ModifiedCodeLineNr = modCodeLineNr;

                studentStatisticsList.Add(studStats);
            }

            return studentStatisticsList;
        }

        private async Task<Stream> GetStudentList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/students");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string message = string.Format(
                    "Error while using StudentsAPI (status code: {0}, reason: {1})",
                    response.StatusCode,
                    response.ReasonPhrase);

                throw new HttpRequestException(message);
            }
            var responseStream = await response.Content.ReadAsStreamAsync();
            return responseStream;
        }

        private async Task<Stream> GetCodeCommitList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/codecommits");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string message = string.Format(
                    "Error while using StudentsAPI (status code: {0}, reason: {1})",
                    response.StatusCode,
                    response.ReasonPhrase);

                throw new HttpRequestException(message);
            }
            var responseStream = await response.Content.ReadAsStreamAsync();
            return responseStream;
        }
    }
}
