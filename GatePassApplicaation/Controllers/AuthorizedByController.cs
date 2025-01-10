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
            var details = _appDbContext.preparedBy.AsQueryable();
            if (startDate.HasValue && endDate.HasValue)
            {
                details = details.Where(d => d.DateTime >= startDate.Value && d.DateTime <= endDate.Value);
            }
            ViewData["StartDate"] = startDate?.ToString("yyyy-MM-dd");
            ViewData["EndDate"] = endDate?.ToString("yyyy-MM-dd");

            details = details.OrderByDescending(d => d.PreparedById);

            return View(details.ToList());
        }

        public IActionResult IndexApproved(DateOnly? startDate, DateOnly? endDate)
        {
            var approvedIndex = _appDbContext.authorizedBy.AsQueryable();
            if (startDate.HasValue && endDate.HasValue)
            {
                approvedIndex = approvedIndex.Where(d => d.DateTime >= startDate.Value && d.DateTime <= endDate.Value);
            }
            ViewData["StartDate"] = startDate?.ToString("yyyy-MM-dd");
            ViewData["EndDate"] = endDate?.ToString("yyyy-MM-dd");
            approvedIndex = approvedIndex.OrderByDescending(d => d.PreparedById);

            return View(approvedIndex.ToList());
        }

        public ActionResult DetailsNotApproved(int id)
        {
            var details = _appDbContext.preparedBy.Find(id);
            return View("DetailsNotApproved", details);
        }
        public ActionResult DetailsApproved(int id)
        {
            var details = _appDbContext.authorizedBy.Find(id);
            return View("DetailsApproved", details);
        }
        [HttpPost]
public IActionResult Approve(int id)
{
    var record = _appDbContext.preparedBy.FirstOrDefault(a => a.PreparedById == id);

    if (record != null)
    {
        var newRecord = _appDbContext.authorizedBy.FirstOrDefault(a => a.PreparedById == id);

        if (newRecord == null)
        {
            newRecord = new AuthorizedBy
            {
                NameOfGoods = record.NameOfGoods,
                Reason = record.Reason,
                Facility = record.Facility,
                SupplierName = record.SupplierName,
                PreparedPerson = record.PreparedPerson,
                Description = record.Description,
                takenBy = record.takenBy,
                SendTo = record.SendTo,
                Department = record.Department,
                LineNo = record.LineNo,
                DateTime = DateOnly.FromDateTime(DateTime.Now),
                PartNo = record.PartNo,
                Quantity = record.Quantity,
                Value = record.Value,
                AuthorizedPerson = HttpContext.Session.GetString("UserName")
            };

            _appDbContext.authorizedBy.Add(newRecord);
        }
        else
        {
            newRecord.AuthorizedPerson = HttpContext.Session.GetString("UserName");
            _appDbContext.authorizedBy.Update(newRecord);
        }

        _appDbContext.SaveChanges();
        _appDbContext.preparedBy.Remove(record);
        _appDbContext.SaveChanges();


    }

    return RedirectToAction("Index");
}

        [HttpPost]
        public ActionResult NonApprove(int id)
        {
            var record = _appDbContext.authorizedBy.FirstOrDefault(a => a.PreparedById == id);
            if(record != null)
            {
                var newRecord = _appDbContext.preparedBy.FirstOrDefault(a => a.PreparedById == id);

                if (newRecord == null)
                {
                    newRecord = new PreparedBy
                    {
                        NameOfGoods = record.NameOfGoods,
                        Reason = record.Reason,
                        Facility = record.Facility,
                        SupplierName = record.SupplierName,
                        Description = record.Description,
                        takenBy = record.takenBy,
                        SendTo = record.SendTo,
                        Department = record.Department,
                        LineNo = record.LineNo,
                        DateTime = record.DateTime,
                        PartNo = record.PartNo,
                        Quantity = record.Quantity,
                        Value = record.Value,
                        PreparedPerson = HttpContext.Session.GetString("UserName")
                    };

                    _appDbContext.preparedBy.Add(newRecord);
                }
                else
                {
                    newRecord.PreparedPerson = HttpContext.Session.GetString("UserName");
                    _appDbContext.preparedBy.Update(newRecord);
                }

                _appDbContext.SaveChanges();
                _appDbContext.authorizedBy.Remove(record);
                _appDbContext.SaveChanges();


            }

            return RedirectToAction("IndexApproved");
        
        }

    }
}
