using Entidades;
namespace Services.Students
{
    public interface ISvStudent
    {
        //READS
        public List<Student> GetAllStudent();
        public Student GetStudentById(int id);

        //WRITES
        public Student AddStudent(Student student);
        public Student UpdateStudent(int id, Student student);
        public void DeleteStudent(int id);
    }
}
