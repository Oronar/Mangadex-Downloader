using Newtonsoft.Json;

namespace Mangadex.Api.Models.Mangas
{
	public class Links
	{
		public string Al { get; set; }

		public string Ap { get; set; }

		public string Bw { get; set; }

		public string Kt { get; set; }

		[JsonProperty("mu")]
		public string MangaUpdates { get; set; }

		[JsonProperty("amz")]
		public string Amazon { get; set; }

		[JsonProperty("ebj")]
		public string EBookJapan { get; set; }

		[JsonProperty("mal")]
		public string MyAnimeList { get; set; }
	}
}