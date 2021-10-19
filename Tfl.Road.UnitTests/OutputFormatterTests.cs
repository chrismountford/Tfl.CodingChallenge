using NUnit.Framework;
using Tfl.Road.AppServices;
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

            var expectedOutput = new Output
            {
                ExitCode = 0,
                OutputText = @"The status of the A10 is as follows
Road Status is Good
Road Status Description is No Exceptional Delays"
        };

            // Act
            var result = formatter.Format(goodResponse);

            // Assert
            Assert.AreEqual(expectedOutput.OutputText, result.OutputText);
            Assert.AreEqual(expectedOutput.ExitCode, 0);
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

            var expectedOutput = new Output
            {
                ExitCode = 1,
                OutputText = @"A233 is not a valid road"
            };

            // Act
            var result = formatter.Format(badResponse);

            // Assert
            Assert.AreEqual(expectedOutput.OutputText, result.OutputText);
            Assert.AreEqual(expectedOutput.ExitCode, 1);
        }
    }
}
