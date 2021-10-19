namespace Tfl.Road.AppServices.Services
{
    public class OutputFormatter : IOutputFormatter
    {
        public string Format(RoadStatus status)
        {
            return @$"The status of the {status.DisplayName} is as follows\r\nRoad Status is {status.StatusSeverity}\r\nRoad Status Description is {status.StatusSeverityDescription}";
        }
    }
}
