using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mico.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPersient { get; set; }

    }      
}
