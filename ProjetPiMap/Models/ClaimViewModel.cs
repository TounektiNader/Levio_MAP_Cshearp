using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class ClaimViewModel
    {
        public int recId { get; set; }
        public string type { get; set; }
        public string topic { get; set; }
        public int userid  { get; set; }
        public string email { get; set; }
        public string response { get; set; }

        public virtual User user { get; set; }

    }
}