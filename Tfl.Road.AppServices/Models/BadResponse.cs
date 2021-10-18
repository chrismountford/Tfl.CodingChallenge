using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace Tfl.Road.AppServices.Models
{
    public class BadResponse
    {
        [JsonPropertyName("$type")]
        public string Type { get; set; }
        public string Url { get; set; }
        [JsonPropertyName("timestampUtc")]
        public DateTime TimeStampUtc { get; set; }
        [JsonPropertyName("exceptionType")]
        public string ExceptionType { get; set; }
        [JsonPropertyName("httpStatusCode")]
        public HttpStatusCode HttpStatusCode { get; set; }
        [JsonPropertyName("httpStatus")]
        public string HttpStatus { get; set; }
        [JsonPropertyName("relativeUri")]
        public string RelativeUri { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
