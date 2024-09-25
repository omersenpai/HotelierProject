using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class 
    { //veritabanı işlemleri
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList(); //Çeşitli türlerde verileri depolamak ve yönetmek için kullanılabilecek dinamik bir veri yapısı sağlar.
        T GetById(int id); // T tipinde nesne getirir.
    }
    
    }

