using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Mico.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }

        public override string UserName { get ; set; }
    }
}
