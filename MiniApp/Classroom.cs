
namespace MiniApp
{
    public class Classroom
    {
        private static int nextId = 1;

        public int Id { get; }
        public string Name { get; }
        public ClassType Type { get; }
        public List<Student> Students { get; internal set; }

        private List<Student> students = new List<Student>();

        public Classroom(string name, ClassType type)
        {
            Id = nextId++;
            Name = name;
            Type = type;
        }

        public void AddStudent(Student student)
        {
            if (students.Count >= (Type == ClassType.Backend ? 20 : 15))
            {
                throw new InvalidOperationException("Classroom is full.");
            }
            students.Add(student);
        }

        public Student FindStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void DeleteStudent(int id)
        {
            var studentToRemove = students.FirstOrDefault(s => s.Id == id);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
            }
        }
    }
}
