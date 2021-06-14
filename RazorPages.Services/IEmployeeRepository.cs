using System;
using System.Collections.Generic;
using System.Text;
using RazorPages.Models;

namespace RazorPages.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployee(int id);

        Employee Update(Employee updateEmployee);

        Employee Add(Employee newEmployee);

        Employee Delete(int id);

        IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept);


    }
}
