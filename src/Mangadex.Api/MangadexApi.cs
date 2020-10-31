using Mangadex.Api.Models;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.IO;
using System.Threading.Tasks;

namespace Mangadex.Api
{
	public class MangadexApi
	{
		private readonly string MangadexApiUrl = "https://mangadex.org/";

		public async Task<MangaResponse> GetManga(int id)
		{
			var client = new RestClient(MangadexApiUrl);
			client.UseNewtonsoftJson();

			var request = new RestRequest($"api/manga/{id}", DataFormat.Json);

			var response = await client.GetAsync<MangaResponse>(request).ConfigureAwait(true);

			return response;
		}

		public async Task<ChapterDetail> GetChapter(int id)
		{
			var client = new RestClient(MangadexApiUrl);
			client.ThrowOnAnyError = true;
			client.UseNewtonsoftJson();

			var request = new RestRequest($"api/chapter/{id}", DataFormat.Json);

			var response = await client.GetAsync<ChapterDetail>(request).ConfigureAwait(true);

			return response;
		}

		public void GetPage(string server, string serverHash, string pageId, Stream stream)
		{
			var client = new RestClient(MangadexApiUrl);

			var request = new RestRequest($"{server}{serverHash}/{pageId}");
			request.ResponseWriter = responseStream => responseStream.CopyTo(stream);

			client.DownloadData(request);
		}
	}
}