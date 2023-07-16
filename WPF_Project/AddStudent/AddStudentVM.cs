using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WPF_Project.AddStudent
{
    public partial class AddStudentVM : ObservableObject
    {
        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public BitmapImage selectedImage;

        [ObservableProperty]
        public string title;
        public AddStudentVM(Students u)
        {
            Students student = u;

            firstname = student.FirstName;
            lastname = student.LastName;
            age = student.Age;
            gpa = student.GPA;
            dateofbirth = student.DateOfBirth;
            selectedImage = student.Image;

        }
        public AddStudentVM()
        {

        }


        //get image 
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Imgae successfuly uploded!", "successfull");
            }
        }






        public Students student { get; private set; }
        public Action CloseAction { get; internal set; }
        
        [RelayCommand]
        public void Save()
        {

            if (gpa < 0 || gpa > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error");
                return;
            }
            if (student == null)
            {

                student = new Students()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    Image = selectedImage,
                    GPA = gpa,
                    DateOfBirth = dateofbirth
           
                };


            }
            else
            {

                student.FirstName = firstname;
                student.LastName = lastname;
                student.Age = age;
                student.GPA = gpa;
                student.Image = selectedImage;
                student.DateOfBirth = dateofbirth;



            }

            if (student.FirstName != null)
            {

                CloseAction();
            }
            Application.Current.MainWindow.Show();


        }

    }
}
