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
   public class ServiceSkill : Service<Skills>, IServiceSkill
    {
        private static IDatabaseFactory factory = new DatabaseFactory();
        private static IUnitOfWork uof = new UnitOfWork(factory);

        public ServiceSkill() : base(uof)
        {

        }
    }
}
