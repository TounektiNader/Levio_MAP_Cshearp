using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entities;
using ServicePattern;

namespace Service
{
    public class ServiceResources : Service<Resource>, IServiceResources
    {
        private static IDatabaseFactory factory = new DatabaseFactory();
        private static IUnitOfWork work = new UnitOfWork(factory);
        public ServiceResources() : base(work)
        {

        }
        public Resource getResource(string usernme) {
            Resource r = new Resource();

            r = GetAll().Where(a => a.UserName.Equals(usernme)).SingleOrDefault();
            return r;
        }
    }
}
