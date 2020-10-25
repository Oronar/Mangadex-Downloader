using Newtonsoft.Json;

namespace Mangadex.Api.Models
{
	public class Group
	{
		public int Id { get; set; }

		[JsonProperty("group_name")]
		public string GroupName { get; set; }
	}
}