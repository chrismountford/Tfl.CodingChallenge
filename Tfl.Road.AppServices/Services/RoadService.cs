using System;
using System.Collections.Generic;
using System.Net.Http;
using Tfl.Road.AppServices.Models;

namespace Tfl.Road.AppServices.Services
{
    public class RoadService : IRoadService
    {
        public List<RoadModel> GetByRoad(string road)
        {
            throw new ArgumentNullException();
        }
    }
}
