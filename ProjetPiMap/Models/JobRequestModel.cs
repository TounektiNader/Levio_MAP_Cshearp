﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class JobRequestModel
    {   
        public int jobRequestId { get; set; }

        public String speciality { get; set; }
        public String state { get; set; }
        public DateTime dateApply { get; set; }


        public int userId { get; set; }
    }
}