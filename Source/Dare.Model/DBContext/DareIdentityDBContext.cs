using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dare.Model.DBContext
{
    public class DareIdentityDBContext : IdentityDbContext
    {
        public IConfiguration _configuration { get; }
        public DareIdentityDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return _configuration["ConnectionString:DareDB"];
        }
    }
}
