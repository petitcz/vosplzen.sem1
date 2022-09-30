using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vosplzen.sem1h4.Data.DTO;
using vosplzen.sem1h4.Data.Model;

namespace vosplzen.sem1h4.Services.IServices
{
    public interface IStudentService
    {
        List<Student> GetAll();

        Student GetById(int id);
        StudentDTO GetDtoById(int id);
        void Update(StudentDTO item);

        void Delete(int id);

        int Count();

        void Add(Student item);

    }
}
