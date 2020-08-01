using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWithOracle.Models;

namespace AspNetCoreWithOracle.Interface
{
    public interface IEmployeeService
    {
        IEnumerable<Employees> GetAllEmployee();
        Employees GetEmployeeById(int eid);
        void AddEmployee(Employees Employee);
        void EditEmployee(Employees Employee);
        void DeleteEmployee(Employees Employee);
    }
}
