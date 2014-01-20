using EkusheBoiMela.Model;
using EkusheBoiMela.Model.Entity;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace EkusheBoiMela.Controllers
{
    public class PublisherController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Publisher/

        public ActionResult Index()
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            return View(db.Publishers.ToList());
        }

        //
        // GET: /Publisher/Details/5

        public ActionResult Details(long id = 0)
        {

            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        //
        // GET: /Publisher/Create

        public ActionResult Create()
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //
        // POST: /Publisher/Create

        [HttpPost]
        public ActionResult Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publisher);
        }

        //
        // GET: /Publisher/Edit/5

        public ActionResult Edit(long id = 0)
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        //
        // POST: /Publisher/Edit/5

        [HttpPost]
        public ActionResult Edit(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        //
        // GET: /Publisher/Delete/5

        public ActionResult Delete(long id = 0)
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        //
        // POST: /Publisher/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Publisher publisher = db.Publishers.Find(id);
            db.Publishers.Remove(publisher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}