using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages002.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnviroonment;

        public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnviroonment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnviroonment = webHostEnviroonment;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; } 

        [BindProperty]
        public bool Notify { get; set; }

        public string Message { get; set; }

        public IActionResult OnGet(int? id)
        {


            if (id.HasValue)
            {
                Employee = _employeeRepository.GetEmployee(id.Value);
            }
            else
                Employee = new Employee();
            

            if (Employee==null)
            {
                return RedirectToPage("/NotFound");
            }
            

            
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                if (Photo != null)
                {
                    if (Employee.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnviroonment.WebRootPath, "images", Employee.PhotoPath);
                        System.IO.File.Delete(filePath);

                    }

                    Employee.PhotoPath = ProcessUploadedFile();

                }

                if (Employee.Id>0)
                {
                    Employee = _employeeRepository.Update(Employee);

                    TempData["SeccessMessage"] = $"Update{Employee.Name} successful!";

                }
                else
                {
                    Employee = _employeeRepository.Add(Employee);

                    TempData["SeccessMessage"] = $"Adding{Employee.Name} successful!";

                }

                

                return RedirectToPage("Employees");
            }
            return Page();
        }

        public void OnPostUpdateNotificationPrefirences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications";

            }
            else
            {
                Message = "You have turned off email notiffications";
            }

            Employee = _employeeRepository.GetEmployee(id);

        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo!=null)
            {
                string uploadsFolder = Path.Combine(_webHostEnviroonment.WebRootPath,"images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fs=new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);

                }

            }

            return uniqueFileName;
        }
    }
}
