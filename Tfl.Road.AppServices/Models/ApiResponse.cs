using System.Net;

namespace Tfl.Road.AppServices.Models
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object ResponseBody { get; set; }
    }
}
