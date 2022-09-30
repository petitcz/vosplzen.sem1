using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vosplzen.sem1h4.Data;
using vosplzen.sem1h4.Data.Model.Generics;
using vosplzen.sem1h4.Services.IServices;

namespace vosplzen.sem1h4.Services
{
    public class MasterService : IMasterService
    {

        private ApplicationDbContext _context;
        private IUserService _userservice;

        public MasterService(ApplicationDbContext context, IUserService userservice)
        {
            _context = context;
            _userservice = userservice;
        }

        public int Count<T>() where T : Generic
        {
            var result = _context.Set<T>().Count();
            return result;
        }

        public void Add<T>(T item) where T : Generic
        {
            item.CreatedBy = _userservice.GetCurrentUsername();

            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }
        public void Update<T>(T item) where T : Generic
        {
            item.Modified = DateTime.Now;
            item.ModifiedBy = _userservice.GetCurrentUsername();

            _context.Set<T>().Update(item);
            _context.SaveChanges();
        }
        public void Delete<T>(int id) where T : Generic
        {
            var removal = _context.Set<T>().Where(x => x.Id == id).FirstOrDefault();
            _context.Set<T>().Remove(removal);
            _context.SaveChanges();

        }

        public T GetById<T>(int id) where T : Generic
        {
            var result = _context.Set<T>().Where(x => x.Id == id).FirstOrDefault();
            return result;
        }

        public List<T> GetAll<T>() where T : Generic
        {
            var result = _context.Set<T>().ToList();
            return result;
        }


    }
}
