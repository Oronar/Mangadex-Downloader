using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

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

	public class Group
	{
		public int Id { get; set; }

		[JsonProperty("group_name")]
		public string GroupName { get; set; }
	}

	public class ChaptersConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(IEnumerable<Chapter>);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var chaptersObject = JObject.Load(reader);
			var chapters = new List<Chapter>();

			foreach (var dataItem in chaptersObject)
			{
				var chapter = JsonConvert.DeserializeObject<Chapter>(dataItem.Value.ToString());
				chapter.Id = int.Parse(dataItem.Key);
				chapters.Add(chapter);
			}

			return chapters;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}


	}

	public class GroupsConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(IEnumerable<Group>);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var chaptersObject = JObject.Load(reader);
			var groups = new List<Group>();

			foreach (var dataItem in chaptersObject)
			{
				var group = JsonConvert.DeserializeObject<Group>(dataItem.Value.ToString());
				group.Id = int.Parse(dataItem.Key);
				groups.Add(group);
			}

			return groups;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}


	}
}
