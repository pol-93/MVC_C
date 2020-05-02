using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prova_mvc.Models;
namespace prova_mvc.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.title = "Sign Up";
            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult index(String username,String password)
        {
            ViewBag.Title = "Your contact page." + username + " y " + password;
            using (imagesGalleryEntities db = new imagesGalleryEntities())
            {
                var lst = from d in db.user
                          where d.username == username && d.password == password
                          select d;
                if (lst.Count() == 1)
                {
                    user Ouser = lst.First();
                    Session["user"] = Ouser;
                    return Redirect("~/Dashboard/index");
                }
                else { 
                
                }
            }

                return View();
        }

        [HttpPost]
        public ActionResult signup(String nickname, String email, String password) {

            user adduser = new user();
            using (imagesGalleryEntities db = new imagesGalleryEntities())
            {
                try
                {
                    adduser.id = (from user in db.user
                                  select user.id).Max() + 1;
                }
                catch (System.InvalidOperationException ex)
                {
                    adduser.id = 0;
                }
                adduser.name = nickname;
                adduser.username = email;
                adduser.password = password;
                db.user.Add(adduser);
                db.SaveChanges();

                Session["user"] = adduser;
                return Redirect("~/Dashboard/index");

            }
            return View();
        }


    }
}