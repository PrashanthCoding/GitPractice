using System;

class Program
{
    class Student
    {
        public string name;
        public int age;

        // Default Constructor
        public Student()
        {
            name = "Unknown";
            age = 0;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}, Age: {age}");
        }
    }

    static void Main()
    {
        Student student = new Student(); // Default constructor will be called
        student.DisplayInfo();
    }
}
