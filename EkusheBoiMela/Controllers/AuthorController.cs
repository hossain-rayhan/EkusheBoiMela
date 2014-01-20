using EkusheBoiMela.Model;
using EkusheBoiMela.Model.Entity;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace EkusheBoiMela.Controllers
{
    public class AuthorController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Author/

        public ActionResult Index()
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            return View(db.Authors.ToList());
        }

        //
        // GET: /Author/Details/5

        public ActionResult Details(long id = 0)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        //
        // GET: /Author/Create

        public ActionResult Create()
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //
        // POST: /Author/Create

        [HttpPost]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        //
        // GET: /Author/Edit/5

        public ActionResult Edit(long id = 0)
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        //
        // POST: /Author/Edit/5

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        //
        // GET: /Author/Delete/5

        public ActionResult Delete(long id = 0)
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        //
        // POST: /Author/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
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