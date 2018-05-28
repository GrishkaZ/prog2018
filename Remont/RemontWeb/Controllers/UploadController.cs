using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RemontWeb.Models;

namespace RemontWeb.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Print(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var dto = Remont.RideDtoHelper.LoadFromStream(file.InputStream);

                using (var db = new ApplicationDbContext())
                {
                    var row = new DBRemontModel
                    {
                        Days = dto.TimeOfRepair.Days,
                        Filled = dto.TimeOfRepair.Filled,
                        FullName = dto.FullName,
                        Price = dto.Price.Price,
                        Currency = (Models.Currency)(int)dto.Price.Currency,
                        BrokenDevice = (Models.Apparat)(int)dto.DescriptionOfBreakageDevice.BrokenDevice,
                        BuySomeDetailsYourself = dto.Repair.BuySomeDetailsYourself,
                        AdditionalRequests = dto.Repair.AdditionalRequests,                      
                    };

                    row.Breakages = new Collection<DBBreakage>();

                    foreach (var brDto in dto.DescriptionOfBreakageDevice.Breakage)
                    {
                        row.Breakages.Add(new DBBreakage
                        {
                            BreakageType = (Models.DamageType)(int)brDto.BreakageType,
                            Description = brDto.Description
                        });
                    }

                    db.RemontModels.Add(row);
                    db.SaveChanges();
                }

                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}