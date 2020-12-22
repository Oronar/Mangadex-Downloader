using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Mangadex.Api.Models.Mangas
{
	public class Manga
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		[JsonProperty("cover_url")]
		public string CoverPath { get; set; }

		[JsonProperty("altTitles")]
		public IEnumerable<string> AlternateTitles { get; set; }

		[JsonProperty("artist")]
		public IEnumerable<string> Artists { get; set; }

		[JsonProperty("author")]
		public IEnumerable<string> Authors { get; set; }

		public Publication Publication { get; set; }

		public IEnumerable<int> Tags { get; set; }

		public int LastChapter { get; set; }

		public int LastVolume { get; set; }

		public bool IsHentai { get; set; }

		public Links Links { get; set; }

		public IEnumerable<Relation> Relations { get; set; }

		public Rating Rating { get; set; }

		public int Views { get; set; }

		public int Follows { get; set; }

		public int Comments { get; set; }

		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("lastUploaded")]
		public DateTime LastUploadedDate { get; set; }

		[JsonProperty("mainCover")]
		public string Cover { get; set; }
	}
}