using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

// FluentValidation modern kullanım
builder.Services.AddFluentValidationAutoValidation(); // Otomatik sunucu tarafı doğrulama
builder.Services.AddFluentValidationClientsideAdapters(); // İstemci tarafı doğrulama için

// Tüm doğrulayıcıları assembly'den otomatik yüklenir
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Spesifik doğrulayıcıları manuel olarak eklenir (isteğe bağlı)
builder.Services.AddTransient<IValidator<CreateGuestDto>, CreateGuestValidator>();
builder.Services.AddTransient<IValidator<UpdateGuestDto>, UpdateGuestValidator>();

// MVC için gerekli yapılandırma (FluentValidation artık buraya eklenmiyor)
builder.Services.AddControllersWithViews();

// Diğer servisler
builder.Services.AddHttpClient("OtelApiClient");
builder.Services.AddAutoMapper(typeof(Program)); // *

var app = builder.Build();

// Hata ayıklama durumu
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
