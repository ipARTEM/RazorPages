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

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(x => x.Id) + 1;

            _employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employeeToDelete = _employeeList.FirstOrDefault(x => x.Id == id);

            if (employeeToDelete!=null)
            {
                _employeeList.Remove(employeeToDelete);

            }
            return employeeToDelete;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept()
        {
            return _employeeList.GroupBy(x => x.Department )
                .Select(x => new DeptHeadCount()
                {
                    Department=x.Key.Value,
                     Count=x.Count()
                }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x=>x.Id==id);
        }

        public Employee Update(Employee updateEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(x => x.Id == updateEmployee.Id);
            if (employee!=null)
            {
                employee.Name = updateEmployee.Name;

                employee.Email = updateEmployee.Email;

                employee.Department = updateEmployee.Department;

                employee.PhotoPath = updateEmployee.PhotoPath;

                

            }
            return employee;
        }
    }
}
