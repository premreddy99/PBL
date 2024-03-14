using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using SQLRepository;

namespace StudentManagementService
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        //private readonly IStudentRepository2 _studentRepository2;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
           // _studentRepository2 = studentRepository2;
        }

        public List<Student> s;
        //s = _studentRepository.GiveAllStudents();
        
        public async Task<List<Student>> GiveMeAllStudents()
        {
            
                
           
            // getAllStudents from database
            //filter the specific student and get the specific sudent

            return await _studentRepository.GiveAllStudents();
        }
        public async Task<Student> GiveMeStudentById(int id)
        {



            // getAllStudents from database
            //filter the specific student and get the specific sudent

            return await _studentRepository.GiveMeStudentById(id);
        }
        public void AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }
        public void updateStudent(Student student)
        {
            _studentRepository.updateStudent(student);
        }

        public void deleteStudent(int id)
        {
            _studentRepository.deleteStudent(id);
        }
    }
}
