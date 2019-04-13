using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class AnswerViewModel
    {

        public int idAnswer { get; set; }
        public string answer { get; set; }
        public bool IsChecked { get; set; }
        public int testId { get; set; }

    }


    public class AnswerViewModelList
    {
        public List<AnswerViewModel> listAnswerViewModel { get; set; }

    }
}