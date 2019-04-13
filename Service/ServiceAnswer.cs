using Data.Infrastructure;
using Domain.Entities;
using Service;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceAnswer : Service<Answers>, IServiceAnswer
    {
        private static IDatabaseFactory factory = new DatabaseFactory();
        private static IUnitOfWork work = new UnitOfWork(factory);
        public ServiceAnswer() : base(work)
        {

        }

        public IEnumerable<Answers> getListAnswers(int idUsr)
        {
         
            
            return GetMany().OfType<Answers>().Where(a=>a.idUser== idUsr).OrderBy(t => t.idTest);
        }
    }

}