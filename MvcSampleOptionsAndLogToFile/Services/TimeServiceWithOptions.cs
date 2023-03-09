using Microsoft.Extensions.Options;

namespace MvcSampleOptionsAndLogToFile.Services
{
	public class TimeServiceWithOptions : ITimeService
	{
		private readonly TimeOptions _options;

		public TimeServiceWithOptions(IOptions<TimeOptions> options)
		{
			_options = options.Value;
		}

		public string GetTime() => $"{_options.Greeting} {DateTime.Now.ToString(_options.Format)}";
		
	}
}
