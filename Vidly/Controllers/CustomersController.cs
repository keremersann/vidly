using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        private ApplicationDbContext applicationDbContext { get; set; }

        public CustomersController()
        {
            this.applicationDbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            this.applicationDbContext.Dispose();
        }

        public ActionResult Index()
        {
            var customers = applicationDbContext.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = applicationDbContext.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            Console.WriteLine(customer.MembershipType);
            
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

    }
}