using GatePassApplicaation.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var details = dbContext.passNotes.Include(d => d.PassHeader).ThenInclude(p => p.Reasons).Include(d => d.PassHeader.Actions).AsQueryable();
            if (startDate.HasValue && endDate.HasValue)
            {
                details = details.Where(d => d.PassHeader.DateTime >= startDate.Value && d.PassHeader.DateTime <= endDate.Value);
            }

            ViewData["StartDate"] = startDate?.ToString("yyyy-MM-dd");
            ViewData["EndDate"] = endDate?.ToString("yyyy-MM-dd");

            details = details.OrderByDescending(d => d.PassNo);

            // Fix: Modify to pass PassHeaders to the view
            var passHeaders = details.Select(d => d.PassHeader).Distinct().ToList();

            return View(passHeaders);  // Passing PassHeaders to the view
        }

        public ActionResult Create()
        {
            var model = new PassHeader
            {
                DateTime = DateOnly.FromDateTime(DateTime.Now),
                Facility = HttpContext.Session.GetString("Facility"),
                PassDetails = new List<PassNote>()
            };
            ViewBag.ReasonId = dbContext.reasons.Select(d=>new SelectListItem { Value=d.ReasonId.ToString(),Text=d.ReasonName }).ToList();
            ViewBag.ActionId = dbContext.actions.Select(c=>new SelectListItem { Value=c.ActionId.ToString(),Text=c.ActionName }).ToList();
            return View(model);
        }

        public async Task<int> GetNextPassNo()
        {
            var latestPass = await dbContext.passHeaders
                                           .OrderByDescending(p => p.Id)
                                           .FirstOrDefaultAsync();
            return (latestPass != null) ? latestPass.PassNo + 1 : 1000; // Start from 1000 if empty
        }

        [HttpPost]
        public async Task<IActionResult> Create(PassHeader passHeader)
        {
            ViewBag.ReasonId = await dbContext.reasons
                .Select(d => new SelectListItem { Value = d.ReasonId.ToString(), Text = d.ReasonName })
                .ToListAsync();

            ViewBag.ActionId = await dbContext.actions
                .Select(c => new SelectListItem { Value = c.ActionId.ToString(), Text = c.ActionName })
                .ToListAsync();

            var createdBy = HttpContext.Session.GetString("UserName");
            passHeader.PreparedPerson = createdBy;

            // Await the async method properly
            passHeader.PassNo = await GetNextPassNo();

            if (passHeader.PassDetails != null && passHeader.PassDetails.Any())
            {
                foreach (var passNote in passHeader.PassDetails)
                {
                    passNote.PassNo = passHeader.PassNo;
                }
            }

            dbContext.Add(passHeader);
            await dbContext.SaveChangesAsync(); // Make it async
            passHeader.PassNo = passHeader.Id;
            dbContext.Update(passHeader);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var data = dbContext.passHeaders.Include(ph=>ph.Actions).Include(ph => ph.Reasons).Include(ph => ph.PassDetails).FirstOrDefault(ph => ph.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return View("Details", data);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var passHeader = dbContext.passHeaders
                .Include(ph => ph.PassDetails)
                .FirstOrDefault(ph => ph.Id == id);

            if (passHeader == null)
            {
                return NotFound();
            }

            ViewBag.ReasonId = dbContext.reasons.Select(d => new SelectListItem
            {
                Value = d.ReasonId.ToString(),
                Text = d.ReasonName
            }).ToList();
            ViewBag.ActionId = dbContext.actions.Select(c => new SelectListItem { Value = c.ActionId.ToString(), Text = c.ActionName }).ToList();

            // Initialize PassDetails if it's null
            if (passHeader.PassDetails == null)
            {
                passHeader.PassDetails = new List<PassNote>();
            }

            return View(passHeader);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PassHeader passHeader)
        {
            
                ViewBag.ReasonId = dbContext.reasons.Select(d => new SelectListItem
                {
                    Value = d.ReasonId.ToString(),
                    Text = d.ReasonName
                }).ToList();
            ViewBag.ActionId = dbContext.actions.Select(c => new SelectListItem { Value = c.ActionId.ToString(), Text = c.ActionName }).ToList();

            var createdBy = HttpContext.Session.GetString("UserName");

            passHeader.PreparedPerson = createdBy;

            dbContext.Entry(passHeader).State = EntityState.Modified;

            foreach (var passNote in passHeader.PassDetails)
            {
                if (passNote.GoodsId == 0)
                {
                    dbContext.passNotes.Add(passNote);
                }
                else 
                {
                    dbContext.Entry(passNote).State = EntityState.Modified;
                }
            }

            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }





        public ActionResult Delete(int id)
        {
            var deleteDetails = dbContext.passHeaders.Include(ph => ph.PassDetails).FirstOrDefault(ph => ph.Id == id);

            if (deleteDetails == null)
            {
                return NotFound();
            }

            dbContext.passNotes.RemoveRange(deleteDetails.PassDetails);
            dbContext.passHeaders.Remove(deleteDetails);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
