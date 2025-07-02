using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IEmployeeDapperRepository
    {
        List<EmployeeDapper> GetAllEmployees();
        EmployeeDapper? GetEmployeeById(int id);
        void CreateEmployee(EmployeeDapper employee);
        void UpdateEmployee(EmployeeDapper employee);
        void DeleteEmployee(int emp);
    }
}
