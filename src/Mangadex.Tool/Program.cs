using Mangadex.Api;
using System;
using System.Threading.Tasks;

namespace Mangadex.Tool
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			var mangadex = new MangadexApi();
			var manga = await mangadex.GetManga(3484);

			Console.WriteLine(manga.Title);
			Console.WriteLine(manga.Description);
		}
	}
}
