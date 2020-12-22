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
		public async static Task Download(int mangaId, string volume, string chapter, string language, string group)
		{
			try
			{
				var mangadex = new MangadexApi();
				var manga = await mangadex.GetManga(mangaId);
				var chapters = await mangadex.GetChapters(mangaId);
				var groups = await mangadex.GetGroups(mangaId);

				Console.WriteLine($"Manga: {manga.Title}");
				Console.WriteLine($"Volume: {volume}");
				Console.WriteLine($"Chapter: {chapter}");
				Console.WriteLine($"Language: {language}");
				Console.WriteLine($"Group: {(group == null ? "Any" : group)}");

				var chapterId = chapters.First(c => (string.IsNullOrEmpty(c.Volume) || c.Volume.Equals(volume, StringComparison.OrdinalIgnoreCase))
					&& c.ChapterNumber.Equals(chapter, StringComparison.OrdinalIgnoreCase)
					&& c.Language.Equals(language, StringComparison.OrdinalIgnoreCase)
					&& (string.IsNullOrEmpty(group) || c.Groups.Any(groupId => groupId == groups.First(g => g.Name.Equals(group, StringComparison.OrdinalIgnoreCase)).Id))).Id;

				var chapterDetail = await mangadex.GetChapter(chapterId);

				var path = @$"{manga.Title}/[{chapterDetail.Groups.First().Name}] {manga.Title} - Chapter {chapter}.cbz";
				Directory.CreateDirectory(Path.GetDirectoryName(path));

				using var cbzFile = new FileStream(path, FileMode.Create);
				using var archive = new ZipArchive(cbzFile, ZipArchiveMode.Update);
				foreach (var page in chapterDetail.Pages)
				{
					var pageFile = archive.CreateEntry(page);
					using (var writer = pageFile.Open())
					{
						Console.WriteLine($"Downloading {page}...");
						mangadex.GetPage(chapterDetail.Server, chapterDetail.Hash, page, writer);
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