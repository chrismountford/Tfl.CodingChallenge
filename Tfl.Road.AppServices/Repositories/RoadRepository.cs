using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Tfl.Road.AppServices.Models;

namespace Tfl.Road.AppServices.Repositories
{
    public class RoadRepository : IRoadRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public RoadRepository(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public ApiResponse GetById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var url = _config["Config:Url"];
            var appKey = _config["Config:apiKey"];
            var appId = _config["Config:appId"];
            var uri = $"{url}{id}?app_id={appId}&app_key={appKey}";

            var response = _httpClient.GetAsync(uri).Result;

            return new ApiResponse
            {
                StatusCode = response.StatusCode,
                ResponseBody = response.Content.ReadAsStringAsync().Result
            };
        }
    }
}
