using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPages.Services
{
    public class MockEmployeeRepositury : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepositury()
        {
            _employeeList = new List<Employee>
            {
                new Employee()
                {
                    Id=0, Name="Artem", Email="a.khimin@yandex.ru", PhotoPath="photo.jpg", Department=Dept.IT
                },
                  new Employee()
                {
                    Id=1, Name="Nikita", Email="a.khimin@yandex.ru", PhotoPath="photo1.jpg", Department=Dept.IT
                },
                    new Employee()
                {
                    Id=2, Name="Dema", Email="a.khimin@yandex.ru", PhotoPath="photo2.jpg", Department=Dept.IT
                },
                      new Employee()
                {
                    Id=3, Name="Nastya", Email="a.khimin@yandex.ru", PhotoPath="photo3.jpg", Department=Dept.HR
                },
                        new Employee()
                {
                    Id=4, Name="Igor", Email="a.khimin@yandex.ru", PhotoPath="photo4.jpg", Department=Dept.Payroll
                },


            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }
    }
}
