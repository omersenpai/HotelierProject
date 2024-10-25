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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//bu metodu override ediyorsanız, modelin nasıl yapılandırılacağını özelleştirebilirsiniz.Çakışma olmasın diye eklendi.
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>().ToTable(tb => tb.HasTrigger("Roomdecrease")).ToTable(tb => tb.HasTrigger("Roomincrease"));
            modelBuilder.Entity<Staff>().ToTable(tb => tb.HasTrigger("Staffdecrease")).ToTable(tb => tb.HasTrigger("Staffincrease"));
            modelBuilder.Entity<Guest>().ToTable(tb => tb.HasTrigger("Guestdecrease")).ToTable(tb => tb.HasTrigger("Guestincrease"));

        }



        //Aşağıda tanımlanan DbSet özellikleri, Entity Framework ile veritabanında hangi tabloların yönetileceğini belirtir.

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        
       
    }
}
