﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QueryString
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx?id=" + IDTextBox.Text + "&name=" + NameTextBox.Text + "&age=" + AgeTextBox.Text); //query string data
        }
    }
}