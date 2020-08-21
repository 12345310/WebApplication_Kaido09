using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_Kaido09.Models;

namespace WebApplication_Kaido09.Controllers
{
    public class MVCListsController : Controller
    {
        private MVCToDo db = new MVCToDo();

        // GET: MVCLists
        public ActionResult Index()
        {
            return View(db.MVCList.ToList());
        }

        // 一覧画面のチェックボックスの状態を登録
        [HttpPost]
        public ActionResult Check1(int Id, bool DoneFlg)
        {
            MVCList mvcList = db.MVCList.Find(Id);
            mvcList.DoneFlg = DoneFlg;
            db.Entry(mvcList).State = EntityState.Modified;
            db.SaveChanges();
            return Json(mvcList);
        }

        // GET: MVCLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVCLists/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DoneFlg,TodoName,DeadLine,Remarks")] MVCList mVCList)
        {
            if (ModelState.IsValid)
            {
                db.MVCList.Add(mVCList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mVCList);
        }

        // GET: MVCLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVCList mVCList = db.MVCList.Find(id);
            if (mVCList == null)
            {
                return HttpNotFound();
            }
            return View(mVCList);
        }

        // POST: MVCLists/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DoneFlg,TodoName,DeadLine,Remarks")] MVCList mVCList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mVCList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mVCList);
        }

        // GET: MVCLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVCList mVCList = db.MVCList.Find(id);
            if (mVCList == null)
            {
                return HttpNotFound();
            }
            return View(mVCList);
        }

        // POST: MVCLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MVCList mVCList = db.MVCList.Find(id);
            db.MVCList.Remove(mVCList);
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
