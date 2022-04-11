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
    public class ScheduleWebinarController : Controller
    {
        private IScheduleWebinarService _scheduleWebinarService;
        public ScheduleWebinarController(IScheduleWebinarService scheduleWebinarService)
        {
            _scheduleWebinarService = scheduleWebinarService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> List(JqueryDatatableParam model)
        {
            var ListOutputModel = await _scheduleWebinarService.GetAll(Common.CreateListInputModel(model));
            return Json(new { echo = model.sEcho, recordsFiltered = ListOutputModel.RecordsTotal, recordsTotal = ListOutputModel.RecordsTotal, data = ListOutputModel.Data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddEdit(int id)
        {
            if (id == 0)
            {
                ScheduleWebinarAddEditModel result1 = new ScheduleWebinarAddEditModel();
                result1.Id = id;
                ViewBag.Mode = "Add";
                return View(result1);
            }
            ViewBag.Mode = "Update";
            var result = await _scheduleWebinarService.Get(id);
            return View(result);
        }
        [HttpPost]
        public async Task<JsonResult> AddEdit(ScheduleWebinarAddEditModel model)
        {
            if (!ModelState.IsValid) return (Json(JsonModel.ModelStateError(ModelState)));

            var result = await _scheduleWebinarService.Save(model);
            if (result)
            {
                if (model.Id != 0)
                {
                    return Json(JsonModel.UpdateSuccess("Schedule Webinar"));
                }
                else
                {
                    return Json(JsonModel.CreateSuccess("Schedule Webinar"));
                }
            }
            return Json(new JsonModel(JsonType.Error, GlobalConstant.Error));
        }

        public async Task<JsonResult> Delete(int id)
        {
            var result = await _scheduleWebinarService.Delete(id);
            if (result)
                return Json(JsonModel.DeleteSuccess("Schedule Webinar"));
            else
                return Json(JsonModel.DeleteFailed("Schedule Webinar"));
        }
    }
}