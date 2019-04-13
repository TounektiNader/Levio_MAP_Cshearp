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
    public class ServiceOffer : Service<OfferJobs>, IServiceOffer
    {
        private static IDatabaseFactory factory = new DatabaseFactory();
        private static IUnitOfWork work = new UnitOfWork(factory);

        public ServiceOffer() :base(work)
        {

        }

        public IEnumerable<OfferJobs> ListOffers()
        {
            return GetAll();
        }

        public int OfferNumber()
        {
            return GetAll().Count();
        }

        public int CustomerNumber()
        {
            IServiceClient serviceClient = new ServiceCustomer();
            int client = serviceClient.GetAll().Count();
            return client;
        }

        public int FreelancerNumber()
        {
            IServiceResources serviceResource = new ServiceResources();
            int pigiste = serviceResource.GetAll().Where(x => x.type == "Freelancer").Count();
            return pigiste;
        }

        public int EmployeNumber()
        {
            IServiceResources serviceResource = new ServiceResources();
            int employe = serviceResource.GetAll().Where(x => x.type == "Employee").Count();
            return employe;
        }

        public int Total()
        {
            IServiceUser serviceUser = new ServiceUser();
            int users = serviceUser.GetAll().Count();
            return users;
        }
    }
}
