using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product (No need to pass any data)
        public ActionResult Index()
        {
            return View();  // View is strongly typed to Product
        }

        [HttpPost]
        public ActionResult Insert(Product product)
        {
            ado_ProductRepository.InsertProduct(product);  // Insert product into DB
            return RedirectToAction("Index");  // Redirect to Index after saving
        }

        // Get all products as JSON
        public JsonResult GetAllProducts()
        {
            var products = ado_ProductRepository.GetAllProducts();  // Fetch all products
            return Json(products, JsonRequestBehavior.AllowGet);  // Return JSON result
        }
    }
}