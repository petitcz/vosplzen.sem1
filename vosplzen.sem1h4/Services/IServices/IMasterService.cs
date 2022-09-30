using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vosplzen.sem1h4.Data.Model.Generics;

namespace vosplzen.sem1h4.Services.IServices
{
    public interface IMasterService
    {
        List<T> GetAll<T>() where T : Generic;

        T GetById<T>(int id) where T: Generic;

        void Update<T>(T item) where T: Generic;

        void Delete<T>(int id) where T : Generic;

        int Count<T>() where T: Generic;

        void Add<T>(T item) where T : Generic;
    }
}
