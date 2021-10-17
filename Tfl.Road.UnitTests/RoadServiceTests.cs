using System;
using System.Collections.Generic;
using NUnit.Framework;
using Tfl.Road.AppServices.Models;
using Tfl.Road.AppServices.Services;

namespace Tfl.Road.UnitTests
{
    [TestFixture]
    public class RoadServiceTests
    {
        [Test]
        public void GetByRoad_ShouldThrowNullException_WhenRoadSuppliedIsNull()
        {
            // Arrange
            IRoadService roadService = new RoadService();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                roadService.GetByRoad(null);
            });
        }

        [Test]
        public void GetByRoad_ShouldReturnValidResponse_WhenRoadIsValid()
        {
            // Arrange
            IRoadService roadService = new RoadService();
            var roadStatus = new RoadStatus
            {
                DisplayName = "A10",
                StatusSeverity = "Good",
                StatusSeverityDescription = "No Exceptional Delays",
                IsError = false,
                ErrorMessage = string.Empty
            };

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
