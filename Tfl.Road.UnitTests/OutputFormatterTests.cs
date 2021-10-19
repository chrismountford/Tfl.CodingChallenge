using NUnit.Framework;
using Tfl.Road.AppServices.Services;

namespace Tfl.Road.UnitTests
{
    [TestFixture]
    public class OutputFormatterTests
    {
        [Test]
        public void Format_ShouldReturnCorrectString_For200Response()
        {
            // Arrange
            var formatter = new OutputFormatter();
            var goodResponse = new RoadStatus
            {
                DisplayName = "A10",
                StatusSeverity = "Good",
                StatusSeverityDescription = "No Exceptional Delays",
                IsError = false,
                ErrorMessage = string.Empty
            };

            var expectedOutput = @"The status of the A10 is as follows\r\nRoad Status is Good\r\nRoad Status Description is No Exceptional Delays";

            // Act
            var result = formatter.Format(goodResponse);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void Format_ShouldReturnCorrectString_For404Response()
        {
            // Arrange
            var formatter = new OutputFormatter();
            var badResponse = new RoadStatus()
            {
                DisplayName = "A233",
                StatusSeverity = null,
                StatusSeverityDescription = null,
                IsError = true,
                ErrorMessage = "The following road id is not recognised: A233"
            };

            var expectedOutput = @"A233 is not a valid road";

            // Act
            var result = formatter.Format(badResponse);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }
    }
}
