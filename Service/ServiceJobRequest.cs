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
    public class ServiceJobRequest : Service<JobRequest>, IServiceJobRequest
    {
        private static IDatabaseFactory factory = new DatabaseFactory();
        private static IUnitOfWork work = new UnitOfWork(factory);
        public ServiceJobRequest():base(work)
        {

        }
        public JobRequest getJobRequest(int userId,int offerId)
        {
             return GetAll().OfType<JobRequest>().Where(acc => acc.userId.Equals(userId) && acc.offerId.Equals(offerId)).FirstOrDefault();

        }

        public JobRequest getJobRequest(int userId)
        {
            return GetAll().OfType<JobRequest>().Where(acc => acc.userId.Equals(userId)).FirstOrDefault();

        }


    }
}
