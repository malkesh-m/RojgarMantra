using RojgarMantra.Core.Constants;
using RojgarMantra.Core.Models;
using RojgarMantra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RojgarMantra.Controllers
{
    public class SMTPDetailsController : Controller
    {
        private ISMTPDetailsService _SMTPDetailsService;
        public SMTPDetailsController(ISMTPDetailsService SMTPDetailsService)
        {
            _SMTPDetailsService = SMTPDetailsService;
        }
        // GET: SMTPDetails
        [HttpGet]
        public async Task<ActionResult> Index(int id)
        {
            if (id == 0)
            {
                ViewBag.Mode = "Add";
                return View();
            }
            ViewBag.Mode = "Update";
            var result = await _SMTPDetailsService.Get(id);
            return View(result);
        }
        [HttpPost]
        public async Task<JsonResult> Index(SMTPDetailsAddEditModel model)
        {
            if (!ModelState.IsValid) return (Json(JsonModel.ModelStateError(ModelState)));

            var result = await _SMTPDetailsService.Save(model);
            if (result)
            {
                if (model.Id != 0)
                {
                    return Json(JsonModel.UpdateSuccess("SMTP Details"));
                }
                else
                {
                    return Json(JsonModel.CreateSuccess("SMTP Details"));
                }
            }
            return Json(new JsonModel(JsonType.Error, GlobalConstant.Error));
        }
    }
}