using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cwg_Exercise.Business_Logic.Abstract;
using Cwg_Exercise.Models;
using Cwg_Exercise.Data.Context;

namespace Cwg_Exercise.Business_Logic.Concrete
{
    public class Customer_Implementation : ICustomer_Operations
    {
        private ApplicationDbContext db;
        private Admin_Implementation adminImplementation;
        ApplicationUser appUser = new ApplicationUser();
        public Customer_Implementation()
        {
             db = new ApplicationDbContext();
            adminImplementation = new Admin_Implementation();
        }

        public bool AccountExist(string userEmail)
        {
            var isExist = db.Customers.SingleOrDefault(a => a.email == userEmail);
            if (isExist != null)
            {
                return true;  
            }
            return false;
        }

        public CustomerAccountApplication GetAccountApplicationInfo(string customerEmail)
        {
            var customer = db.Customers.SingleOrDefault(a => a.email== customerEmail);
            if (customer !=null)
            {
                return customer;
            }
            return null;
           // throw new NotImplementedException();
        }

        public bool OpenNewBankAccount(string userEmail,CustomerAccountApplication customer)
        {
            //ApplicationUser appUser = new ApplicationUser();
            if (customer != null)
            {
               
                customer.applicationStatus = "pending";
                customer.email = userEmail;
                customer.accountNumber = adminImplementation.GenerateAccountNumber();
                db.Customers.Add(customer);
                db.SaveChanges();
                return true;     
            }
            return false;
           // throw new NotImplementedException();
        }

       
    }
}