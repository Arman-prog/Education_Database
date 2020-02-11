using System;
using Education_Database.Repositories;
using System.Linq;

namespace Education_Database
{
    class Program
    {
        static void Main()
        {
            StudentRepository studentRepository = new StudentRepository();
            var students = studentRepository.ToList();

            TeacherRepository teacherRepository = new TeacherRepository();
            var teachers = teacherRepository.ToList();

            UniversityRepository universityRepository = new UniversityRepository();
            var universities = universityRepository.ToList();

            AddressRepository addressRepository = new AddressRepository();
            var addresses = addressRepository.ToList();

            Teacher_UniversityRepository teacher_UniversityRepository = new Teacher_UniversityRepository();
            var teachersuniversity = teacher_UniversityRepository.ToList();

            var query1 = from s in students
                         from u in universities
                         where u.Id == s.UniversityId
                         from a in addresses
                         where a.Id == s.AddressId
                         select (s.FirstName, s.LastName,
                                 a.City, a.StreetOrDistrict, a.House, a.Appartment,
                                 u.Name);

            var stquery = query1.ToList();

            var query2 = from tu in teachersuniversity
                         from t in teachers
                         where t.Id == tu.TeacherId
                         from u in universities
                         where u.Id == tu.UniversityId
                         from a in addresses
                         where a.Id == u.AddressId
                         select (t.FirstName, t.LastName,
                                u.Name, a.City);

            var teachersquery = query2.ToList();


            Console.WriteLine("QUERY - Students\n");
            foreach (var item in stquery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("QUERY - Teachers\n");
            foreach (var item in teachersquery)
            {
                Console.WriteLine(item);
            }
        }
    }
}
