﻿

using Microsoft.AspNetCore.Identity;

namespace Mico.Models
{
    public class Doctor : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Branch { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }

        //public Doctor()
        //{
        //    SocialMedias = new List<SocialMedia>();
        //}
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
