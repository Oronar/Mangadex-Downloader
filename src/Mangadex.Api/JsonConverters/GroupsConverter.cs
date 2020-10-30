using Mangadex.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Mangadex.Api.JsonConverters
{
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