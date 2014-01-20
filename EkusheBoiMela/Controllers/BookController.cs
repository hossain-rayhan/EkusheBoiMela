using System.Data;
using System.Linq;
using System.Web.Mvc;
using EkusheBoiMela.Model.Entity;
using EkusheBoiMela.Model;

namespace EkusheBoiMela.Controllers
{
    public class BookController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Book/

        public ActionResult Index()
        {
            if ((string) Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index","Home");
            }
            var books = db.Books;
            return View(books.ToList());
        }

        //
        // GET: /Book/Details/5

        public ActionResult Details(long id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name");
            ViewBag.CatagoryId = new SelectList(db.Catagories, "Id", "Name");
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name");
            return View();
        }

        //
        // POST: /Book/Create

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", book.AuthorId);
            ViewBag.CatagoryId = new SelectList(db.Catagories, "Id", "Name", book.CatagoryId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        //
        // GET: /Book/Edit/5

        public ActionResult Edit(long id = 0)
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", book.AuthorId);
            ViewBag.CatagoryId = new SelectList(db.Catagories, "Id", "Name", book.CatagoryId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", book.AuthorId);
            ViewBag.CatagoryId = new SelectList(db.Catagories, "Id", "Name", book.CatagoryId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "Name", book.PublisherId);
            return View(book);
        }

        //
        // GET: /Book/Delete/5

        public ActionResult Delete(long id = 0)
        {
            if ((string)Session["loggedInUserRole"] != "admin")
            {

                return RedirectToAction("Index", "Home");
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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