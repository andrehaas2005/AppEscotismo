using AppPerola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPerola.Controllers
{
    public class AdmController : Controller
    {

        perolaEntities db = new perolaEntities();
        //
        // GET: /Adm/
        public ActionResult Index()
        {
            var model = db.tb_chamadas.Where(c => c.Ativo == true).ToList();
            return View(model);
        }

        //
        // GET: /Adm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Adm/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Adm/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Adm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Adm/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Adm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Adm/Delete/5
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
