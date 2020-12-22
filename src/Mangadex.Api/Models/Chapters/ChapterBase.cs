using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Mangadex.Api.Models.Chapters
{
	public class ChapterBase
	{
		public int Id { get; set; }

		public string Hash { get; set; }

		public int MangaId { get; set; }

		public string MangaTitle { get; set; }

		public string Volume { get; set; }

		[JsonProperty("chapter")]
		public string ChapterNumber { get; set; }

		public string Title { get; set; }

		public string Language { get; set; }

		[JsonProperty("uploader")]
		public int UploaderId { get; set; }

		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Timestamp { get; set; }

		public int Comments { get; set; }

		public int Views { get; set; }
	}
}