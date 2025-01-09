//// Controllers/AdminController.cs
//using GatePassApplicaation.Models;
//using Microsoft.AspNetCore.Mvc;




//    [HttpPost]
//    public IActionResult CreateForm(string formName)
//    {
//        var createdBy = HttpContext.Session.GetString("UserName");
//        var form = new Form { FormName = formName, CreatedBy = createdBy };
//        _context.Forms.Add(form);
//        _context.SaveChanges();
//        return RedirectToAction("Index");
//    }
//}
