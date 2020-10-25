using Mangadex.Api.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mangadex.Api.Models
{
	public class MangaResponse
	{
		[JsonProperty("manga")]
		public Manga Manga { get; set; }

		[JsonConverter(typeof(ChaptersConverter))]
		[JsonProperty("chapter")]
		public IEnumerable<Chapter> Chapters { get; set; }

		[JsonConverter(typeof(GroupsConverter))]
		[JsonProperty("group")]
		public IEnumerable<Group> Groups { get; set; }

		public string Status { get; set; }
	}
}