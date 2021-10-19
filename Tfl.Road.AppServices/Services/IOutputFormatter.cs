using System;
using System.Collections.Generic;
using System.Text;

namespace Tfl.Road.AppServices.Services
{
    public interface IOutputFormatter
    {
        string Format(RoadStatus status);
    }
}
