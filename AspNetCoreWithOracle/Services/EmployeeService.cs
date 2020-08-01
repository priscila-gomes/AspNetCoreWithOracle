using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWithOracle.Interface;
using AspNetCoreWithOracle.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace AspNetCoreWithOracle.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly string _connectionString;        
        public EmployeeService(IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("OracleDBConnection");
        }
        public IEnumerable<Employees> GetAllEmployee()
        {
            List<Employees> EmployeeList = new List<Employees>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "Select employee_id, first_name,last_name,email,job_id,hire_date from Employees";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employees emp = new Employees
                        {
                            employee_id = Convert.ToInt32(rdr["employee_id"]),
                            first_name = rdr["first_name"].ToString(),
                            last_name = rdr["last_name"].ToString(),
                            email = rdr["email"].ToString(),
                            job_id = rdr["job_id"].ToString(),
                            hire_date = DateTime.Parse(rdr["hire_date"].ToString())
                        };
                        EmployeeList.Add(emp);
                    }
                }
            }
            return EmployeeList;
        }
        public Employees GetEmployeeById(int eid)
        {
            Employees Employee = new Employees();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "Select * from Employees where employee_id=" + eid + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employees stu = new Employees
                        {
                            employee_id = Convert.ToInt32(rdr["employee_id"]),
                            first_name = rdr["first_name"].ToString(),
                            last_name = rdr["last_name"].ToString(),
                            email = rdr["email"].ToString(),
                            job_id = rdr["job_id"].ToString(),
                            hire_date = DateTime.Parse(rdr["hire_date"].ToString())
                        };
                        Employee = stu;
                    }
                }
            }
            return Employee;
        }
        public void AddEmployee(Employees Employee)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        con.Open();
                        cmd.CommandText = "Insert into Employees(employee_id,first_name,last_name,email,job_id,hire_date)Values('" + Employee.employee_id + "','" 
                                            + Employee.first_name + "','" + Employee.last_name + "','" + Employee.email + "','" + Employee.job_id + "', '" 
                                            + Employee.hire_date.ToString("yyyy-MM-dd") + "' )";
                        cmd.ExecuteNonQuery();
                    }
                    
                }
            }
            catch
            {
                throw;
            }
        }
        public void EditEmployee(Employees Employee)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        con.Open();
                        cmd.CommandText = "Update Employees Set first_name='" + Employee.first_name + "', last_name='" + Employee.last_name + "', email='" 
                                            + Employee.email + "', job_id='" + Employee.job_id + "', hire_date='" + Employee.hire_date.ToString("yyyy-MM-dd") 
                                            + "' where employee_id=" + Employee.employee_id + "";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void DeleteEmployee(Employees Employee)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionString))
                {
                    using (OracleCommand cmd = con.CreateCommand()) 
                    {
                        con.Open();
                        cmd.CommandText = "Delete from Employees where employee_id=" + Employee.employee_id + "";
                        cmd.ExecuteNonQuery();                   
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
