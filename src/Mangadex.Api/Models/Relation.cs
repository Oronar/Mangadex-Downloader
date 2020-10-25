using Newtonsoft.Json;

namespace Mangadex.Api.Models
{
	public class Relation
	{
		[JsonProperty("relation_id")]
		public int RelationId { get; set; }

		[JsonProperty("related_manga_id")]
		public int Id { get; set; }

		[JsonProperty("manga_name")]
		public string Name { get; set; }

		[JsonProperty("manga_hentai")]
		public bool IsHentai { get; set; }
	}
}
