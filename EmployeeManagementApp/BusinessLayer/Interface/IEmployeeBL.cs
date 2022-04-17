using CommonLayer.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBL
    {
     
            string AddEmployee(EmployeeContract employeeContract);
            string UpdateEmployee(EmployeeContract employeeContract, int Id);
            EmployeeContract GetById(int Id);
            IList<EmployeeContract> GetAllEmployees();
            string DeleteEmployee(int Id);
     
    }
}
