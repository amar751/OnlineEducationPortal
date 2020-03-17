using OnlineEducationPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducationPortal.Controllers
{
    public class StudyController : Controller
    {

        EducationPortalEntities instance = new EducationPortalEntities();

        // GET: Study
        public ActionResult StudyRecord()
        {
            return View(instance.StudyDatas.ToList());
        }

        // GET: Study/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Study/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Study/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]StudyData details)
        {
            if (!ModelState.IsValid)
                return View();
            instance.StudyDatas.Add(details);
            instance.SaveChanges();
            return RedirectToAction("StudyRecord");
        }

        // GET: Study/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in instance.StudyDatas where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Study/Edit/5
        [HttpPost]
        public ActionResult Edit(StudyData IdToEdit)
        {
            var orignalRecord = (from m in instance.StudyDatas where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            instance.SaveChanges();
            return RedirectToAction("StudyRecord");


        }

        // GET: Study/Delete/5
        public ActionResult Delete(StudyData IdToDelete)
        {

            var d = instance.StudyDatas.Where(x => x.id == IdToDelete.id).FirstOrDefault();
            instance.StudyDatas.Remove(d);
            instance.SaveChanges();
            return RedirectToAction("StudyRecord");
        }

        // POST: Study/Delete/5
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
