using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noam.Models
{
    public class Courses
    {

        public string? Id { get; set; }
        public string? Course_name { get; set; }
        public string? Course_points { get; set; }
	    public int Score { get; set; }


        public Courses(string id, string name, string points, int score) 
        {
            Id = id;
            Course_name = name;
            Course_points = points;
            Score = score;
        }

    }
}
