using Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Authors> Authors { get; set; }

        public DbSet<Books> Books { get; set; }
    }
}
