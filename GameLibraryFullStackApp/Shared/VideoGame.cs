using System;
namespace GameLibraryFullStackApp.Shared
{
	public class VideoGame
	{
		public int Id { get; set; }
		public required string Title { get; set; }
		public string Publisher { get; set; } = string.Empty;
		public int ReleaseYear { get; set; }
	}
}

