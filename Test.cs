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

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}, Age: {age}");
        }
    }

    static void Main()
    {
        Student student = new Student("John", 20); // Parameterized constructor called
        student.DisplayInfo();
    }
}
