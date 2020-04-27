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
                //db.Database.ExecuteSqlCommand("insert into Table1 values(1088, 'Conditioner', 'expense4',590);");
                //var query = db.user.SqlQuery("select * from dbo.user").ToList<user>();
                var lst = from d in db.user
                          where d.username == username && d.password == password
                          select d;
                if (lst.Count() == 1)
                {
                    user Ouser = lst.First();
                    Session["user"] = Ouser;
                    Response.Redirect("~/Dashboard/index");
                }
                else { 
                
                }
            }

                return View();
        }


    }
}