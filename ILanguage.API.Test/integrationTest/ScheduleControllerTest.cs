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
  
    public class ScheduleControllerTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public ScheduleControllerTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        //HappyPath
        [Fact]
        public async Task GetTheFieldsOfScheduleAsyncWithAValidScheduleReturnsCorrect()
        {

            //Arrange
            var request = "/api/schedules/1";
            
            //Act
            var response = await Client.GetAsync(request);
            var responseAsJsonDeserialized  = await response.Content.ReadFromJsonAsync<Schedule>();
            
            //Asserts
            response.EnsureSuccessStatusCode();
            responseAsJsonDeserialized.Id.Should().Equals(1);
            
            
        }
        //UnhappyPath
        [Fact]
        public async Task GetScheduleByIdWhenScheduleDoesNotExistreturnsNotFound()
        {
            //Arrange
            var request = "/api/schedules/10";
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
        public async Task DeleteByIdAsyncWhenScheduleIdIsValidReturnsSuccess()
        {
            //Arrange
            var request = "/api/schedules/7";
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
        public async Task GetByIdAsyncWhenInvalidReturnsScheduleNotFoundResponse()
        {
            //Arrange
            var request = "/api/schedules/6";
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