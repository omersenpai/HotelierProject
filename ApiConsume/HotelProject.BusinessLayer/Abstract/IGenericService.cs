using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IGenericService<T>where T : class
    { // İş mantığı ve kuralların uygulandığı yerdir. 

        //DataAccess deki isimden ayırabilmek adına başına T ekledik.
        void TInsert(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList(); //Çeşitli türlerde verileri depolamak ve yönetmek için kullanılabilecek dinamik bir veri yapısı sağlar.
        T TGetById(int id);
    }
}
