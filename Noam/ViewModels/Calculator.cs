using Noam.Models;
using System;
using System.Collections.Generic;


namespace Noam.ViewModels
{
    public class Calculator
    {
        Student[] students;

        /* Calculator - insert new students and courses to the system.
         * Given that I'm not working with a database, the data was randomly set for a list of five students for the demonstration.
         * Each score is randomly selected between 56 and 100.
         */
        public Calculator() {

            Student student1 = new Student("31866622", "Gal", "Cohen");
            Student student2 = new Student("31854322", "Eti", "Lankri");
            Student student3 = new Student("31821322", "Or", "Levi");
            Student student4 = new Student("31878522", "Yair", "Meir");
            Student student5 = new Student("31122442", "Dani", "Ron");

            students = new Student[] { student1, student2, student3, student4, student5};

            Random rnd = new Random();
            
            // Due to the fact that the course grade is in a course object, and not in a common object for student and course, I created a new course for each student with a different grade.
            // This solution is not ideal, we would prefer that each course be associated with a separate student.

            foreach (var student in students)
            {
                // insert courses with grades to the students.
                student.AddCourse(new Courses("211.1.1033", "Hedva", "5", rnd.Next(56, 101)));
                student.AddCourse(new Courses("311.1.1223", "Physics", "3.5", rnd.Next(56, 101)));
                student.AddCourse(new Courses("321.1.1321", "Intro to Programming", "5", rnd.Next(56, 101)));
                student.AddCourse(new Courses("321.1.1212", "Object Oriented Programming", "1", rnd.Next(56, 101)));
                student.AddCourse(new Courses("211.1.1333", "Algebra", "5", rnd.Next(56, 101)));
                student.AddCourse(new Courses("316.1.1115", "Data Structures", "4.5", rnd.Next(56, 101)));
                student.AddCourse(new Courses("317.1.1223", "Biology", "4", rnd.Next(56, 101)));
                student.AddCourse(new Courses("241.1.3211", "Java", "2", rnd.Next(56, 101)));
                student.AddCourse(new Courses("243.1.1212", "Python", "2", rnd.Next(56, 101)));
                student.AddCourse(new Courses("451.1.1333", "Web", "5", rnd.Next(56, 101)));
                student.AddCourse(new Courses("451.1.1333", "Sport", "0.5", rnd.Next(56, 101)));
            }

        }

        // For the view leyer 
        public Student[] getData()
        {
            return students;
        }

        /*
         * This function claculating the higest average for a student according to total points.
         * The main idea is using dynamic programming.
         * The use of the 2D array allows access to old solutions and checking whether we have found a better solution.
         */
        public double CalculateAvg(Student s, int totalPoints)
        {
            List<Courses> courses = s.GetCourses();           
            int numCourses = courses.Count;
            int dpSize = totalPoints;
      
            double[,] dp = new double[numCourses + 1, totalPoints + 1];

            // The dp[i, j] entry in the array represents the maximum combined grade using the first i courses and considering j points.
            // By building the dp array iteratively, the algorithm fills in the values ​​gradually,
            // calculating the maximum grades for different combinations of courses and points.   
            // At the end, the best solution will sit in the last cell.

            for (int i = 1; i <= numCourses; i++)
            {
                Courses currentCourse = courses[i - 1];
                double coursePoints = double.Parse(currentCourse.Course_points);
                double courseGrade = currentCourse.Score * coursePoints;

                for (int j = 1; j <= dpSize; j++)
                {
                    if (coursePoints <= j)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], courseGrade + dp[i - 1, (int)(j - coursePoints)]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            // divide in the totalPoints to calculate average 
            return dp[numCourses, dpSize] / totalPoints;
        }


    }
}
