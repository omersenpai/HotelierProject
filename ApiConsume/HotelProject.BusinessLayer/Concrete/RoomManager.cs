using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class RoomManager : IRoomService
    {
        //veri erişim katmanından gelen verilere iş kuralları uygular ve bu verilerin hangi koşullarda işlenmesi gerektiğini belirler.
        // Örneğin, bir oda eklenmeden önce bazı kontroller yapılabilir (boşluk kontrolü, fiyat kontrolü gibi).mantıksal işlemleri yönetir.
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }
       

        public void TDelete(Room t)
        {
            _roomDal.Delete(t);
        }

        public Room TGetById(int id)
        {
          return _roomDal.GetById(id);
        }

        public List<Room> TGetList()
        {
            return _roomDal.GetList();
        }

        public int TGetRoomCount()
        {
            return _roomDal.GetRoomCount();
        }

        public void TInsert(Room t)
        {
           _roomDal.Insert(t);
        }

        public void TUpdate(Room t)
        {
            _roomDal.Update(t);
        }
    }
}
