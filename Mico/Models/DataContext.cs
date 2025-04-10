using Mico.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mico.Models
{
    public class DataContext:IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }

        public DataContext()
        {
            
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

    }
}
