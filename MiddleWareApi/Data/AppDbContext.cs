using Microsoft.EntityFrameworkCore;

namespace MiddleWareApi.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base (options)
        {
            
        }
        public DbSet<MiddleWare> middleWares { get; set; }
    }
}
