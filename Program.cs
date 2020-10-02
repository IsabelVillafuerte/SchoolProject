using CoreSchool.Entities;
using static System.Console;
using CoreSchool.Util;
using System.Linq;

namespace CoreSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new SchoolEngine();
            engine.Initialize();
            Printer.WriteTitle("Welcome to school!!!");
            PrintCourses(engine.School);

            var listObjects = engine.GetObjectSchool();
            //engine.School.CleanPlace();
            var listIPlace = from obj in listObjects
                            where obj is IPlace
                            select (IPlace)obj;
            Printer.WriteTitle("Welcome to school!!!");

        }
        
        private static void PrintCourses(School school)
        {
            Printer.DrawLine();
            Printer.WriteTitle("School Courses");
            if(school?.Courses != null)
                foreach (var course in school.Courses)
                    WriteLine($"Name: {course.Name}, Id: {course.UniqueId}");
            
        }
    }
}
