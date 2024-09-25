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
    public class SubscribeManager : ISubsribeService
    {

        private readonly ISubsribeDal _subsribeDal;

        public SubscribeManager(ISubsribeDal subsribeDal)
        {
            _subsribeDal = subsribeDal;
        }

        public void TDelete(Subscribe t)
        {
            _subsribeDal.Delete(t);
        }

        public Subscribe TGetById(int id)
        {
           return _subsribeDal.GetById(id);
        }

        public List<Subscribe> TGetList()
        {
            return _subsribeDal.GetList();
        }

        public void TInsert(Subscribe t)
        {
            _subsribeDal.Insert(t);
                }

        public void TUpdate(Subscribe t)
        {
            _subsribeDal.Update(t);
        }
    }
}
