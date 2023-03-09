using Microsoft.Extensions.Options;

namespace MvcSampleHttpClient.Services
{
	public class WeatherService : IWeatherService
	{

		private readonly HttpClient _httpClient;
		private readonly ILogger<WeatherService> _logger;
		private readonly string _appId;
		private readonly int _cityId;


		public WeatherService(ILogger<WeatherService> logger, HttpClient httpClient, IOptions<WeatherServiceOptions> options)
		{
			_httpClient = httpClient;
			_logger = logger;
			_appId = options.Value.AppId;
			_cityId = options.Value.CityId;
		}
		
		public async Task<WeatherInfo?> GetInfoAsync()
		{
			var res = await _httpClient.GetAsync($"data/2.5/weather?id={_cityId}&lang=ru&units=metric&APPID={_appId}");
			if (!res.IsSuccessStatusCode)
			{
				_logger.LogError($"Ошибка обращения к сервису погоды ({res.StatusCode})");
				return null;
			}

			try
			{
				var data = await res.Content.ReadFromJsonAsync<ReplyData>();

				if (data == null)
				{
					_logger.LogError("Не удалось прочитать ответ от сервиса погоды");
					return null;
				}
				return new WeatherInfo {CityName = data.Name, TempCelsius = data.Main.Temp};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка обращения к сервису погоды");
				return null;
			}
		}
	}
}
