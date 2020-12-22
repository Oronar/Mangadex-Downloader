namespace Mangadex.Api.Models
{
	public class Response<T>
	{
		public int Code { get; set; }

		public string Status { get; set; }

		public T Data { get; set; }
	}
}