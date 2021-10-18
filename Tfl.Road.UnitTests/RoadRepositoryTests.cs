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
        private IRoadRepository repo = new RoadRepository();

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
            var result = repo.GetById("A10");

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(result.ResponseBody, "Good response");
        }
    }
}
