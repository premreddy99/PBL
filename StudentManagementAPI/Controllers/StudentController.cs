using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementService;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public StudentController() { }
        /*[HttpGet]
        [Route("GetStudentsStartingWithA")]
        public ActionResult<Student[]> GetStudentsStartingWithA()
        {
            //IStudentService studentService = new StudentService();
            return _studentService.GetStudentsStartingWithA(0);
        }

        [HttpGet]
        [Route("GetStudentsContainsA")]
        public ActionResult<Student[]> GetStudentsContainsA()
        {
            //IStudentService studentService = new StudentService();
            return _studentService.GetStudentsContainsA(1);
        }*/
        [HttpGet]
        [Route("GiveMeAllStudents")]
        public async Task<ActionResult<List<Student>>> GetStudentNames()
        {
           // getAllStudents from database
            //filter the specific student and get the specific sudent

           // IStudentService studentService = new StudentService();
            return  await _studentService.GiveMeAllStudents();

        }
        
        [HttpGet]
        [Route("GiveStudentById/{id}")]
        public async Task<ActionResult<Student>> GetStudentNameById(int id)
        {
            // getAllStudents from database
            //filter the specific student and get the specific sudent

            // IStudentService studentService = new StudentService();
            return await _studentService.GiveMeStudentById(id);
        }
        [HttpPost]
        [Route("AddStudent")]
        public async void AddStudent(int id,string name,string branch,int section)
        {
            var student = new Student
            {
                id = id,
                name = name,
                branch = branch,
                section =section
            };
             _studentService.AddStudent(student);
           
        }

        [HttpGet]
        [Route("giveMeAStudent")]
        public string GiveStudent()
        {
            return "abc";
        }

        [HttpPut]
        [Route("UpdateStudentById/{id}")]
        public async void updateStudent(Student student)
        {
            _studentService.updateStudent(student);
        }

        [HttpDelete]
        [Route("DeleteStudentById/{id}")]
        public async void deleteStudent(int id)
        {
            _studentService.deleteStudent(id);
        }
    }
}
