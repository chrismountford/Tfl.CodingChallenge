using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Tfl.Road.AppServices.Models;

namespace Tfl.Road.AppServices.Repositories
{
    public class RoadRepository : IRoadRepository
    {
        public ApiResponse GetById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return new ApiResponse
            {
                StatusCode = HttpStatusCode.OK,
                ResponseBody = "Good response"
            };
        }
    }
}
