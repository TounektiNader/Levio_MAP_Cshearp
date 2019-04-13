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
    public class ServiceDashboard : Service<User>, IDashboardService
    {
        private static IDatabaseFactory factory = new DatabaseFactory();
        private static IUnitOfWork work = new UnitOfWork(factory);
        public ServiceDashboard() : base(work)
        {

        }
        
    }
}
