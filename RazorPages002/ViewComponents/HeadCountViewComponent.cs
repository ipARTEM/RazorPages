using Microsoft.AspNetCore.Mvc;
using RazorPages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages002.ViewComponents
{
    public class HeadCountViewComponent:ViewComponent
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IViewComponentResult Invoke()
        {
            var result = _employeeRepository.EmployeeCountByDept();
            return View(result);


        }
    }
}
