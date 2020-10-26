using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PAPBackOffice.Data
{
    public class IdentityDatabaseContext : IdentityDbContext
    {
        public IdentityDatabaseContext(DbContextOptions<IdentityDatabaseContext> options)
            : base(options)
        {
        }
    }
}
