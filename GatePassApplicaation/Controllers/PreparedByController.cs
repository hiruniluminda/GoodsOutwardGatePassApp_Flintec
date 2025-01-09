using GatePassApplicaation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GatePassApplicaation.Controllers
{
    public class PreparedByController : BaseController
    {
        private readonly AppDbContext dbContext;

        public PreparedByController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index(DateOnly? startDate, DateOnly? endDate)
        {
            var details= dbContext.preparedBy.AsQueryable();
            if (startDate.HasValue && endDate.HasValue)
            {
                details = details.Where(d=>d.DateTime >= startDate.Value && d.DateTime <= endDate.Value);
            }
            ViewData["StartDate"] = startDate?.ToString("yyyy-MM-dd");
            ViewData["EndDate"] = endDate?.ToString("yyyy-MM-dd");

            details = details.OrderByDescending(d => d.PreparedById);

            return View(details.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PreparedBy preparedBy)
        {
            var createdBy = HttpContext.Session.GetString("UserName");
            preparedBy.PreparedPerson = createdBy;
            dbContext.Add(preparedBy);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var editdetails = dbContext.preparedBy.Find(id);
            return View(editdetails);
        }
        [HttpPost]
        public ActionResult Edit(PreparedBy preparedBy)
        {
            dbContext.Entry(preparedBy).State = EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) {
            var deletedetails = dbContext.preparedBy.Find(id);
            dbContext.preparedBy.Remove(deletedetails);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
