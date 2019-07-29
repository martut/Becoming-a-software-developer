using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Episode1.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class WebTests
    {

        public HttpClient HttpClient;

        
        [SetUp]
        public void Setup()
        {    
            HttpClient = new HttpClient();
        }
        
        
        [Test]
        public async Task http_response_should_have_204_status_code()
        {
            //Arrange
            
           
            //Act
            var response = await HttpClient.GetAsync("http://httpstat.us/204");
            
            //Assert
            response.Should().NotBeNull();
            
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);
        }
    }
}