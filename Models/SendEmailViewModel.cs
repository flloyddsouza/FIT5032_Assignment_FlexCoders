﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace FlexCoders_Assignment.Models
{
    
        public class SendEmailViewModel
        {
            [Display(Name = "Email address")]
            //[Required(ErrorMessage = "Please enter an email address.")]
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string ToEmail { get; set; }

            [Required(ErrorMessage = "Please enter a subject.")]
            public string Subject { get; set; }

            [Required(ErrorMessage = "Please enter the contents")]
            public string Contents { get; set; }

           // public HttpPostedFileBase Upload { get; set; }

        }
   
}