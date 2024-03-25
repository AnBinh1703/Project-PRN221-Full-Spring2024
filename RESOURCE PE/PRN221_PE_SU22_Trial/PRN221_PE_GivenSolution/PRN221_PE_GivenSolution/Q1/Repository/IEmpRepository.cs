using Q1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1.Repository
{
    public interface IEmpRepository
    {
        Employee GetEmployeeByID(int employeeId);
        IEnumerable<Employee> GetEmployees();
        void InsertEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
