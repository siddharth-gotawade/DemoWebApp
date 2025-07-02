using Application.Common.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitOfWork
    {
        public IEmployeeRepository EmpRepo { get; set; }
        public readonly IConfiguration _config;
        public UnitOfWork() 
        {
            EmpRepo = new EmployeeRepository(_config);
        }

    }
}
