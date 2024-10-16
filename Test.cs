/*
 *  C# Program to Implement Let Condition using LINQ
 */
using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public string Regno { get; set; }
    public int Marks { get; set; }

}
class Program
{
    static void Main(string[] args)
    {
        //Object Initialization for Student class
        List<Student> objStudent = new List<Student>{
                    new Student{ Name="Prashanth",Regno="R001",Marks=80},
                    new Student{ Name="Manoj",Regno="R002",Marks=40},
                    new Student{ Name="Nazriya",Regno="R003",Marks=25},
                    new Student{ Name="Darini",Regno="R004",Marks=30},
                    new Student{ Name="Arjun",Regno="R005",Marks=70},
                };

        var objresult = from stu in objStudent
                        let totalMarks = objStudent.Sum(mark => mark.Marks)
                        let avgMarks = totalMarks / 5
                        where avgMarks > stu.Marks
                        select stu;
        foreach (var stu in objresult)
        {
            Console.WriteLine("Student: {0} {1}", stu.Name, stu.Regno);

        }
        Console.ReadLine();
    }
}