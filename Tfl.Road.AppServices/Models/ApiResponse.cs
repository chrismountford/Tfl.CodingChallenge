using System.Net;

namespace Tfl.Road.AppServices.Models
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ResponseBody { get; set; }
    }
}
