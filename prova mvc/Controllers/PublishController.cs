using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using prova_mvc.Models;


namespace prova_mvc.Controllers
{
    public class PublishController : Controller
    {
        // GET: Publish
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(pictures image, string post, string description)
        {
            string file = Path.GetFileNameWithoutExtension(image.imageFile.FileName);
            string extension = Path.GetExtension(image.imageFile.FileName);
            string filename = file + DateTime.Now.ToString("yymmssfff") + extension;

            using (imagesGalleryEntities db = new imagesGalleryEntities())
            {
                
                pictures addpicture = new pictures();
                try
                {
                    addpicture.id = (from picture in db.pictures
                                     select picture.id).Max() + 1;
                }
                catch (System.InvalidOperationException ex)
                {
                    addpicture.id = 0;
                };
                addpicture.name = post;
                addpicture.description = description;
                addpicture.publication_date = DateTime.Now;
                var Ouser = (user)Session["User"];
                addpicture.user_id = Ouser.id;
                addpicture.picture_path = "/img/userspictures/" + filename;
                filename = Path.Combine(Server.MapPath("~/img/userspictures/"), filename);
                image.imageFile.SaveAs(filename);
                
                
                db.pictures.Add(addpicture);
                db.SaveChanges();
            }
            ModelState.Clear();

            return View();
        }

    }
}
