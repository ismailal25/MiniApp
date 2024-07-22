namespace MiniApp
{
    class Program
    {
        private static List<Classroom> classrooms = new List<Classroom>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create Classroom");
                Console.WriteLine("2. Create Student");
                Console.WriteLine("3. List All Students");
                Console.WriteLine("4. List Students in a Classroom");
                Console.WriteLine("5. Delete Student");

                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateClassroom();
                        break;
                    case "2":
                        CreateStudent();
                        break;
                    case "3":
                        ListAllStudents();
                        break;
                    case "4":
                        ListStudentsInClassroom();
                        break;
                    case "5":
                        DeleteStudent();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                        break;
                }
            }
        }

        static void CreateClassroom()
        {
            Console.Write("Enter classroom name: ");
            string name = Console.ReadLine().Trim();

            if (!name.IsValidClassName())
            {
                Console.WriteLine("Invalid classroom name format. It should be 2 uppercase letters followed by 1 digit.");
                return;
            }

            ClassType type;
            Console.WriteLine("Select classroom type:");
            Console.WriteLine("1. Backend");
            Console.WriteLine("2. Frontend");
            Console.Write("Enter your choice (1-2): ");
            string typeChoice = Console.ReadLine();

            if (typeChoice == "1")
            {
                type = ClassType.Backend;
            }
            else if (typeChoice == "2")
            {
                type = ClassType.Frontend;
            }
            else
            {
                Console.WriteLine("Invalid choice. Defaulting to Backend.");
                type = ClassType.Backend;
            }

            try
            {
                classrooms.Add(new Classroom(name, type));
                Console.WriteLine("Classroom created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating classroom: {ex.Message}");
            }
        }

        static void CreateStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine().Trim();

            if (!name.IsValidName())
            {
                Console.WriteLine("Invalid name format. It should start with an uppercase letter, not contain spaces, and be at least 3 characters long.");
                return;
            }

            Console.Write("Enter student surname: ");
            string surname = Console.ReadLine().Trim();

            if (!surname.IsValidSurname())
            {
                Console.WriteLine("Invalid surname format. It should start with an uppercase letter, not contain spaces, and be at least 3 characters long.");
                return;
            }

            Console.Write("Enter classroom ID to add the student: ");
            if (!int.TryParse(Console.ReadLine(), out int classroomId))
            {
                Console.WriteLine("Invalid input for classroom ID.");
                return;
            }

            var classroom = classrooms.FirstOrDefault(c => c.Id == classroomId);
            if (classroom == null)
            {
                Console.WriteLine("Classroom not found.");
                return;
            }

            try
            {
                var student = new Student(name, surname);
                classroom.AddStudent(student);
                Console.WriteLine("Student added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
            }
        }

        static void ListAllStudents()
        {
            foreach (var classroom in classrooms)
            {
                foreach (var student in classroom.Students)

                {
                    if (student != null)
                    {
                        throw new Exception("student yoxdur");
                    }
                    else
                    {
                    Console.WriteLine($"Classroom: {classroom.Name}, Student: {student.Name} {student.Surname}");

                    }
                }
            }
        }

        static void ListStudentsInClassroom()
        {
            Console.Write("Enter classroom ID to list students: ");
            if (!int.TryParse(Console.ReadLine(), out int classroomId))
            {
                Console.WriteLine("Invalid input for classroom ID.");
                return;
            }

            var classroom = classrooms.FirstOrDefault(c => c.Id == classroomId);
            if (classroom == null)
            {
                Console.WriteLine("Classroom not found.");
                return;
            }

            foreach (var student in classroom.Students)
            {
                Console.WriteLine($"Classroom: {classroom.Name}, Student: {student.Name} {student.Surname}");
            }
        }

        static void DeleteStudent()
        {
            Console.Write("Enter student ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Invalid input for student ID.");
                return;
            }

            bool studentFound = false;
            foreach (var classroom in classrooms)
            {
                var studentToRemove = classroom.FindStudentById(studentId);
                if (studentToRemove != null)
                {
                    classroom.DeleteStudent(studentId);
                    studentFound = true;
                    Console.WriteLine("Student deleted successfully.");
                    break;
                }
            }

            if (!studentFound)
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
