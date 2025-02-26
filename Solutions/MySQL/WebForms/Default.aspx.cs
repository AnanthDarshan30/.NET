using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebForms
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) //default run method
        {

        }
        protected void btnFetchData_Click(object sender, EventArgs e) //fetch data button fn
        {
            try
            {
                string connstring = "server=localhost;uid=root;pwd=Mercenary001!;database=ananth";
                using (MySqlConnection conn = new MySqlConnection(connstring))
                {
                    conn.Open();  

                    //query to fetch data
                    string sql = "SELECT * FROM customers";
                    string sql1 = "UPDATE customers SET first_name = 'James' WHERE first_name = 'Shiva';SELECT * FROM customers;";
                    MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                    MySqlCommand cmd = new MySqlCommand(sql1, conn);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    string result = "";
                    while (reader.Read())
                    {
                        result += "Name: " + reader["first_name"].ToString() + "<br />";
                    }
                    lblResult.Text = result; //update 

                    reader.Close();

                   //grid view
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    //binding results
                    gvCustomers.DataSource = dt;
                    gvCustomers.DataBind();

                    conn.Close();
                }
            }
            catch (MySqlException ex)
            { 
                lblResult.Text = "Error: " + ex.Message;
            }
        }
    }
}
