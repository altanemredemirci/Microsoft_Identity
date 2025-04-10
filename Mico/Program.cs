using Mico.Identity;
using Mico.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<DataContext>()
	.AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    //password
    options.Password.RequireDigit = true;  //rakam zorunlu
    options.Password.RequireLowercase = true; //küçük harf zorunlu
    options.Password.RequireUppercase = true; //büyük harf zorunlu
    options.Password.RequireNonAlphanumeric = true; //rakam ve alfabe dışında kalan özel karakter zorunlu
    options.Password.RequiredLength = 6; // min pass uzunluðu

    options.Lockout.MaxFailedAccessAttempts = 5; //Max hatali giris hakkı
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Max hatalý giriþ sonrasý account kilitlenme süresi
    options.Lockout.AllowedForNewUsers = true; //Her yeni account için uygula


    //user
    options.User.RequireUniqueEmail = true; //Account'un email adresi benzersiz
    //options.User.AllowedUserNameCharacters = "";

    options.SignIn.RequireConfirmedEmail = true; //Giriþ için Email onayý olmasý zorunlu
    options.SignIn.RequireConfirmedPhoneNumber = false; //Giriþ için Telefon numarasý onayý zorunlu deðil

});


//Configure Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //Oturum Süresi
    options.SlidingExpiration = true; // Her kullanýcý hareketinde oturum süresini resetle
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = "Mico.Security.Cookie",
        SameSite = SameSiteMode.Strict //Oturumu serverdan kullanýcý browserýna taþýdýk.
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//	name: "default",
//	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}");

app.Run();

/*
 * Doctor bir ApplicationUser olacak
 * Doctor kayıt alanı için bir model oluşturunuz. Model de kayıt için kullanılacak propertyler olsun
 * Kayıt formuna model gitsin ve model post edilsin
 * Email Confirm gerek yok.
 * Doktorları Listeleyen bir Index() action olsun

 */