using EkusheBoiMela.Model;
using EkusheBoiMela.Model.Entity;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace EkusheBoiMela.Controllers
{
    public class CatagoryController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Catagory/

        public ActionResult Index()
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            return View(db.Catagories.ToList());
        }

        //
        // GET: /Catagory/Details/5

        public ActionResult Details(long id = 0)
        {
            Catagory catagory = db.Catagories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        //
        // GET: /Catagory/Create

        public ActionResult Create()
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //
        // POST: /Catagory/Create

        [HttpPost]
        public ActionResult Create(Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                db.Catagories.Add(catagory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catagory);
        }

        //
        // GET: /Catagory/Edit/5

        public ActionResult Edit(long id = 0)
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            Catagory catagory = db.Catagories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        //
        // POST: /Catagory/Edit/5

        [HttpPost]
        public ActionResult Edit(Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catagory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catagory);
        }

        //
        // GET: /Catagory/Delete/5

        public ActionResult Delete(long id = 0)
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            Catagory catagory = db.Catagories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

        //
        // POST: /Catagory/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Catagory catagory = db.Catagories.Find(id);
            db.Catagories.Remove(catagory);
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