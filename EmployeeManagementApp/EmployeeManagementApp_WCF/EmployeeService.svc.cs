using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeManagementApp_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeBL employeeBL;
        public EmployeeService()
        {
            employeeBL = new EmployeeBL();
        }

        public string AddEmployee(EmployeeContract employeeContract)
        {
            try
            {
                return employeeBL.AddEmployee(employeeContract);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public EmployeeContract GetById(string Id)
        {
            int empId = Convert.ToInt32(Id);
            return employeeBL.GetById(empId);
        }

        public IList<EmployeeContract> GetAllEmployees()
        {
            return employeeBL.GetAllEmployees();
        }

        public string UpdateEmployee(EmployeeContract employeeContract, string Id)
        {
            int empId = Convert.ToInt32(Id);
            return employeeBL.UpdateEmployee(employeeContract, empId);
        }

        public string DeleteEmployee(string Id)
        {
            int empId = Convert.ToInt32(Id);
            return employeeBL.DeleteEmployee(empId);
        }
    }
}
