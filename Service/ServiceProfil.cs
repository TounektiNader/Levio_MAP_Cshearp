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
    public class ServiceProfil :  Service<Profil>, IServiceProfile
    {
        private static IDatabaseFactory factory = new DatabaseFactory();
        private static IUnitOfWork uof = new UnitOfWork(factory);


        public ServiceProfil() : base(uof)
        {

        }
    }
}
