using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace StudentsTryOut
{
    /// <summary>
    /// Interaction logic for newStudent.xaml
    /// </summary>
    public partial class newStudent : Window
    {
        public int ID;

        public newStudent()
        {
            InitializeComponent();
        }

        public newStudent(int id)
        {
            //Doing a cast to MainForm
            ID = id;
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ID == 0)
            {
                bool isValid;
                isValid = string.IsNullOrEmpty(txtStudentFisrtName.Text);
                if (isValid)
                {
                    MessageBox.Show("Please, fill a fisrt Name!", "Alert");
                    txtStudentFisrtName.Focus();
                    return;
                }
                isValid = string.IsNullOrEmpty(txtStudentLastName.Text);
                if (isValid)
                {
                    MessageBox.Show("Please, fill a last name!", "Alert");
                    txtStudentLastName.Focus();
                    return;
                }
                isValid = string.IsNullOrEmpty(txtStudentEmail.Text);
                if (isValid)
                {
                    MessageBox.Show("Please, fill a email!", "Alert");
                    txtStudentEmail.Focus();
                    return;
                }

                Student student = new Student();
                student.FirstName = txtStudentFisrtName.Text;
                student.LastName = txtStudentLastName.Text;
                student.Email = txtStudentEmail.Text;
                student.InsertStudent(student);
                MessageBox.Show("Student has been inserted", "Alert");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                Close();
            }
            else
            {
                Student student = new Student();
                student.Id = ID;
                student.FirstName = txtStudentFisrtName.Text;
                student.LastName = txtStudentLastName.Text;
                student.Email = txtStudentEmail.Text;
                if (student.UpdateStudent(student))
                {
                    MessageBox.Show("Student has been updated!", "Alert");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Something goes wrong, try again!", "Alert");
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
            if (ID == 0){
                Student student = new Student();
                txtStudentId.Text = student.NextId().ToString();
                btnDelete.IsEnabled = false;
            }
            else
            {
                Student student = new Student();
                student = student.getStudent(ID);
                txtStudentId.Text = student.Id.ToString();
                txtStudentFisrtName.Text = student.FirstName;
                txtStudentLastName.Text = student.LastName;
                txtStudentEmail.Text = student.Email;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void BbtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            if (student.DeleteStudent(ID))
            {
                MessageBox.Show("Student has been deleted!", "Alert");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Something goes wrong, try again!", "Alert");
            }
        }
    }
}
