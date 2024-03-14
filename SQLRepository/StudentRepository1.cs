using Common.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;

namespace SQLRepository
{
    
    public class StudentRepository1:IStudentRepository
    {
        

        private readonly IDbConnection _connection;
        public StudentRepository1(IDbConnection connection)
        {
                _connection = connection;
        }
        
        public async Task<List<Student>> GiveAllStudents()
        {
            List<Student> students = new List<Student>();   
            //opening the connection
            _connection.Open();
            //Give all columns
            string query = "select id,name,branch,section FROM students";
            SqlCommand command=new SqlCommand(query,(SqlConnection)_connection);
            using (SqlDataReader reader =await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                { 
                    Student student = new Student
                    {
                        id = Convert.ToInt32(reader["id"]),
                        name = Convert.ToString(reader["Name"]),
                        branch = Convert.ToString(reader["branch"]),
                        section = Convert.ToInt32(reader["section"])
                    };
                    students.Add(student);
                }
            }
            _connection.Close();
            return students;
            
        }
        //Getting Student by Id
        public async Task<Student> GiveMeStudentById(int id)
        {
            _connection.Open();

            Student s=new Student();
            string query = "select * FROM students where id=@id";
            SqlCommand command=new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            {
                if (await reader.ReadAsync())
                {
                    Student student = new Student
                    {
                        id = Convert.ToInt32(reader["id"]),
                        name = Convert.ToString(reader["Name"]),
                        branch = Convert.ToString(reader["branch"]),
                        section = Convert.ToInt32(reader["section"])
                    };
                    s = student;
                }
            }
            _connection.Close();
            return s;
            
            
        }
        //Inserting the studens
        public async void AddStudent(Student student)
        {
            _connection.Open();
            string query = "INSERT INTO students (id, name, branch, section) VALUES (@id, @name, @branch, @section)";
            SqlCommand command=new SqlCommand(query,(SqlConnection)_connection);
            command.Parameters.AddWithValue("@id", student.id);
            command.Parameters.AddWithValue("@name",student.name);
            command.Parameters.AddWithValue("@branch", student.branch);
            command.Parameters.AddWithValue("@section", student.section);
            using (command)
            {
                // Add parameters to the command

                try
                {
                    // Execute the query
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Student added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add student.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    _connection.Close();
                }
            }
            
        }

        //Updating the student
        public async void updateStudent(Student student)
        {
            _connection.Open();
            string query = "UPDATE students set name=@name,branch=@branch,section=@section where id=@id";
            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@id", student.id);
            command.Parameters.AddWithValue("@name", student.name);
            command.Parameters.AddWithValue("@branch", student.branch);
            command.Parameters.AddWithValue("@section", student.section);
            using (command)
            {
                try
                {
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Student updated successfully");
                    }
                    else { Console.WriteLine("Failed to add student"); }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("An error occured"+ex.Message);
                }
                finally
                {
                    // Close the connection
                    _connection.Close();
                }
            }
        }

        //deleting the student by id

        public async void deleteStudent(int id)
        {
            _connection.Open();
            string query = "DELETE students where id=@id";
            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@id", id);
            using(command)
            {
                try
                {
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Student deleted successfully");
                    }
                    else { Console.WriteLine("Failed to delete student"); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occured" + ex.Message);
                }
                finally
                {
                    // Close the connection
                    _connection.Close();
                }

            }

        }
    }
}
