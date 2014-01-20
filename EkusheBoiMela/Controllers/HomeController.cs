using System.Web.Mvc;
using EkusheBoiMela.Model.Entity;
using EkusheBoiMela.Repository.Repository;

namespace EkusheBoiMela.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository = new UserRepository();
        public ActionResult Index()
        {
            if (Session["loggedInUserRole"] == null)
            {

                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Login()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
            var isValidUser = _userRepository.IsValidUser(user);
            if (isValidUser)
            {
                var loggedInUser = _userRepository.GetUserByMail(user.Name);

                if (loggedInUser != null)
                {

                    Session["loggedInUser"] = user.Name;
                    Session["loggedInUserRole"] = loggedInUser.Role;

                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session["loggedInUser"] = null;
            Session["loggedInUserRole"] = null;

            return RedirectToAction("Login");
        }
    }
}
