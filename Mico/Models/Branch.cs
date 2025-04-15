using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mico.Models
{
    public class Branch
    {
        public int Id { get; set; }

        [DisplayName("Branş Adı")]
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
