using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mico.Models
{
    public class RegisterViewModel
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage ="Ad boş geçilemez")]
        public string Name { get; set; }

        [DisplayName("Soyad")]
        public string Surname { get; set; }

        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        public string Password{ get; set; }

        [DisplayName("Tekrar Şifre")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RePassword{ get; set; }
    }
}
