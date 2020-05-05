using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prova_mvc.Models.TableViewModels
{
    public class ComentsTableViewModel
    {
        public int id;
        public string comments;
        public string data_coment;
        public int? parent_id;
        public string username;
        public int? pictureId;
        public List<ComentsTableViewModel> childComments;
    }                   
}