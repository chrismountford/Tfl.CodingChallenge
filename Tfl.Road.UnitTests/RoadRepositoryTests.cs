using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using Tfl.Road.AppServices.Repositories;

namespace Tfl.Road.UnitTests
{
    [TestFixture]
    public class RoadRepositoryTests
    {
        private IRoadRepository repo;

        [Test]
        public void GetById_ShouldThrowException_WhenIdIsNull()
        {
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                repo.GetById(null);
            });
        }

        [Test]
        public void GetById_ReturnsCorrectApiResponse_WhenIdIsValidRoad()
        {
            // Act
            var handler = new Mock<HttpMessageHandler>();
            handler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("Good response")
                })
                .Verifiable();

            var client = new HttpClient(handler.Object)
            {
                BaseAddress = new Uri("http://something.com")
            };

            //var config = new Mock<IConfiguration>();
            //config.Setup(x => x[It.Is<string>(s => s == "ApiKey")]).Returns("FakeKey");
            //config.Setup(x => x[It.Is<string>(s => s == "AppId")]).Returns("FakeId");

            var configSettings = new Dictionary<string, string>
            {
                {"apiKey", "KEY"},
                {"appId", "ID"}
            };

            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(configSettings)
                .Build();

            repo = new RoadRepository(client, config);
            var result = repo.GetById("A10");

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(result.ResponseBody, "Good response");
        }
    }
}
