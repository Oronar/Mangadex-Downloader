using Mangadex.Api.Models;
using Mangadex.Api.Models.Chapters;
using Mangadex.Api.Models.Groups;
using Mangadex.Api.Models.Mangas;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Mangadex.Api
{
	public class MangadexApi
	{
		private readonly string MangadexApiUrl = "https://mangadex.org/";
		private readonly IRestClient RestClient;

		public MangadexApi()
		{
			RestClient = new RestClient(MangadexApiUrl);
			RestClient.UseNewtonsoftJson();
		}

		public async Task<Manga> GetManga(int id)
		{
			var request = new RestRequest($"api/v2/manga/{id}", DataFormat.Json);

			var response = await RestClient.GetAsync<Response<Manga>>(request)
				.ConfigureAwait(true);

			return response.Data;
		}

		public async Task<IEnumerable<ChapterSummary>> GetChapters(int mangaId)
		{
			var request = new RestRequest($"api/v2/manga/{mangaId}/chapters", DataFormat.Json);

			var response = await RestClient.GetAsync<Response<Collection>>(request)
				.ConfigureAwait(true);

			return response.Data.Chapters;
		}

		public async Task<Chapter> GetChapter(int id)
		{
			var request = new RestRequest($"api/v2/chapter/{id}", DataFormat.Json);

			var response = await RestClient.GetAsync<Response<Chapter>>(request)
				.ConfigureAwait(true);

			return response.Data;
		}

		public void GetPage(string server, string serverHash, string pageId, Stream stream)
		{
			var request = new RestRequest($"{server}{serverHash}/{pageId}");
			request.ResponseWriter = responseStream => responseStream.CopyTo(stream);

			RestClient.DownloadData(request);
		}

		public async Task<IEnumerable<Group>> GetGroups(int mangaId)
		{
			var request = new RestRequest($"api/v2/manga/{mangaId}/chapters");

			var response = await RestClient.GetAsync<Response<Collection>>(request)
				.ConfigureAwait(true);

			return response.Data.Groups;
		}
	}
}