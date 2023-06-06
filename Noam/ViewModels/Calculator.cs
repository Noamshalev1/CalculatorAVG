using Noam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noam.Models;

namespace Noam.ViewModels
{
    public class Calculator
    {
        Student[] students;

        public Calculator() {

            Student student1 = new Student("31866622", "Gal", "Cohen");
            Student student2 = new Student("31854322", "Eti", "Lankri");
            Student student3 = new Student("31821322", "Or", "Levi");
            Student student4 = new Student("31878522", "Yair", "Meir");

            students = new Student[] { student1, student2, student3, student4 };

            Random rnd = new Random();

            foreach (var student in students)
            {

                student.AddCourse(new Courses("211.1.1033", "Hedva", "5", rnd.Next(50, 101)));
                student.AddCourse(new Courses("311.1.1223", "Physics", "3", rnd.Next(50, 101)));
                student.AddCourse(new Courses("321.1.1321", "Intro to Programming", "5", rnd.Next(50, 101)));
                student.AddCourse(new Courses("321.1.1212", "Object Oriented Programming", "2", rnd.Next(50, 101)));
                student.AddCourse(new Courses("211.1.1333", "Algebra", "5", rnd.Next(50, 101)));
            }

        }

        public Student[] getData()
        {
            return students;
        }

        public double CalculateAvg(Student s)
        {
            List<Courses> courses = s.GetCourses();
            List<Courses> sortedCourses = courses.OrderBy(c => c.Course_points).ThenBy(c => c.Score).ToList();
            List<Courses> top10Courses = new List<Courses>();
            int totalPoints = 0;
            foreach (Courses course in sortedCourses)
            {
                if (int.TryParse(course.Course_points, out int points)) {
                    if (totalPoints + points <= 10)
                    {
                        top10Courses.Add(course);
                        totalPoints += int.Parse(course.Course_points);
                    }
                    else
                    {
                        break;
                    }
                }
                    
            }
            double highestAvg = top10Courses.Average(c => c.Score);
            return highestAvg;
        }


    }
}
