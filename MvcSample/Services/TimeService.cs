namespace MvcSample.Services
{
	public class TimeService : ITimeService
	{
		public string GetTime() => DateTime.Now.ToString("HH:mm:ss");
	}
}
