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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentsTryOut
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            newStudent newS = new newStudent(0);
            newS.Show();
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string rootPath = Environment.CurrentDirectory;
            txtPathFile.Text = rootPath;
            txtNameFile.Text = "ExtractName.txt";
            Student student = new Student();
            for (int i = 0; i < student.ListOfStudent().Count; i++)
            {
                StudentList.Items.Add(student.ListOfStudent()[i]);
            }
        }

        private void TxtSerchStudent_KeyUp(object sender, KeyEventArgs e)
        {
            Student student = new Student();
            student.SearchListOfStudent(txtSerchStudent.Text);
            StudentList.Items.Clear();
            for (int i = 0; i < student.SearchListOfStudent(txtSerchStudent.Text).Count; i++)
            {
                StudentList.Items.Add(student.SearchListOfStudent(txtSerchStudent.Text)[i]);
            }
        }

        private void StudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int aux = StudentList.SelectedItem.ToString().IndexOf("-", 0);
            int Id = int.Parse(StudentList.SelectedItem.ToString().Substring(0, aux).ToString().Trim());
            newStudent newS = new newStudent(Id);
            newS.Show();
            Close();
        }

        private void BtnPathExport_Click(object sender, RoutedEventArgs e)
        {
            bool flag;
            flag = string.IsNullOrEmpty(txtPathFile.Text);
            if(flag)
            {
                MessageBox.Show("Path is empty!","Alert");
                txtPathFile.Focus();
                return;
            }
            flag = string.IsNullOrEmpty(txtNameFile.Text);
            if (flag)
            {
                MessageBox.Show("Name is empty!", "Alert");
                txtPathFile.Focus();
                return;
            }
            Student student = new Student();
            ExportFile exportFile = new ExportFile();
            string path_file = txtPathFile.Text + @"\" + txtNameFile.Text;
            string result = exportFile.Export(student.ListOfStudentToExport(), path_file);
            if (result == "Success")
            {
                MessageBox.Show("File Exported", "Alert");
            }
            else
            {
                MessageBox.Show("Error" + result, "Alert");
            }
        }
    }
}
