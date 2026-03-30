using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using FeedbackManagement.Models.Context;
using FeedbackManagement.Models.ViewModels;

namespace FeedbackManagement.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly dbcontext db = new dbcontext();

        // GET: FeedbackSummary (liste simple) - protégé
        [Authorize]
        public ActionResult FeedbackSummary(string status = null)
        {
            var userEmail = User.Identity.Name;
            if (string.IsNullOrEmpty(userEmail) || !db.Contacts.Any(u => u.Email == userEmail))
                return RedirectToAction("Login", "Account");

            var query = db.Feedbacks.Include(f => f.Status).Include(f => f.Contact).AsQueryable();

            if (!string.IsNullOrEmpty(status))
                query = query.Where(f => f.Status.Name == status);

            var list = query.Select(f => new FeedbackStatusViewModel
            {
                Id = f.Id,
                StatusId = f.StatusId,
                Comment = f.Comment,
                ContactName = f.Contact != null ? f.Contact.Name : "",
                Email = f.Contact != null ? f.Contact.Email : "",
                StatusName = f.Status != null ? f.Status.Name : ""
            }).ToList();

            return View(list); // FeedbackSummary.cshtml expects List<FeedbackStatusViewModel>
        }

        // Dashboard action — protégé
        [Authorize]
        public ActionResult Dashboard()
        {
            var list = db.Feedbacks
                .Include(f => f.Status)
                .Include(f => f.Contact)
                .Select(f => new FeedbackStatusViewModel
                {
                    Id = f.Id,
                    StatusId = f.StatusId,
                    Comment = f.Comment,
                    ContactName = f.Contact != null ? f.Contact.Name : "",
                    Email = f.Contact != null ? f.Contact.Email : "",
                    StatusName = f.Status != null ? f.Status.Name : ""
                })
                .ToList();

            return View(list); // Dashboard.cshtml expects List<FeedbackStatusViewModel>
        }

        // Partial, EditStatus, Delete — inchangés (vérifie que [ValidateAntiForgeryToken] est présent)
        [HttpGet]
        [Authorize]
        public ActionResult EditStatusPartial(int id)
        {
            var feedback = db.Feedbacks.Find(id);
            if (feedback == null) return HttpNotFound();

            var vm = new FeedbackStatusViewModel
            {
                Id = feedback.Id,
                StatusId = feedback.StatusId,
                Comment = feedback.Comment
            };

            ViewBag.StatusId = new SelectList(db.FeedbackStatuses, "Id", "Name", vm.StatusId);
            return PartialView("_EditStatusPartial", vm);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public JsonResult EditStatus(FeedbackStatusViewModel model)
        {
            if (!ModelState.IsValid) return Json(new { success = false, error = "Données invalides." });

            var feedback = db.Feedbacks.Find(model.Id);
            if (feedback == null) return Json(new { success = false, error = "Feedback introuvable." });

            feedback.StatusId = model.StatusId ?? feedback.StatusId;
            feedback.Comment = model.Comment;
            db.Entry(feedback).State = EntityState.Modified;
            db.SaveChanges();

            var statusName = db.FeedbackStatuses.Find(feedback.StatusId)?.Name ?? "";
            return Json(new { success = true, id = feedback.Id, status = statusName, comment = feedback.Comment });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            var feedback = db.Feedbacks.Find(id);
            if (feedback == null) return Json(new { success = false, error = "Feedback introuvable." });

            db.Feedbacks.Remove(feedback);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
