using System;

class Program
{
    class Student
    {
        public string name;
        public int age;

        // Parameterized Constructor
        public Student(string studentName, int studentAge)
        {
            name = studentName;
            age = studentAge;
        }

        // Copy Constructor
        public Student(Student student)
        {
            name = student.name;
            age = student.age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}, Age: {age}");
        }
    }

    static void Main()
    {
        Student student1 = new Student("Alice", 22); // Parameterized constructor
        Student student2 = new Student(student1); // Copy constructor

        student1.DisplayInfo();
        student2.DisplayInfo();
    }
}
