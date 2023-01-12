using DSortAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DSortAPI.Data
	{
	public class DataContext : DbContext
		{

		public DataContext(DbContextOptions<DataContext> options) : base(options) {}

		public DbSet<Document> Documents { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<Scan> Scans { get; set; }

		}
	}
