using LMS.BooksRecordService.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.BooksRecordService.API.Persistance
{
    public class BooksDbContext(DbContextOptions<BooksDbContext> options) : DbContext(options)
    {
        private const string _IdSchema = "bk";

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(_IdSchema);
        }
    }
}
