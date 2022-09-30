using Core.DataAccess.Adonet.Helpers;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Adonet
{
    public class AdoEmployeeDal : IEmployeeDal
    {
        public List<Employee> GetAll()
        {
            List<Employee> _employees = DbHelper.CreateReadConnection<Employee>("select * from Employees");
            
            return _employees;
        }
    }
}
