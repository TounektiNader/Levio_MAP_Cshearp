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
    public class ClaimsService : Service<Claim>, IclaimService
    {
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);

        public ClaimsService() : base(uow)
        {

        }


        //ajout pour client
        public void addClaim(Claim c )
        {
            uow.getRepository<Claim>().Add(c);
            uow.Commit();
        }
        //affichage pour admin
        public List<Claim> getAll()
        {
            List<Claim> Listclaim = new List<Claim>();
            Listclaim = GetAll().ToList();

            return Listclaim;
        }
        //affichage pour client
        public List<Claim> getByUserId(int id)
        {
            List<Claim> Listclaim = new List<Claim>();
            Listclaim = GetAll().Where(t => t.userId == 1).ToList();
            Listclaim.Count();
            return Listclaim;
        }
        //ajout pour admin
        public void addAdminClaim(Claim c1 )
        {
            c1.userId = 3;
            uow.getRepository<Claim>().Add(c1);
            uow.Commit();
        }

        public  void DeleteClaim(int id )
        {
            Claim c = new Claim();
            c = GetById(id);
            uow.getRepository<Claim>().Delete(c);
            uow.Commit();
        }

        public void EditClaim(int id, Claim cl)
        {
            uow.getRepository<Claim>().Update(cl);
            uow.Commit();
        }
    }
}
