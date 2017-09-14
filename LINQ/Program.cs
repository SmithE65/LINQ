using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlInterface;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        void Run()
        {
            System.Diagnostics.Debug.WriteLine("Hello world!");

            StudentCollection students = StudentCollection.Select();

/*            foreach (Student s in students)
            {
                System.Diagnostics.Debug.WriteLine($"{s.FirstName} {s.LastName}, major id: {s.MajorId}");
            }
*/
/*            // Do it myself
            StudentCollection DeansList = new StudentCollection();
            foreach (Student student in students)
            {
                if (student.GPA >= 3.5)
                    System.Diagnostics.Debug.WriteLine($"{student.FirstName} {student.LastName} has GPA of {student.GPA}");
            }
*/
            // Shorter syntax (LINQ)
/*            IEnumerable<Student> TopStudents = students.Where(s => s.GPA >= 3.5);
            foreach (Student student in TopStudents)
            {
                System.Diagnostics.Debug.WriteLine($"{student.FirstName} {student.LastName} has GPA of {student.GPA}");
            }
*/
            // Pretty syntax (LINQ)
            var test = from s in students
                       where s.GPA >= 3.5 && s.SatScore > 1400
                       select new { s.FirstName, s.LastName, s.GPA, s.SatScore };

            List<Major> majors = new List<Major>
            {
                new Major() { Id = 0, Name = "Non-matriculated"},
                new Major() { Id = 1, Name = "Audiology" },
                new Major() { Id = 2, Name = "Biology" },
                new Major() { Id = 3, Name = "Linguists" },
                new Major() { Id = 4, Name = "CS" },
                new Major() { Id = 5, Name = "ME" },
                new Major() { Id = 6, Name = "IPS" }
            };

            var studentsAndMajors = from s in students
                                    join m in majors
                                    on s.MajorId equals m.Id
                                    where m.Id < 4
                                    orderby s.LastName descending
                                    select new { s.FirstName, s.LastName, m.Name };

            foreach (var s in studentsAndMajors)
            {
                System.Diagnostics.Debug.WriteLine($"{s.FirstName} {s.LastName} majoring in {s.Name}");
            }
        }
    }
}
