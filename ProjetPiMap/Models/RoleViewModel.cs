using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {

        }
        public RoleViewModel(CustomRole role)
        {
            Id = role.Id;
            Name = role.Name;

        }
        public int Id { get; set; }

        public string Name { get; set; }
    }
}