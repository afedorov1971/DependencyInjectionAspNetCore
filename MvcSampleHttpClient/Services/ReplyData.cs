namespace MvcSampleHttpClient.Services
{
	public class ReplyDataMainInfo
	{
		public double Temp { get; set; }
	}

	public class ReplyData
	{
		public string Name { get; set; } = null!;
		public ReplyDataMainInfo Main { get; set; } = null!;
	}
}
