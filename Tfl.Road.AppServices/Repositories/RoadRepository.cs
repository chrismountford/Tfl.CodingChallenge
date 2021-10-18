using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Tfl.Road.AppServices.Models;

namespace Tfl.Road.AppServices.Repositories
{
    public class RoadRepository : IRoadRepository
    {
        private readonly HttpClient _httpClient;

        public RoadRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ApiResponse GetById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var uri = $"https://api.tfl.gov.uk/Road/{id}";

            var response = _httpClient.GetAsync(uri).Result;

            return new ApiResponse
            {
                StatusCode = response.StatusCode,
                ResponseBody = response.Content.ReadAsStringAsync().Result
            };
        }
    }
}
