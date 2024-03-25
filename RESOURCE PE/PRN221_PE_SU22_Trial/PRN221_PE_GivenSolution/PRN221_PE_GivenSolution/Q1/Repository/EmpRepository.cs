using Q1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1.Repository
{
    public class EmpRepository : IEmpRepository
    {
        public Employee GetEmployeeByID(int employeeId) => EmployeeManagement.Instance.GetEmployeeByID(employeeId);

        public IEnumerable<Employee> GetEmployees() => EmployeeManagement.Instance.GetEmployeeList();

        public void InsertEmployee(Employee employee) => EmployeeManagement.Instance.AddNew(employee);

        public void DeleteEmployee(Employee employee) => EmployeeManagement.Instance.Remove(employee);

        public void UpdateEmployee(Employee employee) => EmployeeManagement.Instance.Update(employee);
    }
}
