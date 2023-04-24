using Microsoft.EntityFrameworkCore;

namespace CA2_backend.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }


		public DbSet<Songs> Songs { get; set; }
		public DbSet<Artist> Artists { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Songs>()
				.Property(s => s.id).HasColumnName("id");

			modelBuilder.Entity<Songs>()
				.Property(s => s.songName).HasColumnName("name");

			modelBuilder.Entity<Songs>()
				.Property(s => s.artistName).HasColumnName("artistName");

			modelBuilder.Entity<Songs>()
				.Property(s => s.albumName).HasColumnName("albumName");

			modelBuilder.Entity<Artist>()
				.Property(a => a.id).HasColumnName("id");

			modelBuilder.Entity<Artist>()
				.Property(a => a.artistName).HasColumnName("artistName");

			modelBuilder.Entity<Artist>()
				.Property(a => a.genre).HasColumnName("genre");

			modelBuilder.Entity<Songs>()
				.ToTable("songs");

			modelBuilder.Entity<Artist>()
				.ToTable("artists");

			// Hardcoding data to the DB
			modelBuilder.Entity<Songs>().HasData(
				new Songs
				{
					id = 1,
					songName = "Law Of Attraction",
					artistName = "Dave",
					albumName = "We're All Alone In This Together"
				},
				new Songs
				{
					id = 2,
					songName = "Ferrari Horses",
					artistName = "D Block Europe",
					albumName = "The Blue Print - Us Vs. Them"
				},
				new Songs
				{
					id = 3,
					songName = "One More Time",
					artistName = "Daft Punk",
					albumName = "Discovery"
				}
			);

			modelBuilder.Entity<Artist>().HasData(
				new Artist
				{
					id = 1,
					artistName = "Dave",
					genre = "Pop"
				},
				new Artist
				{
					id = 2,
					artistName = "D Block Europe",
					genre = "Rap"
				},
				new Artist
				{
					id = 3,
					artistName = "Daft Punk",
					genre = "Dance"
				}
			);
		}
	}
}
