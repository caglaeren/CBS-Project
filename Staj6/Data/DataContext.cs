using Microsoft.EntityFrameworkCore;
namespace Staj6.Data
{
    public class DataContext: DbContext
    {
        
            public DataContext(DbContextOptions<DataContext> options) : base(options) { }
            public DbSet<Locationn> locationnss { get; set; }

        }
    }


