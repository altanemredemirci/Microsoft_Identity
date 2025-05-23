﻿using Mico.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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

        //FLUENT API
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<Doctor>()
        //    .Property(p => p.Name)
        //    //.IsRequired(false) //Allow Null
        //    .HasColumnType("varchar(30)") //Database column data type
        //    .HasAnnotation("Display", "Doktor Adı"); //Name özelliği kullanıcıya görünür de 'Doktor Adı' olarak gösterilecek
        //    //.HasColumnOrder(2) //Name kolonunun tablodaki sırası         
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Branch>()
                .Property(b => b.Code)
                .HasAnnotation("DisplayName", "Kısa Kod");
        }


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

    }
}
