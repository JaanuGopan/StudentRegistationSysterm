﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using WPF_Project.AddStudent;

namespace WPF_Project
{
    public partial class MainWindowVM :ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Students> people;

        [ObservableProperty]
        public Students selectedStudent = null;

        [RelayCommand]
        public void DeleteStudent()
        {
            people.Remove(selectedStudent);
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddStudentVM();
            vm.title = "ADD USER";
            AddStudentWindow window = new AddStudentWindow(vm);
            window.ShowDialog();

            if (vm.student.FirstName == null)
            {
                MessageBox.Show("Please Enter The Details..", "Warning!");
            }
            else
            {
                people.Add(vm.student);
            }
        }

        [RelayCommand]
        public void EditStudent()
        {
            if (selectedStudent != null)
            {
                var vm = new AddStudentVM(selectedStudent);
                vm.title = "EDIT USER";
                var window = new AddStudentWindow(vm);

                window.ShowDialog();


                int index = people.IndexOf(selectedStudent);
                people.RemoveAt(index);
                people.Insert(index, vm.student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }
        public MainWindowVM()
        {
            people = new ObservableCollection<Students>(); //store the student informations

            BitmapImage image1 = new BitmapImage(new Uri("/Profile Picture/1.png", UriKind.Relative)); 
            BitmapImage image2 = new BitmapImage(new Uri("/Profile Picture/2.png", UriKind.Relative));
            BitmapImage image3 = new BitmapImage(new Uri("/Profile Picture/3.png", UriKind.Relative));
            BitmapImage image4 = new BitmapImage(new Uri("/Profile Picture/4.png", UriKind.Relative));


            people.Add(new Students("Janugopan", "Sundaramoorthy", 23,image1, 3.25,"04/02/2000"));
            people.Add(new Students("Harintharan", "Nagalingam", 25, image2, 3.56, "04/02/2000"));
            people.Add(new Students("Lakshayan", "Thavaraja", 23,image3, 3.78, "04/02/2000"));
            people.Add(new Students("Yashokaran", "Phushparaj", 24, image4, 3.44, "04/02/2000"));
           
        }

    }
}
