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
// ReSharper disable All


namespace ILanguage.API.Test.integrationTest
{
  
    public class SubscriptionControllerTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public SubscriptionControllerTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        //HappyPath
        [Fact]
        public async Task GetTheFieldsOfSubscriptionAsyncWithAValidSubscriptionReturnsCorrect()
        {

            //Arrange
            var request = "/api/subscriptions/1";
            
            //Act
            var response = await Client.GetAsync(request);
            var responseAsJsonDeserialized  = await response.Content.ReadFromJsonAsync<Subscription>();
            
            //Asserts
            response.EnsureSuccessStatusCode();
            responseAsJsonDeserialized.Id.Should().Equals(1);
            responseAsJsonDeserialized.Name.Should().Be("Full Year");
            responseAsJsonDeserialized.Price.Should().Equals(99.99);
            responseAsJsonDeserialized.MonthDuration.Should().Equals(12);
            
        }
        //UnhappyPath
        [Fact]
        public async Task GetSubscriptionByIdWhenSubscriptionDoesNotExistreturnsNotFound()
        {
            //Arrange
            var request = "/api/subscriptions/50";
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
        public async Task GetAllNamesOfSubscriptionsAsyncWhenAtLeastOneSubscriptionReturnsPassedTest()
        {
            //Arrange
            var request = "/api/subscriptions";
            
            //Act
            var response = await Client.GetAsync(request);
            var responseAsJsonDeserialized  = await response.Content.ReadFromJsonAsync<IEnumerable<Subscription>>();
            var listOfGottenSubscriptions = responseAsJsonDeserialized.ToList();
            
            //Asserts
            response.EnsureSuccessStatusCode();
            listOfGottenSubscriptions[0].Name.Should().Be("Full Year");
            listOfGottenSubscriptions[1].Name.Should().Be("Full Summer");
            listOfGottenSubscriptions[2].Name.Should().Be("Trimestral");

        }


        [Fact]
        public async Task DeleteByIdAsyncWhenSubscriptionIdIsValidReturnsSuccess()
        {
            //Arrange
            var request = "/api/subscriptions/6";
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
        public async Task DeleteByIdAsyncWhenInvalidReturnsSuscriptionNotFoundResponse()
        {
            //Arrange
            var request = "/api/subscriptions/50";
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