using Mangadex.Api.Models.Chapters;
using Mangadex.Api.Models.Groups;
using Mangadex.Api.Models.Mangas;
using System.Collections.Generic;

namespace Mangadex.Api.Models
{
	public class Collection
	{
		public Manga Manga { get; set; }

		public IEnumerable<ChapterSummary> Chapters { get; set; }

		public IEnumerable<Group> Groups { get; set; }
	}
}