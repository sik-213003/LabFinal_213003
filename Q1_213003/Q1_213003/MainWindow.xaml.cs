using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Q1_213003
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        ObservableCollection<Course> courses = new ObservableCollection<Course>();
        ObservableCollection<Student> student = new ObservableCollection<Student>();
        ObservableCollection<StudentCourse> studentCourses = new ObservableCollection<StudentCourse>();

        public MainWindow()
        {
            InitializeComponent();
            dataGridCourses.ItemsSource = courses;
            dataGridStudents.ItemsSource = student;
            dataGridStudentCourse.ItemsSource = studentCourses;
        }

        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            string code = txtCode.Text;
            string name = txtName.Text;

            if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(name))
            {
                Course newCourse = new Course { Code = code, Name = name };
                courses.Add(newCourse);

            }
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            string studentName = txtStudentName.Text;
            string regno = txtRegNo.Text;

            if(!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(regno))
            {
                Student newStudent = new Student { Name = studentName, RegNo = regno };
                student.Add(newStudent);
            }
        }

        private void AddStudentCourse_Click(object sender, RoutedEventArgs e)
        {
            string studentID = txtStudentID.Text;
            string courseID = txtCourseID.Text;

            if (!string.IsNullOrEmpty(studentID) && !string.IsNullOrEmpty(courseID))
            {
                StudentCourse newStudentCourse = new StudentCourse { StudentID = studentID, CourseID = courseID };
                studentCourses.Add(newStudentCourse);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                
                dataGridStudents.ItemsSource = student;
            }
            else
            {
                // Filter the students based on the search term
                var filteredStudents = student.Where(s => s.Name.ToLower().Contains(searchTerm) || s.RegNo.ToLower().Contains(searchTerm)).ToList();
                dataGridStudents.ItemsSource = filteredStudents;
            }
        }
    }

    public class Course : INotifyPropertyChanged
    {

        private string _id;
        public string id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(id));
                }
            }
        }

        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged(nameof(Code));
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Student : INotifyPropertyChanged
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _regNo;
        public string RegNo
        {
            get { return _regNo; }
            set
            {
                if (_regNo != value)
                {
                    _regNo = value;
                    OnPropertyChanged(nameof(RegNo));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class StudentCourse : INotifyPropertyChanged
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }

        private string _StudentID;
        public string StudentID
        {
            get { return _StudentID; }
            set
            {
                if (_StudentID != value)
                {
                    _StudentID = value;
                    OnPropertyChanged(nameof(StudentID));
                }
            }
        }

        private string _CourseID;
        public string CourseID
        {
            get { return _CourseID; }
            set
            {
                if (_CourseID != value)
                {
                    _CourseID = value;
                    OnPropertyChanged(nameof(CourseID));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
