using System.Collections.Generic;
using Tfl.Road.AppServices.Models;

namespace Tfl.Road.AppServices.Repositories
{
    public interface IRoadRepository
    {
        ApiResponse GetById(string id);
    }
}
