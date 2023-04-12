using Microsoft.EntityFrameworkCore;

namespace CA2_backend.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }


		public DbSet<Songs> Songs { get; set; }
		public DbSet<Artist> Artists { get; set; }
	}
}
