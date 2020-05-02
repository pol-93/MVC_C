using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prova_mvc.Models;
using prova_mvc.Models.TableViewModels;
namespace prova_mvc.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
           
            user currentUser = (user)Session["user"];
            List<PicturesTableViewModel> lst = null;
            using (imagesGalleryEntities db = new imagesGalleryEntities())
            {
                try
                {
                    lst = (from p in db.pictures
                           where p.user_id == currentUser.id
                           select new PicturesTableViewModel
                           {
                               id = p.id,
                               name = p.name,
                               description = p.description,
                               user_id = p.user_id,
                               picture_varchar = p.picture_path
                           }).ToList();
                
                    return View(lst);


                    }
                catch (System.NullReferenceException e)
                {
                    return Redirect("~/home");
                }
            }
        }
     
        public ActionResult logout()
        {
            try
            {
                Session["user"] = null;
                return Redirect("~/home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

    }
}
