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

            return @$"The status of the {status.DisplayName} is as follows
Road Status is {status.StatusSeverity}
Road Status Description is {status.StatusSeverityDescription}";
        }
    }
}
