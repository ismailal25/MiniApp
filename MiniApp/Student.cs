namespace MiniApp
{
    public class Student
    {
        private static int nextId = 1;

        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }

        public Student(string name, string surname)
        {
            Id = nextId++;
            Name = name;
            Surname = surname;
        }
    }
}
