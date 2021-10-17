using System.Collections.Generic;
using Tfl.Road.AppServices.Models;

namespace Tfl.Road.AppServices.Services
{
    public interface IRoadService
    {
        RoadStatus GetByRoad(string road);
    }
}
