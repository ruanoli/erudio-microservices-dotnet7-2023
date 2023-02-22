using Microsoft.EntityFrameworkCore;

namespace GeekShpping.ProductAPI.Models.Context
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext()
        {

        }
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
