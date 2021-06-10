﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPages.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The name field cannot be null! Please, write the name")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage ="Please, enter a Valid Email")]
        public string Email { get; set; }

        public string PhotoPath { get; set; }

        public Dept? Department { get; set; }

    }
}
