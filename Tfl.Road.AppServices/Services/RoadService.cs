using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using Tfl.Road.AppServices.Models;
using Tfl.Road.AppServices.Repositories;

namespace Tfl.Road.AppServices.Services
{
    public class RoadService : IRoadService
    {
        private readonly IRoadRepository _repository;

        public RoadService(IRoadRepository repository)
        {
            _repository = repository;
        }

        public RoadStatus GetByRoad(string road)
        {
            if (road == null)
            {
                throw new ArgumentNullException(nameof(road));
            }

            var result = _repository.GetById(road);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var body = JsonSerializer.Deserialize<TflRoadEntity>(result.ResponseBody);
                return new RoadStatus
                {
                    DisplayName = body.DisplayName,
                    StatusSeverity = body.StatusSeverity,
                    StatusSeverityDescription = body.StatusSeverityDescription,
                    IsError = false,
                    ErrorMessage = string.Empty
                };
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                var body = JsonSerializer.Deserialize<BadResponse>(result.ResponseBody);

                return new RoadStatus
                {
                    DisplayName = null,
                    StatusSeverity = null,
                    StatusSeverityDescription = null,
                    IsError = true,
                    ErrorMessage = body.Message
                };
            }
            
            throw new NotImplementedException("We shouldn't hit this");
        }
    }
}
