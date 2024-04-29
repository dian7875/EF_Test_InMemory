
using Entidades;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;

namespace Services.Students
{
    public class SvStudent : ISvStudent
    {
        private MyContext _myDbContext = default!;
        public SvStudent()
        {
            _myDbContext = new MyContext();
        }

        #region Reads
        public List<Student> GetAllStudent()
        {
            return _myDbContext.Students.ToList();
        }

        #endregion

        #region Writes
        public Student AddStudent(Student student)
        {

            _myDbContext.Students.Add(student);
            _myDbContext.SaveChanges();

            return student;
        }
       

        #endregion

        #region Utils
        public void ShowAll()
        {
            List<Student> student = GetAllStudent();
            foreach (var item in student)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.LastName);
                Console.WriteLine("-----------------");
            }
        }

        public Student GetStudentById(int id)
        {

            return _myDbContext.Students.SingleOrDefault(x => x.Id == id);


        }

        public Student UpdateStudent(int id, Student newStudent)
        {
            Student updateStudent = _myDbContext.Students.Find(id);
            if (updateStudent != null)
            {


                updateStudent.Name = newStudent.Name;
                updateStudent.LastName = newStudent.LastName;

                   _myDbContext.Students.Update(updateStudent);
                _myDbContext.SaveChanges();
            }
            return updateStudent;
        }

        public void DeleteStudent(int id)
        {
            Student deleteStudent = _myDbContext.Students.Find(id);
            if (deleteStudent is not null) {
            
                _myDbContext.Students.Remove(deleteStudent);
                _myDbContext.SaveChanges();
            
            }

        }
        #endregion

    }
}
