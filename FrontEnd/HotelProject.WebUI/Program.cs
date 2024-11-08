using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
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

builder.Services.AddMvc(config =>
{
var policy=new AuthorizationPolicyBuilder() //bir yetkilendirme politikası oluşturuluyor.
    .RequireAuthenticatedUser() //tüm MVC veya Razor sayfalarının yalnızca kimliği doğrulanmış kullanıcılara erişim izni vermesini sağlar.
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));//satırıyla oluşturulan politika, uygulamanın tüm sayfalarına otomatik olarak uygulanır. Böylece, kimliği doğrulanmamış kullanıcılar giriş yapmadan herhangi bir sayfaya erişemez.
}

);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;//cerezlerin yalnızca sunucu tarafından okunabileceğini ve istemcide (tarayıcı tarafında) JavaScript ile erişilemeyeceğini belirler, bu da güvenliği artırır.
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);// Kullanıcı 10 dakika boyunca etkin olmazsa çerez süresi dolar ve tekrar giriş yapması gerekir.
    options.LoginPath = "/Login/Index";// kimliği doğrulanmamış bir kullanıcı korumalı bir sayfaya erişmeye çalıştığında yönlendirileceği giriş sayfası (login page) tanımlanır.
});


var app = builder.Build();

// Hata ayıklama durumu
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}





app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
