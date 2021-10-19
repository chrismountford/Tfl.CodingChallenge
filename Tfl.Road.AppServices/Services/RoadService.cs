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

            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                    var body = JsonSerializer.Deserialize<List<TflRoadEntity>>(result.ResponseBody);
                    return new RoadStatus
                    {
                        DisplayName = body[0].DisplayName,  // We should check to see if there is more than 1, should be safe for this challenge though...
                        StatusSeverity = body[0].StatusSeverity,
                        StatusSeverityDescription = body[0].StatusSeverityDescription,
                        IsError = false,
                        ErrorMessage = string.Empty
                    };

                case HttpStatusCode.NotFound:
                    var badResponseBody = JsonSerializer.Deserialize<BadResponse>(result.ResponseBody);

                    return new RoadStatus
                    {
                        DisplayName = road,
                        StatusSeverity = null,
                        StatusSeverityDescription = null,
                        IsError = true,
                        ErrorMessage = badResponseBody.Message
                    };

                default:
                    throw new NotImplementedException("We shouldn't hit this");
            }
        }
    }
}
