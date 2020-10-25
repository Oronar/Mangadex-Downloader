using Mangadex.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Threading.Tasks;

namespace Mangadex.Api
{
	public class MangadexApi
	{
		public async Task<Manga> GetManga(int id)
		{
			ITraceWriter traceWriter = new MemoryTraceWriter();

			JsonSerializerSettings DefaultSettings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				DefaultValueHandling = DefaultValueHandling.Include,
				TypeNameHandling = TypeNameHandling.All,
				NullValueHandling = NullValueHandling.Ignore,
				Formatting = Formatting.None,
				ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
				TraceWriter = traceWriter
			};

			var client = new RestClient("http://mangadex.org/api/");
			client.UseNewtonsoftJson(DefaultSettings);
			var request = new RestRequest($"manga/{id}", DataFormat.Json);

			var response = await client.GetAsync<MangaResponse>(request).ConfigureAwait(true);
			Console.WriteLine(traceWriter);

			return response.Manga;
		}
	}
}