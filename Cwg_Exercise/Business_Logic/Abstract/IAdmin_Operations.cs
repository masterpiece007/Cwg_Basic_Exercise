using Cwg_Exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwg_Exercise.Business_Logic.Abstract
{
    interface IAdmin_Operations
    {
        /// <summary>
        /// method to view all customer account applications
        /// </summary>
        /// <returns>list of customers applications</returns>
        List<CustomerAccountApplication> ViewAllCustomersApplications();

        /// <summary>
        /// method to view a category of application based on the status
        /// </summary>
        /// <param name="applicationStatus"></param>
        /// <returns>list of customers application</returns>
        List<CustomerAccountApplication> ViewSpecificApplications( string applicationStatus);
        
        /// <summary>
        /// method to change the application status to approved 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>bool</returns>
        bool ApproveCustomerApplication(int customerId);

        /// <summary>
        /// method to change customer application status to rejected
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>bool</returns>
        bool RejectCustomerApplication(int customerId);

        /// <summary>
        /// method to create unique account number for approved customer's application
        /// </summary>
        /// <returns>int</returns>
        string GenerateAccountNumber();



    }
}
