using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ILenguage.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ILenguage.API.Domain.Models;
using Newtonsoft.Json;
using Xunit;

namespace ILanguage.API.Test.integrationTest
{
    public class SessionControllerTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public SessionControllerTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        //HappyPath
        [Fact]
        public async Task GetTheFieldsOfSessionAsyncWithAValidSessionReturnsCorrect()
        {

            //Arrange
            var request = "/api/sessions/1";

            //Act
            var response = await Client.GetAsync(request);
            var responseAsJsonDeserialized = await response.Content.ReadFromJsonAsync<Session>();

            //Asserts
            response.EnsureSuccessStatusCode();
            responseAsJsonDeserialized.Id.Should().Equals(1);
            responseAsJsonDeserialized.Link.Should().Be("zoom.com");
            responseAsJsonDeserialized.State.Should().Be("active");
            responseAsJsonDeserialized.Topic.Should().Be("nothing");

        }
        //UnhappyPath
        [Fact]
        public async Task GetSessionByIdWhenSessionDoesNotExistreturnsNotFound()
        {
            //Arrange
            var request = "/api/sessions/1000";
            int expectedStatusCode = 404;
            string expectedMessage = "Bad Request";
            //Act
            var response = await Client.GetAsync(request);
            var gottenStatusCode = response.StatusCode;
            string gottenMessage = response.ReasonPhrase;

            //Arrange
            expectedMessage.Should().Be(gottenMessage);
            expectedStatusCode.Should().Equals(gottenStatusCode);

        }

        [Fact]
        public async Task GetAllStatesOfSessionssAsyncWhenAtLeastOneSessionReturnsPassedTest()
        {
            //Arrange
            var request = "/api/sessions";

            //Act
            var response = await Client.GetAsync(request);
            var responseAsJsonDeserialized = await response.Content.ReadFromJsonAsync<IEnumerable<Session>>();
            var listOfGottenSessions = responseAsJsonDeserialized.ToList();

            //Asserts
            response.EnsureSuccessStatusCode();
            listOfGottenSessions[0].State.Should().Be("active");
            listOfGottenSessions[1].State.Should().Be("active");
            listOfGottenSessions[2].State.Should().Be("active");

        }


        [Fact]
        public async Task DeleteByIdAsyncWhenSessionIdIsValidReturnsSuccess()
        {
            //Arrange
            var request = "/api/sessions/7";
            int expectedStatusCode = 200;
            string expectedMessage = "OK";

            //Act
            var response = await Client.DeleteAsync(request);
            string gottenMessage = response.ReasonPhrase;
            var gottenStatusCode = response.StatusCode;

            //Asserts
            response.EnsureSuccessStatusCode();
            expectedMessage.Should().Be(gottenMessage);
            expectedStatusCode.Should().Equals(gottenStatusCode);

        }
        [Fact]
        public async Task GetByIdAsyncWhenInvalidReturnsSessionsNotFoundResponse()
        {
            //Arrange
            var request = "/api/sessions/50";
            int expectedStatusCode = 400;
            string expectedMessage = "Bad Request";

            //Act
            var response = await Client.DeleteAsync(request);
            string gottenMessage = response.ReasonPhrase;
            var gottenStatusCode = response.StatusCode;

            //Asserts

            expectedMessage.Should().Be(gottenMessage);
            expectedStatusCode.Should().Equals(gottenStatusCode);

        }





    }
}
