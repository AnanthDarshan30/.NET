using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegistration
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Code here will execute when the page loads for the first time.
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Here you would normally save the data to a database
            // For simplicity, we're just displaying a message.
            lblMessage.Text = $"User '{username}' registered successfully!";
        }
    }
}