using GatePassApplicaation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace GatePassApplicaation.Controllers
{
    public class AuthorizedByController : BaseController
    {
        private readonly AppDbContext _appDbContext;
        public AuthorizedByController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index(DateOnly? startDate, DateOnly? endDate)
        {
            var details = _appDbContext.passNotes.Include(d => d.PassHeader).AsQueryable();
            if (startDate.HasValue && endDate.HasValue)
            {
                details = details.Where(d => d.PassHeader.DateTime >= startDate.Value && d.PassHeader.DateTime <= endDate.Value);
            }
            ViewData["StartDate"] = startDate?.ToString("yyyy-MM-dd");
            ViewData["EndDate"] = endDate?.ToString("yyyy-MM-dd");

            details = details.OrderByDescending(d => d.PartNo);
            var passHeaders = details.Select(d => d.PassHeader).Distinct().ToList();

            return View(passHeaders);
        }

        public IActionResult IndexApproved(DateOnly? startDate, DateOnly? endDate)
        {
            var approvedIndex = _appDbContext.passNoteLeads.Include(d => d.PassHeaderLead).AsQueryable();
            if (startDate.HasValue && endDate.HasValue)
            {
                approvedIndex = approvedIndex.Where(d => d.PassHeaderLead.DateTime >= startDate.Value && d.PassHeaderLead.DateTime <= endDate.Value);
            }
            ViewData["StartDate"] = startDate?.ToString("yyyy-MM-dd");
            ViewData["EndDate"] = endDate?.ToString("yyyy-MM-dd");
            approvedIndex = approvedIndex.OrderByDescending(d => d.PartNo);
            var passHeaderLead = approvedIndex.Select(d => d.PassHeaderLead).Distinct().ToList();
            return View(passHeaderLead);
        }

        public ActionResult DetailsNotApproved(int id)
        {
            var data = _appDbContext.passHeaders.Include(ph => ph.Reasons).Include(ph => ph.PassDetails).FirstOrDefault(ph => ph.PassNo == id);

            if (data == null)
            {
                return NotFound();
            }

            return View("DetailsNotApproved", data);
        }

        public ActionResult DetailsApproved(int id)
        {
            var data = _appDbContext.passHeaderLeads.Include(ph => ph.Reasons).Include(ph => ph.PassDetails).FirstOrDefault(ph => ph.PassNo == id);

            if (data == null)
            {
                return NotFound();
            }

            return View("DetailsApproved", data);
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Approve(int id)
        {
            var passHeaderRecord = _appDbContext.passHeaders.Include(p => p.PassDetails).FirstOrDefault(a => a.PassNo == id);

            if (passHeaderRecord == null)
            {
                return NotFound();
            }

            try
            {
                using (var transaction = _appDbContext.Database.BeginTransaction())
                {
                    var passHeaderLead = new PassHeaderLead
                    {
                        ReasonId = passHeaderRecord.ReasonId,
                        Facility = passHeaderRecord.Facility,
                        SupplierName = passHeaderRecord.SupplierName,
                        PreparedPerson = passHeaderRecord.PreparedPerson,
                        takenBy = passHeaderRecord.takenBy,
                        SendTo = passHeaderRecord.SendTo,
                        Department = passHeaderRecord.Department,
                        DateTime = DateOnly.FromDateTime(DateTime.Now),
                        AuthorizedPerson = HttpContext.Session.GetString("UserName"),
                    };

                    _appDbContext.passHeaderLeads.Add(passHeaderLead);
                    _appDbContext.SaveChanges();

                    foreach (var passNote in passHeaderRecord.PassDetails)
                    {
                        var passNoteLead = new PassNoteLead
                        {
                            NameOfGoods = passNote.NameOfGoods,
                            Description = passNote.Description,
                            LineNo = passNote.LineNo,
                            PartNo = passNote.PartNo,
                            Quantity = passNote.Quantity,
                            Value = passNote.Value,
                            PassNo = passHeaderLead.PassNo
                        };

                        _appDbContext.passNoteLeads.Add(passNoteLead);
                    }

                    _appDbContext.SaveChanges();

                    _appDbContext.passHeaders.Remove(passHeaderRecord);
                    _appDbContext.passNotes.RemoveRange(passHeaderRecord.PassDetails);

                    _appDbContext.SaveChanges();
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                _appDbContext.Database.RollbackTransaction();
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult NonApprove(int id)
        {
            var passHeaderLead = _appDbContext.passHeaderLeads.Include(p => p.PassDetails).FirstOrDefault(a => a.PassNo == id);

            if (passHeaderLead != null)
            {
                try
                {
                    using (var transaction = _appDbContext.Database.BeginTransaction())
                    {
                        var passHeader = new PassHeader
                        {
                            ReasonId = passHeaderLead.ReasonId,
                            Facility = passHeaderLead.Facility,
                            SupplierName = passHeaderLead.SupplierName,
                            PreparedPerson = passHeaderLead.PreparedPerson,
                            takenBy = passHeaderLead.takenBy,
                            SendTo = passHeaderLead.SendTo,
                            Department = passHeaderLead.Department,
                            DateTime = passHeaderLead.DateTime,
                        };

                        _appDbContext.passHeaders.Add(passHeader);
                        _appDbContext.SaveChanges();

                        foreach (var passNoteLead in passHeaderLead.PassDetails)
                        {
                            var passNote = new PassNote
                            {
                                NameOfGoods = passNoteLead.NameOfGoods,
                                Description = passNoteLead.Description,
                                LineNo = passNoteLead.LineNo,
                                PartNo = passNoteLead.PartNo,
                                Quantity = passNoteLead.Quantity,
                                Value = passNoteLead.Value,
                                PassNo = passHeader.PassNo
                            };

                            _appDbContext.passNotes.Add(passNote);
                        }

                        _appDbContext.SaveChanges();

                        _appDbContext.passHeaderLeads.Remove(passHeaderLead);
                        _appDbContext.passNoteLeads.RemoveRange(passHeaderLead.PassDetails);

                        _appDbContext.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    _appDbContext.Database.RollbackTransaction();
                    return StatusCode(500, "Internal server error: " + ex.Message);
                }
            }

            return RedirectToAction("IndexApproved");
        }


    }
}
