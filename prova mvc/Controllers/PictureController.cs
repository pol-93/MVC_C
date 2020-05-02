using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prova_mvc.Models.TableViewModels;
using prova_mvc.Models;
namespace prova_mvc.Controllers
{
    public class PictureController : Controller
    {
        // GET: Picture
        [HttpGet]
        public ActionResult Index(int pictureId)
        {
            PictureWithCommentsModel model = new PictureWithCommentsModel();
            
            List<ComentsTableViewModel> allcomments = null;
            List<PicturesTableViewModel> thepicture = null;
            using (imagesGalleryEntities db = new imagesGalleryEntities())
            {
                allcomments = (from c in db.comments
                               where c.picture_id == pictureId && c.parent_comment_id == null
                               select new ComentsTableViewModel
                               {
                                   id = c.id,
                                   comments = c.comment,
                                   data_coment = c.comment_date.ToString(),
                                   parent_id = c.parent_comment_id,
                               }).ToList();

                thepicture = (from p in db.pictures
                             where p.id == pictureId 
                             select new PicturesTableViewModel
                             {
                                 id = p.id,
                                 name = p.name,
                                 description = p.description,
                                 picture_varchar = p.picture_path,

                             }).ToList();
            }

            getChildComments(ref allcomments, null, 0, pictureId);
            model.comments = allcomments;
            model.picture = thepicture;
            return View(model);
        }

        public void getChildComments(ref List<ComentsTableViewModel> Comments, List<ComentsTableViewModel> ActualChilds, int position, int pictureId)
        {
            int i = 0;

            for (i = 0; i < Comments.Count; i++)
            {

                using (imagesGalleryEntities db = new imagesGalleryEntities())
                {
                    int id_parent = Comments.ElementAt(i).id;
                    Comments.ElementAt(i).childComments = (from c in db.comments
                                                           where c.picture_id == pictureId && c.parent_comment_id == id_parent
                                                           select new ComentsTableViewModel
                                                           {
                                                               id = c.id,
                                                               comments = c.comment,
                                                               data_coment = c.comment_date.ToString(),
                                                               parent_id = c.parent_comment_id,
                                                           }).ToList();

                }
            }

        }
      
    }
}
