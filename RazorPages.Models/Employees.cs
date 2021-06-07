﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPages.Models
{
    public class Employees
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhotoPath { get; set; }

        public Dept? Department { get; set; }

    }
}
