using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagement
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUsername.Text = Session["Username"].ToString();
            }
        }
        protected void btnEnrollStudents_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentEnrollment.aspx");
        }

        protected void btnManageAttendance_Click(object sender, EventArgs e)
        {
            Response.Redirect("AttendanceManagement.aspx");
        }

        protected void btnViewCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisplayCourses.aspx");
        }

        protected void btnViewStudents_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewStudents.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}