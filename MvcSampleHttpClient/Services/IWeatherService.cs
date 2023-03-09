namespace MvcSampleHttpClient.Services
{
	public interface IWeatherService
	{
		Task<WeatherInfo?> GetInfoAsync();
	}
}
