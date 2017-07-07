using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cwg_Exercise.Business_Logic.Abstract;
using Cwg_Exercise.Models;
using Cwg_Exercise.Data.Context;
using System.Text;

namespace Cwg_Exercise.Business_Logic.Concrete
{
    public class Admin_Implementation : IAdmin_Operations
    {
        private ApplicationDbContext db;
        public Admin_Implementation()
        {
            db = new ApplicationDbContext();

        }
        
        public bool ApproveCustomerApplication(int customerId)
        {
            var customer = db.Customers.SingleOrDefault(a => a.id == customerId);
            if (customer != null)
            {
                customer.applicationStatus = "approved";
                db.SaveChanges();
                return true;
            }
            return false;
            // throw new NotImplementedException();
        }

        public string GenerateAccountNumber()
        {
            int accountNumberLength = 6;
            var random = new Random();
            var accountNumber = new StringBuilder();

            for (int i = 0; i < accountNumberLength; i++)
            {
                accountNumber.Append(random.Next(0, 9));
            }
            return accountNumber.ToString();
            
           // throw new NotImplementedException();
        }

        public bool RejectCustomerApplication(int customerId)
        {
            var customer = db.Customers.SingleOrDefault(a => a.id == customerId);
            if (customer != null)
            {
                customer.applicationStatus = "rejected";
                db.SaveChanges();
                return true;
            }
            return false;
            // throw new NotImplementedException();
        }

        public bool PendCustomerApplication(int customerId)
        {
            var customer = db.Customers.SingleOrDefault(a => a.id == customerId);
            if (customer != null)
            {
                customer.applicationStatus = "pending";
                db.SaveChanges();
                return true;
            }
            return false;
            // throw new NotImplementedException();
        }


        public List<CustomerAccountApplication> ViewAllCustomersApplications()
        {
            var customersApplications = db.Customers;
            if (customersApplications != null)
            {
            return customersApplications.ToList();
            }
            return null;
            
            //throw new NotImplementedException();
        }

        public List<CustomerAccountApplication> ViewSpecificApplications(string applicationStatus)
        {
            var specificApplications = db.Customers.Where(a => a.applicationStatus == applicationStatus);
            if (specificApplications != null)
            {
                return specificApplications.ToList();
            }
            return null;
            //throw new NotImplementedException();
        }
    }
}