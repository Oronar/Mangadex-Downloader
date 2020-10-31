using Mangadex.Api;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mangadex.Tool
{
	public static class CbzDownloader
	{
		public async static Task Download(int mangaId, int volume, int chapter, string language, string group)
		{
			try
			{
				var mangadex = new MangadexApi();
				var manga = await mangadex.GetManga(mangaId);

				Console.WriteLine($"Manga: {manga.Manga.Title}");
				Console.WriteLine($"Volume: {volume}");
				Console.WriteLine($"Chapter: {chapter}");
				Console.WriteLine($"Language: {language}");
				Console.WriteLine($"Group: {(group == null ? "Any" : group)}");

				var chapterId = manga.Chapters.First(c => c.Volume == volume
					&& c.ChapterNumber == chapter
					&& c.LanguageName.Equals(language, StringComparison.OrdinalIgnoreCase)
					&& (group == null || group.Equals(c.GroupName, StringComparison.OrdinalIgnoreCase))).Id;

				var chapterDetail = await mangadex.GetChapter(chapterId);

				var path = @$"{manga.Manga.Title}/{manga.Manga.Title} - Chapter {chapter}.cbz";
				Directory.CreateDirectory(Path.GetDirectoryName(path));

				using var cbzFile = new FileStream(path, FileMode.Create);
				using var archive = new ZipArchive(cbzFile, ZipArchiveMode.Update);
				foreach (var page in chapterDetail.Pages)
				{
					var pageFile = archive.CreateEntry(page);
					using (var writer = pageFile.Open())
					{
						Console.WriteLine($"Downloading {page}...");
						mangadex.GetPage(chapterDetail.ServerUri.ToString(), chapterDetail.Hash, page, writer);
					}
					Thread.Sleep(1000);
				}
				Console.WriteLine($"Download complete: {path}");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}