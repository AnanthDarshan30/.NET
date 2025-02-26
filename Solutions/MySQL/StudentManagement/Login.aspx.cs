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
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = string.Empty;
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Check if inputs are not empty
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter both username and password.";
                return;
            }
            else if(string.IsNullOrEmpty(username))
            {
                lblMessage.Text = "Please enter your username.";
                return;
            }
            else if(string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter your password.";
                return;
            }

            // Connection string from Web.config
            string connString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE Username = @Username AND Password = @Password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password); // Ensure passwords are hashed in real apps

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        Session["Username"] = reader["Username"].ToString();
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Invalid username or password.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}