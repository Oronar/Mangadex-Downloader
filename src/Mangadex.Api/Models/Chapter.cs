using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Mangadex.Api.Models
{
	public class Chapter
	{
		public int Id { get; set; }

		public int? Volume { get; set; }

		public int ChapterNumber { get; set; }

		public string Title { get; set; }

		public string LanguageName { get; set; }

		public string LanguageCode { get; set; }

		public int GroupId { get; set; }

		public string GroupName { get; set; }

		public int GroupId2 { get; set; }

		public string GroupName2 { get; set; }

		public int GroupId3 { get; set; }

		public string GroupName3 { get; set; }

		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Timestamp { get; set; }

		public int? Comments { get; set; }
	}
}