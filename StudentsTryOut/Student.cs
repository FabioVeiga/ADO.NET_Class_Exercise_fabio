using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentsTryOut
{
    class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        private string connectionStr = "Server=INSTRUCTORIT;Database=IBTCollege;User Id=ProfileUser;Password=ProfileUser2019";

        public Student() { }

        public List<string> ListOfStudent()
        {
            List<string> students = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                string sql = "SELECT Id, firstName, lastName, emailAddress FROM Students";
                conn.Open();
                try{
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        students.Add(reader["id"] + " - " + reader["firstName"] + " " + reader["lastName"] + "(" + reader["emailAddress"] + ")");
                    }
                    reader.Close();
                    
                }catch(SqlException e)
                {
                    students.Add("Erro: " + e);
                }
                return students;
            }
        }

        public List<string> SearchListOfStudent(string search)
        {
            List<string> students = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                string sql = "SELECT Id, firstName, lastName, emailAddress FROM Students WHERE firstName like '%"+ search + "%' or lastName like '%" + search + "%' or  Id like '%" + search + "%' or emailAddress like '%" + search + "%'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(reader["id"] + " - " + reader["firstName"] + " " + reader["lastName"] + "(" + reader["emailAddress"] + ")");
                }
                reader.Close();
            }
            return students;
        }

        public Student getStudent(int id)
        {
            Student student = new Student();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                string sql = "SELECT Id, firstName, lastName, emailAddress FROM Students WHERE Id=" + id;
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    student.Id = int.Parse(dt.Rows[0]["Id"].ToString());
                    student.FirstName = dt.Rows[0]["firstName"].ToString();
                    student.LastName = dt.Rows[0]["lastName"].ToString();
                    student.Email = dt.Rows[0]["emailAddress"].ToString();
                }

            }
            return student;
        }

        public bool InsertStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {

                conn.Open();
                string sql = "INSERT INTO Students" +
                    "(Id, firstName, lastName, emailAddress) VALUES (" +
                    "'" + NextId() + "'," +
                    "'" + student.FirstName + "'," +
                    "'" + student.LastName + "'," +
                    "'" + student.Email + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int NextId()
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                string sql = "SELECT max(Id) as id FROM Students";
                int lastId = 0;
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lastId = int.Parse(reader["id"].ToString());
                }
                reader.Close();
                return lastId + 1;
            }
        }

        public bool DeleteStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                string sql = "DELETE FROM Students WHERE id = " + id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                string sql = "UPDATE Students SET " +
                    "firstName = '" + student.FirstName + "'," +
                    "lastName = '" + student.LastName + "', " +
                    "emailAddress = '" + student.Email + "' " +
                    "WHERE id = " + student.Id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<string> ListOfStudentToExport()
        {
            List<string> students = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                string sql = "SELECT firstName, lastName FROM Students";
                conn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        students.Add(reader["firstName"] + " " + reader["lastName"]);
                    }
                    reader.Close();

                }
                catch (SqlException e)
                {
                    students.Add("Erro: " + e);
                }
                return students;
            }
        }

    }
}
