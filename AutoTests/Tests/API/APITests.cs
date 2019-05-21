using NUnit.Framework;
using RestSharp;
using ToptalTestAutomation.Engine;
using System.Net;

namespace ToptalTestAutomation.Tests.API
{
    [TestFixture]
    public class APITests
    {       

        [OneTimeSetUp]
        public void Setup()
        {            
        }

        [Test]
        public void Basictest()
        {
            var request = new RestRequest("v1?apiKey=at_08HkDwTYC8ygW3NSKRF9iIFSYqL4F&ipAddress=8.8.8.8", Method.GET);
            var response = ClientApi.GetInstance().Client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void WrongCredentials()
        {
            var request = new RestRequest("v1?apiKey=ay_08HkDwTYC8ygW3NSKRF9iIFSYqL4F&ipAddress=8.8.8.8", Method.GET);
            var response = ClientApi.GetInstance().Client.Execute(request);
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Test]
        public void WrongIpAdress()
        {
            var request = new RestRequest("v1?apiKey=at_08HkDwTYC8ygW3NSKRF9iIFSYqL4F&ipAddress=0", Method.GET);
            var response = ClientApi.GetInstance().Client.Execute(request);
            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TearDown]
        public void End()
        {
        }
    }
}
