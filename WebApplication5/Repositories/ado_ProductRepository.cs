using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public class ado_ProductRepository
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Get all products
        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM Product";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductID = reader["ProductID"].ToString(),
                        ProductName = reader["ProductName"].ToString(),
                        Price = reader["Price"].ToString()  // Price as string, based on your schema
                    });
                }
            }
            return products;
        }

        // Insert a product
        public static void InsertProduct(Product product)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO Product (ProductID, ProductName, Price) VALUES (@id, @name, @price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", product.ProductID);
                cmd.Parameters.AddWithValue("@name", product.ProductName);
                cmd.Parameters.AddWithValue("@price", product.Price);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Get product price by ProductID
        public static string GetProductPriceById(string productId)
        {
            string productPrice = string.Empty;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT Price FROM Product WHERE ProductID = @productId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@productId", productId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    productPrice = reader["Price"].ToString();
                }
            }
            return productPrice;
        }
    }
}