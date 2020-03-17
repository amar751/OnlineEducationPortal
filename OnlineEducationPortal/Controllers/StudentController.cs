using OnlineEducationPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducationPortal.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        EducationPortalEntities instance = new EducationPortalEntities();

        public ActionResult StudentDetails()
        {
            return View(instance.StudentDatas.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]StudentData details)
        {
            if (!ModelState.IsValid)
                return View();
            instance.StudentDatas.Add(details);
            instance.SaveChanges();
            return RedirectToAction("StudentDetails");

        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in instance.StudentDatas where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentData IdToEdit)
        {

            var orignalRecord = (from m in instance.StudentDatas where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            instance.SaveChanges();
            return RedirectToAction("StudentDetails");
        }

        // GET: Student/Delete/5
        public ActionResult Delete(StudentData IdToDelete)
        {
            var d = instance.StudentDatas.Where(x => x.id == IdToDelete.id).FirstOrDefault();
            instance.StudentDatas.Remove(d);
            instance.SaveChanges();
            return RedirectToAction("StudentDetails");
        }

        // POST: Student/Delete/5
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
