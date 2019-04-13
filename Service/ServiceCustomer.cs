using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceCustomer :Service<Customer>, IServiceClient
    {

        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork UOW = new UnitOfWork(dbfactory);

       

        public ServiceCustomer() : base(UOW)
        {

        }

        //public ApplicationIdentity FindRoleByName(string email)
        //{
        //    IEnumerable<Customer> ls = this.GetMany().OrderBy(p => p.Id).Where(p => p.Email == email).Take(1);

        //    Customer c = new Customer();
        //    foreach (var i in ls)
        //    {
        //        c.firstname = i.firstname;
        //        c.Roles. = i.role;
        //    }
        //    return c;
        //}

    }
}
