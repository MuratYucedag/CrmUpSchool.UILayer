using Crm.UpSchool.DataAccessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Concrete;
using Crm.UpSchool.DataAccessLayer.Repository;
using Crm.UpSchool.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.DataAccessLayer.EntityFramework
{
    public class EfEmployeeDal : GenericRepository<Employee>, IEmployeeDal
    {
        public void ChangeEmployeeStatusToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public void ChangeEmployeeStatusToTrue(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployeesByCategory()
        {
            using (var context = new Context())
            {
                return context.Employees.Include(x => x.Category).ToList();
             }
        }
    }
}
