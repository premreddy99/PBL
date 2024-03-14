using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLRepository { 
public  interface IStudentRepository
    {
        public Task<List<Student>> GiveAllStudents();
        public Task<Student> GiveMeStudentById(int id);
        public void AddStudent(Student student);
        public void updateStudent(Student student);
        public void deleteStudent(int id);
    }
/*    public interface IStudentRepository2
    {
        public string[] GiveAllStudents();
    }*/
}
