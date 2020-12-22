using System.Collections.Generic;

namespace Mangadex.Api.Models.Chapters
{
	public class ChapterSummary : ChapterBase
	{
		public IEnumerable<int> Groups { get; set; }
	}
}