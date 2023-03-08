namespace TransientService.Services
{
	public class TimeService : ITimeService
	{
		private readonly string _time;
		public TimeService()
		{
			_time = DateTime.Now.ToString("HH:mm:ss");
		}

		public string GetTime() => _time;
	}
}
