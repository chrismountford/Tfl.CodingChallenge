using System;
using System.Collections.Generic;
using System.Net;
using Moq;
using NUnit.Framework;
using Tfl.Road.AppServices.Models;
using Tfl.Road.AppServices.Repositories;
using Tfl.Road.AppServices.Services;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Tfl.Road.UnitTests
{
    [TestFixture]
    public class RoadServiceTests
    {
        private readonly Mock<IRoadRepository> repoMock = new Mock<IRoadRepository>();
        private IRoadService roadService;

        [SetUp]
        public void Setup()
        {
            roadService = new RoadService(repoMock.Object);
        }

        [Test]
        public void GetByRoad_ShouldThrowNullException_WhenRoadSuppliedIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                roadService.GetByRoad(null);
            });
        }

        [Test]
        public void GetByRoad_ShouldReturnValidResponse_WhenRoadIsValid()
        {
            // Arrange
            var roadStatus = new RoadStatus
            {
                DisplayName = "A10",
                StatusSeverity = "Good",
                StatusSeverityDescription = "No Exceptional Delays",
                IsError = false,
                ErrorMessage = string.Empty
            };

            var responseBody = JsonSerializer.Serialize(new List<TflRoadEntity>
                {
                    new TflRoadEntity
                    {
                        Id = "A10",
                        DisplayName = "A10",
                        StatusSeverity = "Good",
                        StatusSeverityDescription = "No Exceptional Delays"
                    }
                }
            );

            var validResponse = new ApiResponse
            {
                StatusCode = HttpStatusCode.OK,
                ResponseBody = responseBody
            };

            repoMock.Setup(x => x.GetById("A10")).Returns(validResponse);

            // Act
            var result = roadService.GetByRoad("A10");

            // Assert
            Assert.AreEqual(roadStatus.DisplayName, result.DisplayName);
            Assert.AreEqual(roadStatus.StatusSeverity, result.StatusSeverity);
            Assert.AreEqual(roadStatus.StatusSeverityDescription, result.StatusSeverityDescription);
            Assert.IsFalse(result.IsError);
        }

        [Test]
        public void GetByRoad_ShouldReturnInvalidResponse_WhenRoadIsNotValid()
        {
            // Arrange
            var badRoad = "a10fdffdf";
            var errorMessage = $"The following road id is not recognised: {badRoad}";
            var roadStatus = new RoadStatus()
            {
                DisplayName = badRoad,
                StatusSeverity = null,
                StatusSeverityDescription = null,
                IsError = true,
                ErrorMessage = errorMessage
            };

            var responseBody = JsonSerializer.Serialize(new BadResponse
            {
                // We only really care about the Message property here
                Type = "",
                TimeStampUtc = DateTime.Now,
                ExceptionType = "",
                HttpStatusCode = HttpStatusCode.NotFound,
                HttpStatus = "NotFound",
                RelativeUri = "",
                Message = errorMessage
            });

            var invalidResponse = new ApiResponse
            {
                StatusCode = HttpStatusCode.NotFound,
                ResponseBody = responseBody
            };

            repoMock.Setup(x => x.GetById("a10fdffdf")).Returns(invalidResponse);

            // Act
            var result = roadService.GetByRoad(badRoad);

            // Assert
            Assert.AreEqual(badRoad, result.DisplayName);
            Assert.IsNull(result.StatusSeverity);
            Assert.IsNull(result.StatusSeverityDescription);
            Assert.IsTrue(result.IsError);
            Assert.AreEqual(roadStatus.ErrorMessage, result.ErrorMessage);
        }
    }
}
