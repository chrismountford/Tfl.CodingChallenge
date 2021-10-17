using System;
using System.Collections.Generic;
using System.Net;
using Moq;
using NUnit.Framework;
using Tfl.Road.AppServices.Models;
using Tfl.Road.AppServices.Repositories;
using Tfl.Road.AppServices.Services;

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
            var validResponse = new ApiResponse
            {
                StatusCode = HttpStatusCode.OK,
                ResponseBody = new TflRoadEntity
                {
                    Id = "A10",
                    DisplayName = "A10",
                    StatusSeverity = "Good",
                    StatusSeverityDescription = "No Exceptional Delays"
                }
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
    }
}
