using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WPF_Project
{
    public class Students
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string DateOfBirth { set; get; }
        public int Age { set; get; }
        public BitmapImage Image { get; set; }
        public double GPA { set; get; }

        public Students(string firstName, string lastName, int age, BitmapImage imageUrl, double gpa, string dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Image = imageUrl;
            GPA = gpa;
            DateOfBirth = dateOfBirth;
        }
        public string ImageUrl
        {
            get { return $"/Profile Picture/{Image}"; }
        }

        public Students() { }
    }

    
}
