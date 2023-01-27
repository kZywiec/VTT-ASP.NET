using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VTT.Models.Context
{
    namespace FirstAspApp.Models
    {
        public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
        {
            public
           AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }
        }
    }
}
