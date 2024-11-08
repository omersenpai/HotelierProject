using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class StaffManager : IStaffService
    {

        private readonly IStaffDal _staffDal;//StaffManager sınıfı içindeki metotların veri erişim katmanı (Data Access Layer - DAL) ile iletişim kurmasını sağlar.

        public StaffManager(IStaffDal staffDal)//StaffManager sınıfı oluşturulduğunda dışarıdan bir IStaffDal türünde bir nesne (örneğin bir DAL sınıfının implementasyonu) alır.
        {
            _staffDal = staffDal;//Bu satır, constructor'da dışarıdan gelen staffDal parametresini sınıfın içindeki readonly değişkene atar.
        }

        public void TDelete(Staff t)
        {
            _staffDal.Delete(t);
        }

        public Staff TGetById(int id)
        {
           return _staffDal.GetById(id);
        }

        public List<Staff> TGetList()
        {
            return _staffDal.GetList();
        }

        public int TGetStaffCount()
        {
           return _staffDal.GetStaffCount();
        }

        public void TInsert(Staff t)
        {
           _staffDal.Insert(t);
        }

        public List<Staff> TLast4StaffList()
        {
           return _staffDal.Last4StaffList();
        }

        public void TUpdate(Staff t)
        {
           _staffDal.Update(t);
        }
    }
}
