using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public class ado_SaleRepository
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Get all sales
        public static List<Sale> GetAllSales()
        {
            List<Sale> sales = new List<Sale>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT s.SaleID, c.CustomerName, p.ProductName, p.Price, s.SaleDate 
                                 FROM Sale s
                                 JOIN Customer c ON s.CustomerID = c.CustomerID
                                 JOIN Product p ON s.ProductID = p.ProductID";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sales.Add(new Sale
                    {
                        SaleID = Convert.ToInt32(reader["SaleID"]),
                        CustomerName = reader["CustomerName"].ToString(),
                        ProductName = reader["ProductName"].ToString(),
                        Price = reader["Price"].ToString(),
                        SaleDate = reader["SaleDate"].ToString()
                    });
                }
            }
            return sales;
        }

        // Insert a sale
        public static void InsertSale(Sale sale)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO Sale (CustomerID, ProductID, SaleDate) VALUES (@custId, @prodId, @date)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@custId", sale.CustomerID);
                cmd.Parameters.AddWithValue("@prodId", sale.ProductID);
                cmd.Parameters.AddWithValue("@date", sale.SaleDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}