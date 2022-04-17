using CommonLayer.Constracts;
using RepositoryLayer.Interface;
using RepositoryLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class EmployeeRL : IEmployeeRL
    {
        Employee_ManagementEntities employeeServiceWCFEntities;

        public EmployeeRL()
        {
            employeeServiceWCFEntities = new Employee_ManagementEntities();
        }
        public int AddEmployee(EmployeeContract employeeContract)
        {

            Employee emp = new Employee()
            {
                Name = employeeContract.Name,
                Salary = employeeContract.Salary,
                Email = employeeContract.Email
            };
            employeeServiceWCFEntities.Employees.Add(emp);
            return employeeServiceWCFEntities.SaveChanges();
        }
        public IList<EmployeeContract> GetAllEmployees()
        {
            var query = (from a in employeeServiceWCFEntities.Employees select a).Distinct();
            List<EmployeeContract> employeeData = new List<EmployeeContract>();

            query.ToList().ForEach(x =>
            {
                employeeData.Add(new EmployeeContract
                {
                    Id = x.Id,
                    Name = x.Name,
                    Salary = (int)x.Salary,
                    Email = x.Email
                });
            });
            return employeeData;
        }
        public int UpdateEmployee(EmployeeContract employeeContract, int Id)
        {
            Employee employee = employeeServiceWCFEntities
                .Employees.Find(Id);
            if (employee != null)
            {
                employee.Email = employeeContract.Email;
                employee.Name = employeeContract.Name;
                employee.Salary = employeeContract.Salary;

                return employeeServiceWCFEntities.SaveChanges();
            }
            else
            {
                throw new Exception("Employee do not exists");
            }
        }
        public EmployeeContract GetById(int Id)
        {
            var Employee = employeeServiceWCFEntities.Employees.Find(Id);
            EmployeeContract employeeContract = new EmployeeContract()
            {
                Name = Employee.Name,
                Email = Employee.Email,
                Salary = (int)Employee.Salary,
                Id = Employee.Id
            };
            return employeeContract;
        }
        public int DeleteEmployee(int Id)
        {
            var employee = (from a in employeeServiceWCFEntities.Employees
                            where a.Id == Id
                            select a).FirstOrDefault();
            if (employee != null)
            {
                employeeServiceWCFEntities.Employees.Remove(employee);
                return employeeServiceWCFEntities.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}
