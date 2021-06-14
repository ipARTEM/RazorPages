using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages002.Pages.Employees
{
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeRepository _db;

        public EmployeesModel(IEmployeeRepository db)
        {
            _db = db;
        }

        public IEnumerable<Employee> Employees { get; set; }

        [BindProperty(SupportsGet =true)]   // для методов пост   (SupportsGet =true)- для гет
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Employees = _db.Search(SearchTerm);
        }
    }
}
