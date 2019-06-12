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
        public ActionResult Authorise (Game.Models.Member model)
        {
            using(GameEntities1 db = new GameEntities1())
            {
                var userDetails = db.Members.Where(x => x.Account == model.Account && x.Password == model.Password).FirstOrDefault();
                if ( userDetails == null)
                {
                    model.LoginErrorMsg = "Invalid Account or Password";
                    return View("Index", model);
                }
                else
                {
                    Session["userID"] = userDetails.UserID;
                    return RedirectToAction("Index","Home");
                }
            }
        }
        public ActionResult MonsterNews()
        {
            return RedirectToAction("Index", "MonsterNews");
        }

        public ActionResult Members()
        {
            return RedirectToAction("Index", "Members");
        }

        public ActionResult Monster_Item()
        {
            return RedirectToAction("Index", "Monster_Item");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}