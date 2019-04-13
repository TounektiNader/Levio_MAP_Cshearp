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

    public class ServiceMandate : Service<Mandate>, IServiceMandate
    {
        private static IDatabaseFactory factory = new DatabaseFactory();
        private static IUnitOfWork uof = new UnitOfWork(factory);


        public ServiceMandate() : base(uof)
        {

        }
    }
}
