using Mangadex.Api.Models.Groups;
using System.Collections.Generic;

namespace Mangadex.Api.Models.Chapters
{
	public class Chapter : ChapterBase
	{
		public IEnumerable<Group> Groups { get; set; }

		public string Status { get; set; }

		public IEnumerable<string> Pages { get; set; }

		public string Server { get; set; }
	}
}