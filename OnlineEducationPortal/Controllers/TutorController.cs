using OnlineEducationPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducationPortal.Controllers
{
    public class TutorController : Controller
    {
        // GET: Tutor
        EducationPortalEntities instance = new EducationPortalEntities();

        public ActionResult TutorRecord()
        {
            return View(instance.RegisterDatas.ToList());
        }

        // GET: Tutor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tutor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tutor/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]RegisterData details)
        {
            if (!ModelState.IsValid)
                return View();
            instance.RegisterDatas.Add(details);
            instance.SaveChanges();
            return RedirectToAction("TutorRecord");

        }

        // GET: Tutor/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in instance.RegisterDatas where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Tutor/Edit/5
        [HttpPost]
        public ActionResult Edit(RegisterData IdToEdit)
        {
            var orignalRecord = (from m in instance.RegisterDatas where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            instance.SaveChanges();
            return RedirectToAction("TutorRecord");

        }

        // GET: Tutor/Delete/5
        public ActionResult Delete(RegisterData IdtoDelete)
        {
            var d = instance.RegisterDatas.Where(x => x.id ==IdtoDelete.id).FirstOrDefault();
            instance.RegisterDatas.Remove(d);
            instance.SaveChanges();
            return RedirectToAction("TutorRecord");
        }

        // POST: Tutor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
