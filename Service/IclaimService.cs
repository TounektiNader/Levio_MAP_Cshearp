using Domain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public  interface IclaimService : IService<Claim>
    {
        void addClaim(Claim c);
        void addAdminClaim(Claim c1);
        List<Claim> getByUserId(int id);
        List<Claim> getAll();
        void DeleteClaim(int id);
        void EditClaim(int id, Claim cl);

    }
}
