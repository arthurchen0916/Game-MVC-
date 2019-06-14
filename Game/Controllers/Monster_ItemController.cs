using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Game.Models;

namespace Game.Controllers
{
    public class Monster_ItemController : Controller
    {
        private GameEntities1 db = new GameEntities1();

        // GET: Monster_Item
        public ActionResult Index()
        {
            return View(db.Monster_Item.ToList());
        }

        // GET: Monster_Item/Details/5
        public ActionResult Details(int? id ,string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monster_Item monster_Item = db.Monster_Item.Find(id,id2);
            if (monster_Item == null)
            {
                return HttpNotFound();
            }
            return View(monster_Item);
        }

        // GET: Monster_Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Monster_Item/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MonsterID,ItemName")] Monster_Item monster_Item)
        {
            if (ModelState.IsValid)
            {
                db.Monster_Item.Add(monster_Item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monster_Item);
        }

        // GET: Monster_Item/Edit/5
        public ActionResult Edit(int? id,string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monster_Item monster_Item = db.Monster_Item.Find(id,id2);
            if (monster_Item == null  )
            {
                return HttpNotFound();
            }
            return View(monster_Item);
        }

        // POST: Monster_Item/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MonsterID,ItemName")] Monster_Item monster_Item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monster_Item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monster_Item);
        }

        // GET: Monster_Item/Delete/5
        public ActionResult Delete(int? id,string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monster_Item monster_Item = db.Monster_Item.Find(id,id2);
            if (monster_Item == null)
            {
                return HttpNotFound();
            }
            return View(monster_Item);
        }

        // POST: Monster_Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string id2)
        {
            Monster_Item monster_Item = db.Monster_Item.Find(id,id2);
            db.Monster_Item.Remove(monster_Item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
