using BookWeb.Areas.Identity.Data;
using BookWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.Data
{
    /// <summary>
    /// Database context for project which inherits from DbContext class
    /// </summary>
    public class BookDbContext : IdentityDbContext<BookWebUser>
    {
        /// <summary>
        /// To ensure the connection between the project and database.
        /// </summary>
        /// <param name="options"></param>
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
