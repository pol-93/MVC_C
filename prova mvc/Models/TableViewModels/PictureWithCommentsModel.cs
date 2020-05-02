using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prova_mvc.Models.TableViewModels
{
    public class PictureWithCommentsModel
    {


            public List<PicturesTableViewModel> picture { get; set; }
            public List<ComentsTableViewModel> comments { get; set; }

            public List<UserTableViewModel> user { get; set; }

        public PictureWithCommentsModel()
            {
                this.picture = new List<PicturesTableViewModel>();
                this.comments = new List<ComentsTableViewModel>();
                this.user = new List<UserTableViewModel>();
        }
        

    }
}