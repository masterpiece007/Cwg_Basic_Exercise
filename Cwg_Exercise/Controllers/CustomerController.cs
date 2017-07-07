using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cwg_Exercise.Models;
using Cwg_Exercise.Business_Logic.Concrete;
using Cwg_Exercise.Data.Context;

namespace Cwg_Exercise.Controllers
{
    public class CustomerController : Controller
    {
        
        Customer_Implementation customerImplementation = new Customer_Implementation();
        // GET: Customer
        [Authorize]
        public ActionResult OpenNewBankAccount()
        {
            var userEmail = User.Identity.Name;
            var customer = new CustomerAccountApplication();
            ViewBag.accountType =new List<string> { "current", "savings" };
            if (customerImplementation.AccountExist(userEmail))
            {
                return RedirectToAction("Index", "Home", new { applicationMessage =" you cannot have more than 1 account" });
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpenNewBankAccount(CustomerAccountApplication customer)
        {
           var  userEmail=User.Identity.Name;
            
            if (ModelState.IsValid)
            {
                var isSubmitted = customerImplementation.OpenNewBankAccount(userEmail, customer);
                if (isSubmitted)
                {
                   return RedirectToAction("index", "Home", new { applicationMessage = "dear " + customer.customerName + " your application will be reviewed shortly" });
                }
                
            }
           
                 return View(customer);     
        }
        [Authorize]
        public ActionResult CheckApplicationStatus(string customerEmail)
        {
            var customer = customerImplementation.GetAccountApplicationInfo(customerEmail);
            if (customer != null)
            {
                return View(customer);
            }

           return RedirectToAction("index", "Home");
            
        }
    }
}