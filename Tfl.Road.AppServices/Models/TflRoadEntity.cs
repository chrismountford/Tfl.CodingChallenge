using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json.Serialization;

namespace Tfl.Road.AppServices.Models
{
    public class TflRoadEntity
    {
        [JsonPropertyName("$type")]
        public string Type { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
        [JsonPropertyName("statusSeverity")]
        public string StatusSeverity { get; set; }
        [JsonPropertyName("statusSeverityDescription")]
        public string StatusSeverityDescription { get; set; }
        [JsonPropertyName("bounds")]
        public string Bounds { get; set; }  // TODO Make these list of Coordinates
        [JsonPropertyName("envelope")]
        public string Envelope { get; set; }  // TODO Make these list of Coordinates
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
