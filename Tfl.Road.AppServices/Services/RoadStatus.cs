namespace Tfl.Road.AppServices.Services
{
    public class RoadStatus
    {
        public string DisplayName { get; set; }
        public string StatusSeverity { get; set; }
        public string StatusSeverityDescription { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
    }
}