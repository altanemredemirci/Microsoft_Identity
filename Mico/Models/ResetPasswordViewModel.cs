using System.ComponentModel.DataAnnotations;

namespace Mico.Models
{
    public class ResetPasswordViewModel
    {
        public string token { get; set; }
        public string userId { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
