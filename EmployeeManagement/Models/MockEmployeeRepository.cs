using EmployeeManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
        {
            new Employee() { Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@pragimtech.com" },
            new Employee() { Id = 2, Name = "John", Department = Dept.IT, Email = "john@pragimtech.com" },
            new Employee() { Id = 3, Name = "Sam", Department = Dept.Payroll, Email = "sam@pragimtech.com" },
        };
        }
        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee GetEmployee(int Id)
        {
            return this._employeeList.FirstOrDefault(e => e.Id == Id);
        }
        public List<Employee> GetAllEmployee()
        {
            return this._employeeList.ToList();
        }

        public Employee Update(Employee employeeChnages)
        {
            Employee employee = _employeeList.FirstOrDefault(x => x.Id == employeeChnages.Id);
            if (employee != null)
            {
                employee.Name = employeeChnages.Name;
                employee.Email = employeeChnages.Email;
                employee.Department = employeeChnages.Department;
            }
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee =_employeeList.FirstOrDefault(x => x.Id == Id);
            if (employee!=null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }
    }
}
