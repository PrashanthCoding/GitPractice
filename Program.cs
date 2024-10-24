using System;

class Program
{
    class Student
    {
        public string name;
        public int age;

        // Constructor chaining
        public Student() : this("Unknown", 0)
        {
        }

        public Student(string studentName) : this(studentName, 0)
        {
        }

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
        Student student1 = new Student();
        student1.DisplayInfo();

        Student student2 = new Student("Paul");
        student2.DisplayInfo();

        Student student3 = new Student("Sarah", 23);
        student3.DisplayInfo();
    }
}
