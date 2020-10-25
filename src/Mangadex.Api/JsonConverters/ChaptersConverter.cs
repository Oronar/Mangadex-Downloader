using Mangadex.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Mangadex.Api.JsonConverters
{
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
}