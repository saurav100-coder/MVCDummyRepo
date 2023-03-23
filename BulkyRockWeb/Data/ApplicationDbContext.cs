using BulkyRockWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyRockWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Cateogry> cateogries { get; set; }
    }
}
