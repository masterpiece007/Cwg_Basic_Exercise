using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Cwg_Exercise.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Cwg_Exercise.Data.Context
{

    //    public class BankDb : IdentityDbContext<ApplicationUser>
    public class BankDb : DbContext
    {
        public DbSet<CustomerAccountApplication> Customers { get; set; }

        //public BankDb()
        //    : base("DefaultConnection", throwIfV1Schema: false)
        //{
        //}

        //public static BankDb Create()
        //{
        //    return new BankDb();
        //}

    }
}