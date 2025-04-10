namespace Mico.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }

    }

    public class SocialMedia
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
