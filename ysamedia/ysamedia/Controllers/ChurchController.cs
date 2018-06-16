using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ysamedia.Controllers
{
    public class ChurchController : Controller
    {
        // GET: Church
        public ActionResult Index()
        {
            return View();
        }

        // GET: Church/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Church/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Church/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Church/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Church/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Church/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Church/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}