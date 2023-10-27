using System;
using GameLibraryFullStackApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace GameLibraryFullStackApp.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext()
		{

		}
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<VideoGame> VideoGames { get; set; }
	}
}

