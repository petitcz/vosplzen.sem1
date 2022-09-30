using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vosplzen.sem1h4.Data;
using vosplzen.sem1h4.Data.DTO;
using vosplzen.sem1h4.Data.Model;
using vosplzen.sem1h4.Services.IServices;

namespace vosplzen.sem1h4.Services
{
    public class StudentService : IStudentService
    {

        private ApplicationDbContext _context;
        private IUserService _userservice;

        public StudentService(ApplicationDbContext context, IUserService userservice)
        {
            _context = context;
            _userservice = userservice;
        }

        [Obsolete]
        public void Add(Student item)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            var result = _context.Users.Count();
            return result;
        }

        public void Delete(int id)
        {
            var userToDisable = GetById(id);
            userToDisable.IsActive = false;
            _context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            List<Student> list = _context.Users.Where(x => x.IsActive).ToList();
            return list;
        }

        public Student GetById(int id)
        {
            var user = _context.Users.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            return user;
        }

        private void Update(Student item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        public void Update(StudentDTO item)
        {
            var student = GetById(item.Id);
            student.Class = item.Class;
            student.FirstName = item.FirstName;
            student.LastName = item.LastName;
            student.Modified = DateTime.Now;
            Update(student);
        }

        public StudentDTO GetDtoById(int id)
        {
            var student = GetById(id);
            var studentDto = new StudentDTO()
            { Id = student.Id, FirstName = student.FirstName, LastName = student.LastName, Class = student.Class, UserName = student.UserName };
            return studentDto;
        }
    }
}
