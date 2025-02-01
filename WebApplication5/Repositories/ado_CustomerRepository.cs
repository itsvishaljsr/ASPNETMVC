using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public class ado_CustomerRepository
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Get all customers
        public static List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM Customer";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        CustomerID = reader["CustomerID"].ToString(),
                        CustomerName = reader["CustomerName"].ToString(),
                        CustomerAddress = reader["CustomerAddress"].ToString()
                    });
                }
            }
            return customers;
        }

        // Insert a customer
        public static void InsertCustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO Customer (CustomerID, CustomerName, CustomerAddress) VALUES (@id, @name, @address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", customer.CustomerID);
                cmd.Parameters.AddWithValue("@name", customer.CustomerName);
                cmd.Parameters.AddWithValue("@address", customer.CustomerAddress);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Get customer name by ID
        public static string GetCustomerNameById(string customerId)
        {
            string customerName = string.Empty;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT CustomerName FROM Customer WHERE CustomerID = @customerId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customerName = reader["CustomerName"].ToString();
                }
            }
            return customerName;
        }
    }
}