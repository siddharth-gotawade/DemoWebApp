using Application.Common.Interface;
using Application.Common.Utility;
using Dapper;
using Domain.Entities;
using Infrasturcture.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Repository
{
    public class EmployeeDapperRepository : IEmployeeDapperRepository
    {
        public IConfiguration _config;
        public string ConStr = string.Empty;

        public EmployeeDapperRepository(IConfiguration config)
        {
            _config = config;
            ConStr = _config.GetConnectionString("SqlConnection");
        }

        private IDbConnection Connection => new SqlConnection(ConStr);

        //public List<Employee> GetAllEmployees()
        //{
        //    DataSet ds = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "usp_GetAllEmployee");
        //    DataTable dt = ds.Tables[0]; // your method to load data
        //    List<Employee> emp = DataTableToList._DataTableToList<Employee>(dt);

        //    return emp;
        //}

        public List<EmployeeDapper> GetAllEmployees()
        {
            using var conn = Connection;
            return conn.Query<EmployeeDapper>("usp_GetAllEmployee", commandType: CommandType.StoredProcedure).ToList();
        }

        //public List<Employee> GetEmployeeById(int Id)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@P_ID", SqlDbType.Int) { Value = Id }
        //    };

        //    DataSet ds = SqlHelper.ExecuteDataset(ConStr, "usp_GetEmployeeById", parameters);
        //    DataTable dt = ds.Tables[0];
        //    List<Employee> emp = DataTableToList._DataTableToList<Employee>(dt);

        //    return emp;
        //}

        public EmployeeDapper? GetEmployeeById(int id)
        {
            using var conn = Connection;
            return conn.QueryFirstOrDefault<EmployeeDapper>("usp_GetEmployeeById", new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        //public void CreateEmployee(Employee employee)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@P_Name", SqlDbType.VarChar, 100) { Value = employee.Name },
        //        new SqlParameter("@P_DOB", SqlDbType.Date) { Value = employee.DOB }
        //    };
        //    SqlHelper.ExecuteNonQuery(ConStr, "usp_CreateEmployee", parameters);
        //}

        public void CreateEmployee(EmployeeDapper emp)
        {
            var conn = Connection;
            conn.Execute("usp_CreateEmployee", new { emp.Name, emp.DOB }, commandType: CommandType.StoredProcedure);
        }


        //public void UpdateEmployee(Employee employee)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //  {
        //        new SqlParameter("@P_ID", SqlDbType.Int) { Value = employee.Id },
        //        new SqlParameter("@P_NAME", SqlDbType.VarChar) { Value = employee.Name },
        //        new SqlParameter("@P_DOB", SqlDbType.DateTime) { Value = employee.DOB }

        //  };
        //    SqlHelper.ExecuteNonQuery(ConStr, "usp_UpdateEmployee", parameters);
        //}

        public void UpdateEmployee(EmployeeDapper emp)
        {
            using var conn = Connection;
            conn.Execute("usp_UpdateEmployee", new { emp.Id, emp.Name, emp.DOB }, commandType: CommandType.StoredProcedure);
        }

        //public void DeleteEmployee(Employee employee)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@P_ID", SqlDbType.Int) { Value = employee.Id }
        //    };
        //    SqlHelper.ExecuteNonQuery(ConStr, "usp_DeleteEmployee", parameters);
        //}

        public void DeleteEmployee(int id)
        {
            using var conn = Connection;
            conn.Execute("usp_DeleteEmployee", new { ID = id},commandType: CommandType.StoredProcedure);  
        }
    }
}
