/*
 * C# Program to Count File Extensions and Group it using LINQ
 */
using System;
using System.IO;
using System.Linq;
namespace ConsoleApplication9
{
    class Program
    {
        public static void Main()
        {
            string[] arr = { "aaa.txt", "bbb.TXT", "xyz.abc.pdf", "aaaa.PDF",
                             "abc.xml", "ccc.txt", "zzz.txt" };
            var egrp = arr.Select(file => Path.GetExtension(file).TrimStart('.').ToLower())
                       .GroupBy(x => x, (ext, extCnt) => new
                       {
                           Extension = ext,
                           Count = extCnt.Count()
                       });

            foreach (var v in egrp)
                Console.WriteLine("{0} File(s) with {1} Extension ",
                                    v.Count, v.Extension);
            Console.ReadLine();
        }
    }
}