using Microsoft.EntityFrameworkCore;
using SchoolService.Models;

namespace SchoolService.Data
{
    public class AppDbContext  : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Shkola> Shkolas { get; set; }
    }
}