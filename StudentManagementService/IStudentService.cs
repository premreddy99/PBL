using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementService
{
    public interface IStudentService
    {
        public Task<List<Student>> GiveMeAllStudents();
        public Task<Student> GiveMeStudentById(int id);
        public void AddStudent(Student student);

        public void updateStudent(Student student);
        public void deleteStudent(int id);
        //public List<Student> GetStudentsStartingWithA();
        //public List<Student> GetStudentsContainsA();
    }
}
