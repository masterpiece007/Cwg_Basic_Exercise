using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cwg_Exercise.Models
{
    public class CustomerAccountApplication
    {
        [Key]
        public int id { get; set; }

        [Required,Display(Name = "customer name")]
        public string customerName { get; set; }

        [Required, Display(Name = "phone")]
        public string phoneNumber { get; set; }

        [Required, Display(Name = "address"),StringLength( maximumLength:25,
            ErrorMessage ="max length is 25,min length is 5",
            MinimumLength =5)]
        public string address { get; set; }

        [DataType(DataType.EmailAddress), Display(Name = "email")]
        public string email { get; set; }

        [Required, Display(Name = "account type")]
        public string accountType { get; set; }

        [Display(Name = "account number")]
        public string accountNumber { get; set; }

        [Display(Name = "application status")]
        public string applicationStatus { get; set; }

        //[Required,StringLength(
        //    maximumLength:9,
        //    ErrorMessage ="max length is 9,min length is 6",
        //    MinimumLength =6),
        //    DataType(DataType.Password)
        //    ]
        //public string password { get; set; }

        //[Compare("password",ErrorMessage ="password does not match"),DataType(DataType.Password),Display(Name ="compare password")]
        //public string confirmPassword { get; set; }
    }
}