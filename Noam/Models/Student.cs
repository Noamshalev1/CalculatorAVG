using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Noam.Models
{
    /*
     * Class Student
     * Holds the details about a student and his courses.
     */
    public class Student
    {
        public string? Id { get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get;set; }
        public List<Courses>? courses { get; set; }

        public Student(string id, string FName, string LName) 
        {
            this.Id = id;
            this.First_name = FName;
            this.Last_name = LName;
            courses = new List<Courses>();
        }

        public void AddCourse(Courses course)
        {
            if(course != null && !courses.Contains(course))
                courses.Add(course);
        }

        public void RemoveCourse(Courses course)
        {
            if (course != null && courses.Contains(course))
                courses.Remove(course);
        }

        public void SetGrade(Courses currentCourse, int grade)
        {
            foreach (var course in courses)
            {
                if (course.Id == currentCourse.Id)
                {
                    course.Score = grade;
                    break;
                }   
            }
        }

        public List<Courses> GetCourses() { return courses; }
    }
}
