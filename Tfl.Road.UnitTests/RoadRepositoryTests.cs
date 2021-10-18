using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using NUnit.Framework;
using Tfl.Road.AppServices.Repositories;

namespace Tfl.Road.UnitTests
{
    [TestFixture]
    public class RoadRepositoryTests
    {
        [Test]
        public void GetById_ShouldThrowException_WhenIdIsNull()
        {
            // Arrange
            IRoadRepository repo = new RoadRepository();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                repo.GetById(null);
            });
        }

        [Test]
        public void GetById_ReturnsCorrectApiResponse_WhenIdIsValidRoad()
        {
            // Arrange
            IRoadRepository repo = new RoadRepository();

            // Act
            var result = repo.GetById("A10");

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(result.ResponseBody, "Good response");
        }
    }
}
