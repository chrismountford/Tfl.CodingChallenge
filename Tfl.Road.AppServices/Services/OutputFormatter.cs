namespace Tfl.Road.AppServices.Services
{
    public class OutputFormatter : IOutputFormatter
    {
        public Output Format(RoadStatus status)
        {
            Output output;
            if (status.IsError)
            {
                return new Output
                {
                    ExitCode = 1,
                    OutputText = $"{status.DisplayName} is not a valid road"
                };
            }

            return new Output
            {
                ExitCode = 0,
                OutputText = @$"The status of the {status.DisplayName} is as follows
Road Status is {status.StatusSeverity}
Road Status Description is {status.StatusSeverityDescription}"
            };
        }
    }
}
