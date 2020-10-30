using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mangadex.Api.Models
{
	public class ChapterDetail : Chapter
	{
		public string Hash { get; set; }

		[JsonProperty("manga_id")]
		public int MangaId { get; set; }

		[JsonProperty("server")]
		public Uri ServerUri { get; set; }

		[JsonProperty("long_strip")]
		public bool IsLongStrip { get; set; }

		[JsonProperty("page_array")]
		public IEnumerable<string> Pages { get; set; }
	}
}