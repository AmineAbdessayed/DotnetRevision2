using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.WEB.Controllers
{
    public class ExpertiseController : Controller
    {

        readonly IService<Expertise> tacheService;

        public ExpertiseController(IService<Expertise> tacheService)
        {
            this.tacheService = tacheService;
        }
        // GET: ExpertiseController
        public ActionResult Index(string filter )
        {
            if (!string.IsNullOrEmpty(filter))
                return View(tacheService.GetAll().Where(f => f.Sinistre.assurance.Type.ToString()==filter));
            return View(tacheService.GetAll().OrderBy(h => h.DateExpertise));
        }


        // GET: ExpertiseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpertiseController/Create
        public ActionResult Create()
        {
            var amine = tacheService.GetAll();
            ViewBag.e = new SelectList(amine, "ExpertFk", "ExpertFk");  // ken teheb tbadl haja badelha f sprintKey el thenya
            ViewBag.s = new SelectList(amine, "SinistreFk", "SinistreFk");
            return View();
        }
        // POST: ExpertiseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Expertise amine)
        {
            try
            {
                tacheService.Add(amine);
                tacheService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpertiseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExpertiseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpertiseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExpertiseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
