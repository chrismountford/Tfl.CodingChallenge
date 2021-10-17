using System;
using NUnit.Framework;
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
    }
}
