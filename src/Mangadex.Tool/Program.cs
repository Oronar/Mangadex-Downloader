using Mangadex.Api;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Mangadex.Tool
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			var mangadex = new MangadexApi();
			var manga = await mangadex.GetManga(3484);

			Console.WriteLine(manga.Manga.Title);
			Console.WriteLine(manga.Manga.Description);

			var chapterDetail = await mangadex.GetChapter(manga.Chapters.First().Id);

			using var zipToOpen = new FileStream(@"test.cbz", FileMode.Create);
			using var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update);
			var pageFile = archive.CreateEntry(chapterDetail.Pages.First());
			using var writer = pageFile.Open();
			mangadex.GetPage(chapterDetail.Hash, chapterDetail.Pages.First(), writer);
		}
	}
}