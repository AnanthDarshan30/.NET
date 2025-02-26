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
    public partial class EnrollStudents : System.Web.UI.Page
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

                    ddlCourses.DataSource = reader;
                    ddlCourses.DataTextField = "CourseName";
                    ddlCourses.DataValueField = "CourseId";
                    ddlCourses.DataBind();
                    ddlCourses.Items.Insert(0, new ListItem("--Select a course--", "0"));
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error loading courses: " + ex.Message;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            txtName.CssClass = "";
            txtEmail.CssClass = "";
            txtPhone.CssClass = "";

            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            int courseId = int.Parse(ddlCourses.SelectedValue);

            bool hasError = false;
            lblMessage.Text = "";
            if(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phone))
            {
                txtName.CssClass = "error"; txtEmail.CssClass = "error";txtPhone.CssClass = "error";
                lblMessage.Text = "Please fill all the fields.";
                return;
            }
            if (string.IsNullOrEmpty(name))
            {
                txtName.CssClass = "error";
                lblMessage.Text += "Please fill Name. ";
                hasError = true;
            }

            if (string.IsNullOrEmpty(email))
            {
                txtEmail.CssClass = "error";
                lblMessage.Text += "Please fill Email. ";
                hasError = true;
            }
            else if (!email.Contains("@"))
            {
                txtEmail.CssClass = "error";
                lblMessage.Text += "Enter a valid email. ";
                hasError = true;
            }

            if (string.IsNullOrEmpty(phone))
            {
                txtPhone.CssClass = "error";
                lblMessage.Text += "Please fill Phone. ";
                hasError = true;
            }
            else if (phone.Length != 10 || !phone.All(char.IsDigit))
            {
                txtPhone.CssClass = "error";
                lblMessage.Text += "Enter a valid 10-digit phone number.<br/>";
                hasError = true;
            }

            if (hasError)
            {
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Students (Name, Email, Phone, CourseId) VALUES (@Name, @Email, @Phone, @CourseId)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    cmd.ExecuteNonQuery();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Student enrolled successfully!";
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    if (ex.Message.Contains("Email"))
                    {
                        lblMessage.Text = "Error enrolling student: User email already exists or invalid.";
                    }
                    else if (ex.Message.Contains("Course"))
                    {
                        lblMessage.Text = "Error enrolling student: No proper course selected.";
                    }
                    else
                    {
                        lblMessage.Text = "Error enrolling student: " + ex.Message;
                    }
                }
            }
        }
    }
}