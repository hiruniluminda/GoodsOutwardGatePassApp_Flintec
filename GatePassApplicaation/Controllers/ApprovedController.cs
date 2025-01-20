using GatePassApplicaation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace GatePassApplicaation.Controllers
{
    public class ApprovedController : BaseController
    {
        private readonly AppDbContext _appDbContext;
        public ApprovedController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index(DateOnly? startDate, DateOnly? endDate)
        {
            var details = _appDbContext.passNoteLeads.Include(d => d.PassHeaderLead).AsQueryable();
            if (startDate.HasValue && endDate.HasValue)
            {
                details = details.Where(d => d.PassHeaderLead.DateTime >= startDate.Value && d.PassHeaderLead.DateTime <= endDate.Value);
            }
            ViewData["StartDate"] = startDate?.ToString("yyyy-MM-dd");
            ViewData["EndDate"] = endDate?.ToString("yyyy-MM-dd");

            details = details.OrderByDescending(d => d.PartNo);
            var passHeaderLead = details.Select(d => d.PassHeaderLead).Distinct().ToList();

            return View(passHeaderLead);
        }

        public IActionResult IndexApproved(DateOnly? startDate, DateOnly? endDate)
        {
            var approvedIndex = _appDbContext.passNoteAdmins.Include(d => d.PassHeaderAdmin).AsQueryable();
            if (startDate.HasValue && endDate.HasValue)
            {
                approvedIndex = approvedIndex.Where(d => d.PassHeaderAdmin.DateTime >= startDate.Value && d.PassHeaderAdmin.DateTime <= endDate.Value);
            }
            ViewData["StartDate"] = startDate?.ToString("yyyy-MM-dd");
            ViewData["EndDate"] = endDate?.ToString("yyyy-MM-dd");
            approvedIndex = approvedIndex.OrderByDescending(d => d.PartNo);
            var passHeaderLead = approvedIndex.Select(d => d.PassHeaderAdmin).Distinct().ToList();
            return View(passHeaderLead);
        }

        public ActionResult DetailsNotApproved(int id)
        {
            var data = _appDbContext.passHeaderLeads.Include(ph => ph.Reasons).Include(ph => ph.PassDetails).FirstOrDefault(ph => ph.PassNo == id);

            if (data == null)
            {
                return NotFound();
            }

            return View("DetailsNotApproved", data);
        }

        public ActionResult DetailsApproved(int id)
        {
            var data = _appDbContext.passHeaderAdmins.Include(ph => ph.Reasons).Include(ph => ph.PassDetails).FirstOrDefault(ph => ph.PassNo == id);

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
            var passHeaderRecord = _appDbContext.passHeaderLeads.Include(p => p.PassDetails).FirstOrDefault(a => a.PassNo == id);

            if (passHeaderRecord == null)
            {
                return NotFound();
            }

            try
            {
                using (var transaction = _appDbContext.Database.BeginTransaction())
                {
                    var passHeaderAdmins = new PassHeaderAdmin
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

                    _appDbContext.passHeaderAdmins.Add(passHeaderAdmins);
                    _appDbContext.SaveChanges();

                    foreach (var passNote in passHeaderRecord.PassDetails)
                    {
                        var passNoteAdmin = new PassNoteAdmin
                        {
                            NameOfGoods = passNote.NameOfGoods,
                            Description = passNote.Description,
                            LineNo = passNote.LineNo,
                            PartNo = passNote.PartNo,
                            Quantity = passNote.Quantity,
                            Value = passNote.Value,
                            PassNo = passHeaderAdmins.PassNo
                        };

                        _appDbContext.passNoteAdmins.Add(passNoteAdmin);
                    }

                    _appDbContext.SaveChanges();

                    _appDbContext.passHeaderLeads.Remove(passHeaderRecord);
                    _appDbContext.passNoteLeads.RemoveRange(passHeaderRecord.PassDetails);

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
            var passHeaderAdmin = _appDbContext.passHeaderAdmins.Include(p => p.PassDetails).FirstOrDefault(a => a.PassNo == id);

            if (passHeaderAdmin != null)
            {
                try
                {
                    using (var transaction = _appDbContext.Database.BeginTransaction())
                    {
                        var passHeader = new PassHeaderLead
                        {
                            ReasonId = passHeaderAdmin.ReasonId,
                            Facility = passHeaderAdmin.Facility,
                            SupplierName = passHeaderAdmin.SupplierName,
                            PreparedPerson = passHeaderAdmin.PreparedPerson,
                            AuthorizedPerson = passHeaderAdmin.AuthorizedPerson,
                            takenBy = passHeaderAdmin.takenBy,
                            SendTo = passHeaderAdmin.SendTo,
                            Department = passHeaderAdmin.Department,
                            DateTime = passHeaderAdmin.DateTime,
                        };

                        _appDbContext.passHeaderLeads.Add(passHeader);
                        _appDbContext.SaveChanges();

                        foreach (var passNoteLead in passHeaderAdmin.PassDetails)
                        {
                            var passNoteLeads = new PassNoteLead
                            {
                                NameOfGoods = passNoteLead.NameOfGoods,
                                Description = passNoteLead.Description,
                                LineNo = passNoteLead.LineNo,
                                PartNo = passNoteLead.PartNo,
                                Quantity = passNoteLead.Quantity,
                                Value = passNoteLead.Value,
                                PassNo = passHeader.PassNo
                            };

                            _appDbContext.passNoteLeads.Add(passNoteLeads);
                        }

                        _appDbContext.SaveChanges();

                        _appDbContext.passHeaderAdmins.Remove(passHeaderAdmin);
                        _appDbContext.passNoteAdmins.RemoveRange(passHeaderAdmin.PassDetails);

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
