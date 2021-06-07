using System;
using System.Collections.Generic;
using System.Text;
using RazorPages.Models;

namespace RazorPages.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();


    }
}
