using Application.Services.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
        
        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
