using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale (No data passed)
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Sale sale)
        {
            ado_SaleRepository.InsertSale(sale);  // Insert sale into DB
            return RedirectToAction("Index");
        }

        // Fetch Customer Name based on CustomerID
        public JsonResult GetCustomerName(string customerId)
        {
            var customerName = ado_CustomerRepository.GetCustomerNameById(customerId);
            return Json(customerName, JsonRequestBehavior.AllowGet);
        }

        // Fetch Product Price based on ProductID
        public JsonResult GetProductPrice(string productId)
        {
            var productPrice = ado_ProductRepository.GetProductPriceById(productId);
            return Json(productPrice, JsonRequestBehavior.AllowGet);
        }

        // Fetch all sales records in JSON format
        public JsonResult GetAllSales()
        {
            var sales = ado_SaleRepository.GetAllSales();  // Fetch all sales
            return Json(sales, JsonRequestBehavior.AllowGet);
        }
    }
}