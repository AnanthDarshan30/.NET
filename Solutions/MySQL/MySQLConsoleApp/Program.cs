using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace MySQLConsoleApp
{
    class Program
    {
        static string connString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. DataReader");
                Console.WriteLine("2. DataAdapter");
                Console.WriteLine("3. ExecuteScalar");
                Console.WriteLine("4. Execute Stored Procedure: getMostFrequentCustomers");
                Console.WriteLine("5. Insert Customer");
                Console.WriteLine("6. Update Customer");
                Console.WriteLine("7. Delete Customer");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        UseDataReader();
                        break;
                    case "2":
                        UseDataAdapter();
                        break;
                    case "3":
                        UseExecuteScalar();
                        break;
                    case "4":
                        ExecuteStoredProcedure();
                        break;
                    case "5":
                        InsertCustomer();
                        break;
                    case "6":
                        UpdateCustomer();
                        break;
                    case "7":
                        DeleteCustomer();
                        break;
                    case "8":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        // Option 1: DataReader
        static void UseDataReader()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM customers";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["customer_id"]}, Name: {reader["first_name"]} {reader["last_name"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // Option 2: DataAdapter (fills a DataSet)
        static void UseDataAdapter()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM customers";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        Console.WriteLine($"ID: {row["customer_id"]}, Name: {row["first_name"]} {row["last_name"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // Option 3: ExecuteScalar (gets a single value, e.g., count of rows)
        static void UseExecuteScalar()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM customers";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    object result = cmd.ExecuteScalar();
                    Console.WriteLine($"Total number of customers: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // Option 4: Execute Stored Procedure
        static void ExecuteStoredProcedure()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("getMostFrequentCustomers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Most Frequent Customers:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["CustomerID"]}, Name: {reader["CustomerName"]}, Frequency: {reader["Frequency"]}");
                        }
                    }
                }
            }
        }

        // Option 5: Insert Customer
        static void InsertCustomer()
        {
            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO customers (CustomerName) VALUES (@name)", conn))
                {
                    cmd.Parameters.AddWithValue("@name", customerName);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) inserted.");
                }
            }
        }

        // Option 6: Update Customer
        static void UpdateCustomer()
        {
            Console.Write("Enter Customer ID to update: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.Write("Enter New Customer Name: ");
            string newCustomerName = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("UPDATE customers SET CustomerName = @name WHERE CustomerID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@name", newCustomerName);
                    cmd.Parameters.AddWithValue("@id", customerId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) updated.");
                }
            }
        }

       
        static void DeleteCustomer()
        {
            Console.Write("Enter Customer ID to delete: ");
            int customerId = int.Parse(Console.ReadLine());

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM customers WHERE CustomerID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", customerId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) deleted.");
                }
            }
        }
    }
}
