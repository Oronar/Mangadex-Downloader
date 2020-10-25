using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Mangadex.Api.Models
{
	public class Manga
	{
		public string Title { get; set; }

		public string Description { get; set; }

		[JsonProperty("cover_url")]
		public string CoverUrl { get; set; }

		[JsonProperty("alt_names")]
		public IEnumerable<string> AlternateTitles { get; set; }

		public string Artist { get; set; }

		public string Author { get; set; }

		public int Status { get; set; }

		public int Demographic { get; set; }

		public IEnumerable<int> Genres { get; set; }

		[JsonProperty("last_chapter")]
		public int LastChapter { get; set; }

		[JsonProperty("last_volume")]
		public int LastVolume { get; set; }

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_updated")]
		public DateTime UpdatedDate { get; set; }

		[JsonProperty("lang_name")]
		public string Language { get; set; }

		[JsonProperty("lang_flag")]
		public string LanguageFlag { get; set; }

		[JsonProperty("hentai")]
		public bool IsHentai { get; set; }

		public Dictionary<string, string> Links { get; set; }

		public IEnumerable<Relation> Related { get; set; }

		public Rating Rating { get; set; }

		public int Views { get; set; }

		public int Follows { get; set; }

		public int Comments { get; set; }

		public IEnumerable<string> Covers { get; set; }
	}
}