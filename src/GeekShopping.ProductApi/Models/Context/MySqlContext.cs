using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext() { }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
    }
}
