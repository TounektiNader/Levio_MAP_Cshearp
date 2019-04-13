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
    public class ServiceFolder : Service<Folder>, IServiceFolder
    {
        private static IDatabaseFactory factory = new DatabaseFactory();
        private static IUnitOfWork work = new UnitOfWork(factory);
        public ServiceFolder():base(work)
        {

        }

        public Folder getFolder(int jobRequestId)
        {
            return GetAll().OfType<Folder>().Where(acc => acc.jobRequestId.Equals(jobRequestId)).FirstOrDefault();


        }



        public Folder getFolderByUser(int idUser)
        {
            var Em = GetAll();
            JobRequest A = work.getRepository<JobRequest>().GetAll().Where(a => a.userId == idUser).FirstOrDefault();


            return getFolder(A.jobRequestId);
            
        }

    }
}
