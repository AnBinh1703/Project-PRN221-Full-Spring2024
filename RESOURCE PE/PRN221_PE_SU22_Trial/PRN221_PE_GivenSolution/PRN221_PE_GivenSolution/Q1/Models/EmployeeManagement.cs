using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1.Models
{
    internal class EmployeeManagement
    {
        private static EmployeeManagement instance = null;

        private static readonly object instanceLock = new object();
        private EmployeeManagement() { }
        public static EmployeeManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            List<Employee> Employees;
            try
            {
                var PRN221_Spr22DB = new PRN221_Spr22Context();
                Employees = PRN221_Spr22DB.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Employees;
        }

        public Employee GetEmployeeByID(int EmployeeID)
        {
            Employee Employee = null;
            try
            {
                var PRN221_Spr22DB = new PRN221_Spr22Context();
                Employee = PRN221_Spr22DB.Employees.SingleOrDefault(car => car.Id == EmployeeID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Employee;
        }

        public void AddNew(Employee emp)
        {
            try
            {
                //Employee _Employee = GetEmployeeByID(emp.Id);
                //if (_Employee == null)
                //{
                    var PRN221_Spr22DB = new PRN221_Spr22Context();
                    PRN221_Spr22DB.Employees.Add(emp);
                    PRN221_Spr22DB.SaveChanges();
                //}
                //else
                //{
                //    throw new Exception("The Employee is already exist.");
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Employee employee)
        {
            try
            {
                Employee _employee = GetEmployeeByID(employee.Id);
                if (_employee != null)
                {
                    var PRN221_Spr22DB = new PRN221_Spr22Context();
                    PRN221_Spr22DB.Entry(employee).State = EntityState.Modified;
                    PRN221_Spr22DB.SaveChanges();
                }
                else
                {
                    throw new Exception("The employee does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Employee employee)
        {
            try
            {
                Employee _employee = GetEmployeeByID(employee.Id);
                if (_employee != null)
                {
                    var PRN221_Spr22DB = new PRN221_Spr22Context();
                    PRN221_Spr22DB.Employees.Remove(employee);
                    PRN221_Spr22DB.SaveChanges();
                }
                else
                {
                    throw new Exception("The employee does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
