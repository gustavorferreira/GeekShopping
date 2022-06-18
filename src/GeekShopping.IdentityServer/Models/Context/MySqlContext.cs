using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Models.Context
{
    public class MySqlContext : IdentityDbContext<ApplicationUser>
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
    }
}
