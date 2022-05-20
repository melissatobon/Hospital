﻿using System.ComponentModel.DataAnnotations;

namespace Hospital.Web.Request
{
    public class EmailRequest
    {

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }

}
