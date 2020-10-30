using Mangadex.Api.Models;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Threading.Tasks;

namespace Mangadex.Api
{
	public class MangadexApi
	{
		private readonly string MangadexUrl = "http://mangadex.org/api/";

		public async Task<MangaResponse> GetManga(int id)
		{
			var client = new RestClient(MangadexUrl);
			client.UseNewtonsoftJson();

			var request = new RestRequest($"manga/{id}", DataFormat.Json);

			var response = await client.GetAsync<MangaResponse>(request).ConfigureAwait(true);

			return response;
		}
	}
}