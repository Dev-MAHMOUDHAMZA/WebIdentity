using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebIdentity.Models
{
    public class AppliactionDbContext :IdentityDbContext<AppliactionUser>
    {
        public AppliactionDbContext(DbContextOptions<AppliactionDbContext> options):base(options)
        {
                
        }
    }
}
