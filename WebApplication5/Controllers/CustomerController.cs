using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer (No need to pass anything in the GET method)
        public ActionResult Index()
        {
            return View();  // View is strongly typed to Customer
        }

        [HttpPost]
        public ActionResult Insert(Customer customer)
        {
            ado_CustomerRepository.InsertCustomer(customer);  // Insert customer into DB
            return RedirectToAction("Index");  // Redirect to Index after saving
        }

        // Get all customers as JSON
        public JsonResult GetAllCustomers()
        {
            var customers = ado_CustomerRepository.GetAllCustomers();  // Fetch all customers
            return Json(customers, JsonRequestBehavior.AllowGet);  // Return JSON result
        }
    }
}