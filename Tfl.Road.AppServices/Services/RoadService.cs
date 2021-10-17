using System;
using System.Collections.Generic;
using System.Net.Http;
using Tfl.Road.AppServices.Models;

namespace Tfl.Road.AppServices.Services
{
    public class RoadService : IRoadService
    {
        public RoadStatus GetByRoad(string road)
        {
            if (road == null)
            {
                throw new ArgumentNullException(nameof(road));
            }

            return new RoadStatus
            {
                DisplayName = "A10",
                StatusSeverity = "Good",
                StatusSeverityDescription = "No Exceptional Delays",
                IsError = false,
                ErrorMessage = string.Empty
            };
        }
    }
}
