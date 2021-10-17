using System;
using System.Collections.Generic;
using Tfl.Road.AppServices.Models;

namespace Tfl.Road.AppServices.Repositories
{
    public class RoadRepository : IRoadRepository
    {
        public List<TflRoadEntity> GetById(string id)
        {
            throw new ArgumentNullException(nameof(id));
        }
    }
}
