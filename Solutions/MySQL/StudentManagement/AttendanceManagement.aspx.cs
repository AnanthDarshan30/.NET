using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace StudentManagement
{
    public partial class ManageAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();
                txtDate.Attributes["max"] = DateTime.Today.ToString("yyyy-MM-dd"); // Restrict future dates
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
                    ddlCourses.Items.Insert(0, new ListItem("--Select Course--", "0"));
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error loading courses: " + ex.Message;
                }
            }
        }

        protected void cvDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DateTime.TryParse(args.Value, out DateTime selectedDate))
            {
                args.IsValid = selectedDate <= DateTime.Today;
            }
            else
            {
                args.IsValid = false; // Invalid format
            }
        }

        protected void btnLoadStudents_Click(object sender, EventArgs e)
        {
            // Check if a course is selected
            if (ddlCourses.SelectedValue == "0")
            {
                // Show the message in red and return early if no course is selected
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please select a course.";
                return;
            }

            // Get the selected course ID
            int courseId = int.Parse(ddlCourses.SelectedValue);
            string connString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // Query to get students for the selected course
                    string query = "SELECT StudentId, Name FROM Students WHERE CourseId = @CourseId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    // Use DataAdapter to fill DataTable
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the data to GridView
                    gvStudents.DataSource = dt;
                    gvStudents.DataBind();

                    // Display appropriate message if no students are found
                    if (dt.Rows.Count == 0)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "No students found for the selected course.";
                    }
                    else
                    {
                        lblMessage.Text = string.Empty; // Clear any previous messages
                    }
                }
                catch (Exception ex)
                {
                    // Display error message in case of an exception
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error loading students: " + ex.Message;
                }
            }
        }


        protected void btnSubmitAttendance_Click(object sender, EventArgs e)
        {
            if (ddlCourses.SelectedValue == "0")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please select a course.";
                return;
            }

            if (!DateTime.TryParse(txtDate.Text, out DateTime attendanceDate) || attendanceDate > DateTime.Today)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Invalid or future date.";
                return;
            }

            string connString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    foreach (GridViewRow row in gvStudents.Rows)
                    {
                        int studentId = int.Parse(row.Cells[0].Text);
                        bool isPresent = ((CheckBox)row.FindControl("chkIsPresent")).Checked;

                        // Check if the record already exists
                        string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE StudentId = @StudentId AND CourseId = @CourseId AND AttendanceDate = @AttendanceDate";
                        MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@StudentId", studentId);
                        checkCmd.Parameters.AddWithValue("@CourseId", ddlCourses.SelectedValue);
                        checkCmd.Parameters.AddWithValue("@AttendanceDate", attendanceDate);

                        int recordExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (recordExists > 0)
                        {
                            // Update the existing record
                            string updateQuery = "UPDATE Attendance SET IsPresent = @IsPresent WHERE StudentId = @StudentId AND CourseId = @CourseId AND AttendanceDate = @AttendanceDate";
                            MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                            updateCmd.Parameters.AddWithValue("@StudentId", studentId);
                            updateCmd.Parameters.AddWithValue("@CourseId", ddlCourses.SelectedValue);
                            updateCmd.Parameters.AddWithValue("@AttendanceDate", attendanceDate);
                            updateCmd.Parameters.AddWithValue("@IsPresent", isPresent);

                            updateCmd.ExecuteNonQuery();
                        }
                        else
                        {
                            // Insert a new record if it doesn't exist
                            string insertQuery = "INSERT INTO Attendance (StudentId, CourseId, AttendanceDate, IsPresent) VALUES (@StudentId, @CourseId, @AttendanceDate, @IsPresent)";
                            MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                            insertCmd.Parameters.AddWithValue("@StudentId", studentId);
                            insertCmd.Parameters.AddWithValue("@CourseId", ddlCourses.SelectedValue);
                            insertCmd.Parameters.AddWithValue("@AttendanceDate", attendanceDate);
                            insertCmd.Parameters.AddWithValue("@IsPresent", isPresent);

                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Attendance successfully submitted!";
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error submitting attendance: " + ex.Message;
                }
            }
        }

    }
}
