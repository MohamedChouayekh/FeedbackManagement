using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using FeedbackManagement.Models.Context;
using FeedbackManagement.Models.Entities;
using FeedbackManagement.Models.DTO;

namespace FeedbackManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly dbcontext db = new dbcontext();

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Create() => View("Create");

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Contacts.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Cet email est déjà utilisé.");
                    return View(model);
                }

                var user = new Contact { Name = model.Name, Email = model.Email };
                db.Contacts.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login() => View();

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email)
        {
            var user = db.Contacts.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("FeedbackSummary", "Feedback"); // login -> FeedbackSummary
            }
            ModelState.AddModelError("", "Email invalide.");
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
