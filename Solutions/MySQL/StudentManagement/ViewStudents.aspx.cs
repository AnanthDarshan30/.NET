using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace StudentManagement
{
    public partial class ViewStudents : Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudents();
            }
        }

        private void LoadStudents()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT StudentId, Name FROM students";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                ddlStudents.DataSource = reader;
                ddlStudents.DataTextField = "Name";
                ddlStudents.DataValueField = "StudentId";
                ddlStudents.DataBind();
                reader.Close();
            }
            ddlStudents.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Student--", "0"));
        }

        protected void btnGetDetails_Click(object sender, EventArgs e)
        {
            if (ddlStudents.SelectedValue == "0")
            {
                studentDetails.Visible = false;
                return;
            }

            int studentId = int.Parse(ddlStudents.SelectedValue);

            LoadStudentDetails(studentId);
            LoadStudentCourses(studentId);
            LoadStudentAttendance(studentId);

            studentDetails.Visible = true;
        }

        private void LoadStudentDetails(int studentId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT Name, Email, Phone FROM students WHERE StudentId = @StudentId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblStudentName.Text = reader["Name"].ToString();
                    lblStudentEmail.Text = reader["Email"].ToString();
                    lblStudentPhone.Text = reader["Phone"].ToString();
                }
                reader.Close();
            }
        }

        private void LoadStudentCourses(int studentId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT c.CourseName, c.Instructor 
                                 FROM courses c 
                                 INNER JOIN students s ON c.CourseId = s.CourseId 
                                 WHERE s.StudentId = @StudentId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gvCourses.DataSource = dt;
                gvCourses.DataBind();
            }
        }

        private void LoadStudentAttendance(int studentId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT c.CourseName, a.AttendanceDate, 
                                 CASE WHEN a.IsPresent = 1 THEN 'Yes' ELSE 'No' END AS IsPresent 
                                 FROM attendance a 
                                 INNER JOIN courses c ON a.CourseId = c.CourseId 
                                 WHERE a.StudentId = @StudentId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gvAttendance.DataSource = dt;
                gvAttendance.DataBind();
            }
        }
    }
}