using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;


namespace Service
{
  public class ServiceUser : Service<User>, IServiceUser
    {
        private static IDatabaseFactory factory = new DatabaseFactory();
        private static IUnitOfWork work = new UnitOfWork(factory);
        public ServiceUser() : base(work)
        {

        }


        public User getUserById(int Id)
        {
            return GetById(Id);
        }



    }
}
