using System.ComponentModel.DataAnnotations;

namespace Tfl.Road.AppServices.Models
{
    public class RoadModel
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string StatusSeverity { get; set; }
        public string Bounds { get; set; }  // TODO Make these list of Coordinates
        public string Envelope { get; set; }  // TODO Make these list of Coordinates
        public string Url { get; set; }
    }
}
