using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using FeedbackManagement.Models.Context;
using FeedbackManagement.Models.ViewModels;

namespace FeedbackManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly dbcontext db = new dbcontext();

        // Page d'accueil (redirige vers Dashboard)
        public ActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        // Tableau de bord
        public ActionResult Dashboard()
        {
            var feedbacks = db.Feedbacks
                .Include(f => f.Status)
                .Include(f => f.Contact)
                .Select(f => new FeedbackStatusViewModel
                {
                    Id = f.Id,
                    Comment = f.Comment,
                    ContactName = f.Contact != null ? f.Contact.Name : "",
                    Email = f.Contact != null ? f.Contact.Email : "",
                    StatusName = f.Status != null ? f.Status.Name : ""
                })
                .ToList();

            return View(feedbacks);
        }
    }
}
