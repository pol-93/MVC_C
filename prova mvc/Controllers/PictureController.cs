using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prova_mvc.Models.TableViewModels;
using prova_mvc.Models;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Services;

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
            List<UserTableViewModel> UserInfo = null; ;
            using (imagesGalleryEntities db = new imagesGalleryEntities())
            {
                allcomments = (from c in db.comments
                               join us in db.user on c.user_id equals us.id
                               where c.picture_id == pictureId && c.parent_comment_id == null
                               select new ComentsTableViewModel
                               {
                                   id = c.id,
                                   comments = c.comment,
                                   data_coment = c.comment_date.ToString(),
                                   parent_id = c.parent_comment_id,
                                   username = us.name,
                                   pictureId = c.picture_id,
                               }).ToList();

                thepicture = (from p in db.pictures
                              where p.id == pictureId
                              select new PicturesTableViewModel
                              {
                                  id = p.id,
                                  name = p.name,
                                  description = p.description,
                                  publicationDate = p.publication_date.ToString(),
                                  picture_varchar = p.picture_path,

                              }).ToList();

                UserInfo = (from u in db.user
                            join p in db.pictures on u.id equals p.user_id
                            select new UserTableViewModel
                            {
                                id = u.id,
                                username = u.name,
                                nickname = u.username,
                            }).Distinct().ToList();
            }

            getChildComments(ref allcomments, null, 0, pictureId);
            model.comments = allcomments;
            model.picture = thepicture;
            model.user = UserInfo;
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
                                                           join us in db.user on c.user_id equals us.id
                                                           where c.picture_id == pictureId && c.parent_comment_id == id_parent
                                                           select new ComentsTableViewModel
                                                           {
                                                               id = c.id,
                                                               comments = c.comment,
                                                               data_coment = c.comment_date.ToString(),
                                                               parent_id = c.parent_comment_id,
                                                               username = us.name,
                                                               pictureId = c.picture_id,
                                                           }).ToList();

                    if (Comments.ElementAt(i).childComments.Count > 0) {
                        for (int j = 0; j < Comments.ElementAt(i).childComments.Count; j++) {
                            int id_parent_last_lvl = Comments.ElementAt(i).childComments.ElementAt(j).id;
                            Comments.ElementAt(i).childComments.ElementAt(j).childComments =
                                (from c in db.comments
                                 join us in db.user on c.user_id equals us.id
                                 where c.picture_id == pictureId && c.parent_comment_id == id_parent_last_lvl
                                 select new ComentsTableViewModel
                                 {
                                     id = c.id,
                                     comments = c.comment,
                                     data_coment = c.comment_date.ToString(),
                                     parent_id = c.parent_comment_id,
                                     username = us.name,
                                     pictureId = c.picture_id,
                                 }).ToList();
                        }
                    }
                }
            }

        }
        [HttpPost]
        public async Task<List<ComentsTableViewModel>> loadComments(string CommentId, string pictureId)
            {
            
            List<ComentsTableViewModel> MoreComments = null; 
            using (imagesGalleryEntities db = new imagesGalleryEntities())
            {
                int CommentIdInt = Int32.Parse(CommentId);
                int PictureIdInt = Int32.Parse(pictureId);
                MoreComments = (from c in db.comments
                    join us in db.user on c.user_id equals us.id
                    where c.picture_id == PictureIdInt && c.parent_comment_id == CommentIdInt
                                select new ComentsTableViewModel
                    {
                        id = c.id,
                        comments = c.comment,
                        data_coment = c.comment_date.ToString(),
                        parent_id = c.parent_comment_id,
                        username = us.name,
                        pictureId = c.picture_id,
                    }).ToList();
               
            }
            return MoreComments;
        }

    }
   

}
