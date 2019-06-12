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
    public class MonsterNewsController : Controller
    {
        private GameEntities1 db = new GameEntities1();

        // GET: MonsterNews
        public ActionResult Index()
        {
            return View(db.MonsterNew.ToList());
        }

        // GET: MonsterNews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonsterNew monsterNew = db.MonsterNew.Find(id);
            if (monsterNew == null)
            {
                return HttpNotFound();
            }
            return View(monsterNew);
        }

        // GET: MonsterNews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonsterNews/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MonsterID,MonsterName,MonsterHP,MonsterATK,MonsterExp")] MonsterNew monsterNew)
        {
            if (ModelState.IsValid)
            {
                db.MonsterNew.Add(monsterNew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monsterNew);
        }

        // GET: MonsterNews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonsterNew monsterNew = db.MonsterNew.Find(id);
            if (monsterNew == null)
            {
                return HttpNotFound();
            }
            return View(monsterNew);
        }

        // POST: MonsterNews/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MonsterID,MonsterName,MonsterHP,MonsterATK,MonsterExp")] MonsterNew monsterNew)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monsterNew).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monsterNew);
        }

        // GET: MonsterNews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonsterNew monsterNew = db.MonsterNew.Find(id);
            if (monsterNew == null)
            {
                return HttpNotFound();
            }
            return View(monsterNew);
        }

        // POST: MonsterNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonsterNew monsterNew = db.MonsterNew.Find(id);
            db.MonsterNew.Remove(monsterNew);
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
