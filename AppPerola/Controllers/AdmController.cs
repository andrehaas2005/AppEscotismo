using AppPerola.Models;
using RTE;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AppPerola.Controllers
{
    [ValidateInput(false)]
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
        [ValidateInput(false)]
        public ActionResult Create()
        {
            Editor Editor1 = PrepairEditor("Texto", delegate(Editor editor)
            {
                editor.ID = editor.Name = "Texto";
                editor.Height = Unit.Pixel(300);
               // editor.Text = "Type here";
                editor.Skin = "office2010blue";
                //editor.Toolbar = "light";
            });

            ViewBag.Editor1 = Editor1.MvcGetString();

            return View();
        }
  

        
        [ValidateInput(false)]
        
        private Editor PrepairEditor(string propertyName, Action<Editor> oninit)
        {
            Editor editor = new Editor(System.Web.HttpContext.Current, propertyName);

            editor.ClientFolder = "/richtexteditor/";
            editor.ContentCss = "/Content/Site.css";
           // editor.Skin = "office2010";
            //editor.ClientFolder = "/Content/richtexteditor/";
            //editor.ClientFolder = "/Scripts/richtexteditor/";

           // editor.Text = "Type here";

            editor.AjaxPostbackUrl = Url.Action("EditorAjaxHandler");

            if (oninit != null) oninit(editor);

            //try to handle the upload/ajax requests
            bool isajax = editor.MvcInit();

            if (isajax)
                return editor;

            //load the form data if any
            if (this.Request.HttpMethod == "POST")
            {
                string formdata = this.Request.Form[editor.Name];
                if (formdata != null)
                    editor.LoadFormData(formdata);
            }

            //render the editor to ViewBag.Editor
            ViewBag.Editor = editor.MvcGetString();

            return editor;
        }

        //
        // POST: /Adm/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(tb_chamadas model)
        {

            Editor theeditor = PrepairEditor("Texto", delegate(Editor editor)
            {
                //set editor properties here
            });

            model.Texto = theeditor.ApplyFilter(model.Texto);

            //or use , while the LoadFormData is called
            //model.Message = theeditor.Text;

            //check the editor data here

            if (ModelState.IsValid)
            {
                //TODO , save the data to DB , and redirect to result page..
            }

            return View(model);

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

        [ValidateInput(false)]
        public ActionResult EditorAjaxHandler()
        {
            PrepairEditor("Texto", delegate(Editor editor)
            {

            });
            return new EmptyResult();
        }
    }
}
