using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class TestModel
    {
        public int testId { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string question { get; set; }
        [Required]
        public string reponse { get; set; }
        [Required]
        public string choix1 { get; set; }
        [Required]

        public string choix2 { get; set; }
        public bool IsCheckedR { get; set; } 
        public bool IsCheckedR1 { get; set; }

        public bool IsCheckedR2 { get; set; }
        public List<Answers> answers { get; set; }


    }


    public class QuestionList
    {
        public List<TestModel> tests { get; set; }
    }
}