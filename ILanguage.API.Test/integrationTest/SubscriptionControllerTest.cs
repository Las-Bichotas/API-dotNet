using System;
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
  
    public class SubscriptionControllerTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public SubscriptionControllerTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task GetTheFieldsOfSubscriptionWithAValidSubscriptionReturnsCorrect()
        {

            var request = "/api/subscriptions/1";
            var response = await Client.GetAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsJsonDeserialized  = await response.Content.ReadFromJsonAsync<Subscription>();
            
            responseAsJsonDeserialized.Id.Should().Equals(1);
            responseAsJsonDeserialized.Name.Should().Be("All New Basic");
            responseAsJsonDeserialized.Price.Should().Equals(99.99);
            responseAsJsonDeserialized.MonthDuration.Should().Equals(10);


        }

     
        
        
    }
}