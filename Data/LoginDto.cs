using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Data
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z][-_.a-zA-Z0-9]*@gmail.com$", ErrorMessage = "Please enter a valid  email address")]
        [StringLength(50, ErrorMessage = "Email should not exceed 50 characters")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
       //StringLength(50, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters")]
        public string password { get; set; }
    }
}