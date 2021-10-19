namespace Tfl.Road.AppServices.Services
{
    public class OutputFormatter : IOutputFormatter
    {
        public string Format(RoadStatus status)
        {
            if (status.IsError)
            {
                return $"{status.DisplayName} is not a valid road";
            }

            return @$"The status of the {status.DisplayName} is as follows\r\nRoad Status is {status.StatusSeverity}\r\nRoad Status Description is {status.StatusSeverityDescription}";
        }
    }
}
