using System;
using System.Collections.Generic;
using System.Net.Http;
using Tfl.Road.AppServices.Models;

namespace Tfl.Road.AppServices.Repositories
{
    public class RoadRepository : IRoadRepository
    {
        public ApiResponse GetById(string id)
        {
            return new ApiResponse();
        }
    }
}
