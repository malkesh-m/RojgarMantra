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
    public class CountryController : Controller
    {
        private ICountryService _CountryService;
        public CountryController(ICountryService CountryService)
        {
            _CountryService = CountryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> List(JqueryDatatableParam model)
        {
            var ListOutputModel = await _CountryService.GetAll(Common.CreateListInputModel(model));
            return Json(new { echo = model.sEcho, recordsFiltered = ListOutputModel.RecordsTotal, recordsTotal = ListOutputModel.RecordsTotal, data = ListOutputModel.Data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AddEdit(int id)
        {
            if (id == 0)
            {

                ViewBag.Mode = "Add";
                return View();
            }
            ViewBag.Mode = "Update";
            var result = await _CountryService.Get(id);
            return View(result);
        }
        [HttpPost]
        public async Task<JsonResult> AddEdit(CountryAddEditModel model)
        {
            if (!ModelState.IsValid) return (Json(JsonModel.ModelStateError(ModelState)));

            var result = await _CountryService.Save(model);
            if (result)
            {
                if (model.Id != 0)
                {
                    return Json(JsonModel.UpdateSuccess("Country"));
                }
                else
                {
                    return Json(JsonModel.CreateSuccess("Country"));
                }
            }
            return Json(new JsonModel(JsonType.Error, GlobalConstant.Error));
        }

        public async Task<JsonResult> Delete(int id)
        {
            var result = await _CountryService.Delete(id);
            if (result)
                return Json(JsonModel.DeleteSuccess("Country"));
            else
                return Json(JsonModel.DeleteFailed("Country"));
        }
    }
}