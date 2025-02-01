using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Sale
    {
        public int SaleID { get; set; }  
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }  
        public string ProductID { get; set; }
        public string ProductName { get; set; }  
        public string Price { get; set; }  
        public string SaleDate { get; set; }
    }
}