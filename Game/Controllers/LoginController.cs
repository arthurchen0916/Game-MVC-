using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Game.Models;

namespace Game.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorise(Member account)
        {
            using(GameEntities1 db= new GameEntities1())
            {
                var userDetail = db.Members.Where(x => x.Account == account.Account && x.Password == account.Password).FirstOrDefault();
                if(userDetail == null)
                {
                    account.LoginErrorMsg = "Invalid Account or Password";
                    return View("Index", account);
                }
                else
                {
                    Session["userID"] = account.UserID;
                    return RedirectToAction("Index","Home");
                }
            }

        }
    }
}