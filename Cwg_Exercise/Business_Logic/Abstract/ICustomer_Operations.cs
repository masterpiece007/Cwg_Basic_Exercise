using Cwg_Exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwg_Exercise.Business_Logic.Abstract
{
    interface ICustomer_Operations
    {
        /// <summary>
        /// method for opening new account
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>bool</returns>
        bool OpenNewBankAccount(string userEmail, CustomerAccountApplication customer);

        /// <summary>
        /// method for getting account application info
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>string: Approved or Pending or Rejected</returns>
        CustomerAccountApplication GetAccountApplicationInfo(string customerEmail);
    }
}
