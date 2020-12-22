namespace Mangadex.Api.Models.Mangas
{
	public class Relation
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public int Type { get; set; }

		public bool IsHentai { get; set; }
	}
}