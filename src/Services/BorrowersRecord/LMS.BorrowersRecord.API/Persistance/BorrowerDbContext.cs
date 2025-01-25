using LMS.BorrowersRecord.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.BorrowersRecord.API.Persistance {
	public class BorrowerDbContext(DbContextOptions<BorrowerDbContext> options) : DbContext(options)
	{
		private const string borrowerSchema = "br";

		public DbSet<Borrower> Borrowers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema(borrowerSchema);//Install-Package Microsoft.EntityFrameworkCore.Relational
		}
	}
}
	