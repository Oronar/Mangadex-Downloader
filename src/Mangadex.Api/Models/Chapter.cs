using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Mangadex.Api.Models
{
	public class Chapter
	{
		public int Id { get; set; }

		public int? Volume { get; set; }

		[JsonProperty("chapter")]
		public int ChapterNumber { get; set; }

		public string Title { get; set; }

		[JsonProperty("lang_name")]
		public string LanguageName { get; set; }

		[JsonProperty("lang_code")]
		public string LanguageCode { get; set; }

		[JsonProperty("group_id")]
		public int GroupId { get; set; }

		[JsonProperty("group_name")]
		public string GroupName { get; set; }

		[JsonProperty("group_id_2")]
		public int? GroupId2 { get; set; }

		[JsonProperty("group_name_2")]
		public string GroupName2 { get; set; }

		[JsonProperty("group_id_3")]
		public int? GroupId3 { get; set; }

		[JsonProperty("group_name_3")]
		public string GroupName3 { get; set; }

		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Timestamp { get; set; }

		public int? Comments { get; set; }
	}
}