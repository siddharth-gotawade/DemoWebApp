using Application.Common.Interface;
using Application.Common.Utility;
using Domain.Entities;
using Infrasturcture.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IConfiguration _config;
        public string ConStr = string.Empty;

        public EmployeeRepository(IConfiguration config)
        {
            _config = config;
            ConStr = _config.GetConnectionString("SqlConnection");
        }

        public List<Employee> GetAllEmployees()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "usp_GetAllEmployee");
            DataTable dt = ds.Tables[0]; // your method to load data
            List<Employee> emp = DataTableToList._DataTableToList<Employee>(dt);

            return emp;
        }

        public List<Employee> GetEmployeeById(int Id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@P_ID", SqlDbType.Int) { Value = Id }
            };

            DataSet ds = SqlHelper.ExecuteDataset(ConStr, "usp_GetEmployeeById", parameters);
            DataTable dt = ds.Tables[0];
            List<Employee> emp = DataTableToList._DataTableToList<Employee>(dt);

            return emp;
        }

        public void CreateEmployee(Employee employee)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@P_Name", SqlDbType.VarChar, 100) { Value = employee.Name },
                new SqlParameter("@P_DOB", SqlDbType.Date) { Value = employee.DOB }
            };
            SqlHelper.ExecuteNonQuery(ConStr, "usp_CreateEmployee", parameters);
        }

        public void DeleteEmployee(Employee employee)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@P_ID", SqlDbType.Int) { Value = employee.Id }
            };
            SqlHelper.ExecuteNonQuery(ConStr, "usp_DeleteEmployee", parameters);
        }
     

        public void UpdateEmployee(Employee employee)
        {
            SqlParameter[] parameters = new SqlParameter[]
          {
                new SqlParameter("@P_ID", SqlDbType.Int) { Value = employee.Id },
                new SqlParameter("@P_NAME", SqlDbType.VarChar) { Value = employee.Name },
                new SqlParameter("@P_DOB", SqlDbType.DateTime) { Value = employee.DOB }

          };
            SqlHelper.ExecuteNonQuery(ConStr, "usp_UpdateEmployee", parameters);
        }
    }
}
