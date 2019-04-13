using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetPiMap.Models
{
    public class BigViewModel
    {
        public AttachmentModel attachmentModel { get; set; }
        public JobRequestModel jobRequestModel { get; set; }
        public UserModel resourceViewModel { get; set; }
        public FolderViewModel folderViewModel { get; set; }
        public OfferViewModel offerViewModel { get; set;}
        public List<OfferViewModel> offerViewModels { get; set; }


    }
}