using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {  //IdentityDbContext, kimlik doğrulama ve yetkilendirme işlemleri için kullanıcı ve rol tabanlı tabloların veritabanında yönetilmesini sağlar.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-KM7D4VT;initial catalog=ApiDb;TrustServerCertificate=true;Integrated Security=true");
        }
        //Aşağıda tanımlanan DbSet özellikleri, Entity Framework ile veritabanında hangi tabloların yönetileceğini belirtir.

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }

        
       
    }
}
