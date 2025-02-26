using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace StudentManagement
{
    public partial class DispalyCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();
            }
        }
        private void LoadCourses()
        {
            string connString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    
                    string query = "SELECT CourseId, CourseName FROM Courses";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    
                    courseDropdown.DataSource = reader;
                    courseDropdown.DataTextField = "CourseName";
                    courseDropdown.DataValueField = "CourseId";
                    courseDropdown.DataBind();

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Response.Write($"<p>Error: {ex.Message}</p>");
                }
            }
        }
        protected void btnGetStudents_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                   
                    int courseId = int.Parse(courseDropdown.SelectedValue);
                    string query = @"
                        SELECT StudentId, Name, Email, Phone
                        FROM Students
                        WHERE CourseId = @CourseId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    
                    string studentHtml = "<table border='1'><tr><th>Student ID</th><th>Name</th><th>Email</th><th>Phone</th></tr>";

                    while (reader.Read())
                    {
                        studentHtml += $@"
                            <tr>
                                <td>{reader["StudentId"]}</td>
                                <td>{reader["Name"]}</td>
                                <td>{reader["Email"]}</td>
                                <td>{reader["Phone"]}</td>
                            </tr>";
                    }

                    studentHtml += "</table>";
                    studentList.Text = studentHtml;

                    reader.Close();
                }
                catch (Exception ex)
                {
                    studentList.Text = $"<p>Error: {ex.Message}</p>";
                }
            }
        }
    }
}