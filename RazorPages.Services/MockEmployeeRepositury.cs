using RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    Id=0, Name="Artem", Email="a.khimin@yandex.ru", PhotoPath="avatar.png", Department=Dept.IT
                },
                  new Employee()
                {
                    Id=1, Name="Nikita", Email="a.khimin@yandex.ru", PhotoPath="avatar2.png", Department=Dept.IT
                },
                    new Employee()
                {
                    Id=2, Name="Dema", Email="a.khimin@yandex.ru", PhotoPath="avatar3.png", Department=Dept.IT
                },
                      new Employee()
                {
                    Id=3, Name="Nastya", Email="a.khimin@yandex.ru", PhotoPath="avatar4.png", Department=Dept.HR
                },
                        new Employee()
                {
                    Id=4, Name="Igor", Email="a.khimin@yandex.ru", PhotoPath="avatar5.png", Department=Dept.Payroll
                },
                         new Employee()
                {
                    Id=5, Name="Ura", Email="a.khimin@yandex.ru", PhotoPath="avatar5.png", Department=Dept.Payroll
                }


            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x=>x.Id==id);
        }
    }
}
