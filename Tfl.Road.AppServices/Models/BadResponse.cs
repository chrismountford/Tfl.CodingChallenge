using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Tfl.Road.AppServices.Models
{
    public class BadResponse
    {
        public string Type { get; set; }
        public string TimeStampUtc { get; set; }
        public string ExceptionType { get; set; }
        public HttpStatusCode HttpStatusCode  { get; set; }
        public string HttpStatus { get; set; }
        public string RelativeUri { get; set; }
        public string Message { get; set; }
    }
}
